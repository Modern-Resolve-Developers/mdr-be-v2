using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using danj_backend.Authentication;
using danj_backend.DB;
using danj_backend.EFCore.EFUsers;
using danj_backend.Helper;
using danj_backend.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using danj_backend.Extensions;
using danj_backend.JwtHelpers;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(configuration["ConnectionStrings:localenv"],
    providerOptions => providerOptions.EnableRetryOnFailure())
);

builder.Services.AddIdentity<ApplicationAuthentication, IdentityRole>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:IssuerSigningKey"]))
    };
});
var myappOrigins = "_myAppOrigins";
// Add services to the container.
//builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy(myappOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001", "https://mdr-dev-stage-frontend.vercel.app")
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
    );
});



builder.Services.AddControllers();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
    Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
});

Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseSetting("https_port", "8080");
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5001;
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "The API key to access API's",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement{
        { scheme, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});


builder.Services.AddScoped<EFCoreUsersRepository>();
builder.Services.AddScoped<EFCoreFuncTokenRepository>();
builder.Services.AddScoped<EFCoreFuncAuthHistory>();
builder.Services.AddScoped<EFCoreFuncTaskManagement>();
builder.Services.AddScoped<EFCoreFuncJWTRepository>();
builder.Services.AddScoped<ApiKeyAuthFilter>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();
app.UseRouting();
app.UseCors(myappOrigins);

//app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyAuthMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
