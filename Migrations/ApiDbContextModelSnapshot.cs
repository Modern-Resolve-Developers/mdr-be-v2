﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using danj_backend.DB;

#nullable disable

namespace danj_backend.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("danj_backend.Model.Authentication_history", b =>
                {
                    b.Property<int>("authId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("authId"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("isValid")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("preserve_data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("savedAuth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("authId");

                    b.ToTable("authentication_history");
                });

            modelBuilder.Entity("danj_backend.Model.Customers", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerId"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("customerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isstatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("verified")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("customerId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("danj_backend.Model.FP", b =>
                {
                    b.Property<int>("fpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fpId"));

                    b.Property<DateTime>("currentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("expiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("isValid")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("sentCounter")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("verificationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fpId");

                    b.ToTable("fp_verifier");
                });

            modelBuilder.Entity("danj_backend.Model.JWTAuthentication", b =>
                {
                    b.Property<int>("jwtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("jwtId"));

                    b.Property<string>("isValid")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("jwtpassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jwtusername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("jwtId");

                    b.ToTable("jwt_authentication");
                });

            modelBuilder.Entity("danj_backend.Model.Jitser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isPrivate")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("roomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roomPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roomStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("roomUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("dg_jitser_meet");
                });

            modelBuilder.Entity("danj_backend.Model.JitsiJoinedPersons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("jitsi_joined");
                });

            modelBuilder.Entity("danj_backend.Model.MDR_Task_Management", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("assignee_userid")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reporter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subtask")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("taskCode")
                        .HasColumnType("int");

                    b.Property<string>("task_dept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("task_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("mdr_task_management");
                });

            modelBuilder.Entity("danj_backend.Model.ProductManagement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("IsUnderMaintenance")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("downPayment")
                        .HasColumnType("real");

                    b.Property<float>("installmentInterest")
                        .HasColumnType("real");

                    b.Property<string>("maintainedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("monthlyPayment")
                        .HasColumnType("real");

                    b.Property<int>("monthsToPay")
                        .HasColumnType("int");

                    b.Property<string>("productCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productFeatures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("productPrice")
                        .HasColumnType("real");

                    b.Property<string>("productStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("projectInstallment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectScale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("repositoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("repositoryZipUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("totalPayment")
                        .HasColumnType("real");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("product_management");
                });

            modelBuilder.Entity("danj_backend.Model.Product_Features_Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("product_features_category");
                });

            modelBuilder.Entity("danj_backend.Model.Settings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("dynamicDashboardEnabled")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("settingsType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("settings");
                });

            modelBuilder.Entity("danj_backend.Model.SystemGenerator", b =>
                {
                    b.Property<int>("genCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("genCodeId"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<Guid>("systemCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("genCodeId");

                    b.HasIndex("product_id");

                    b.ToTable("system_gen");
                });

            modelBuilder.Entity("danj_backend.Model.TokenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("token_model");
                });

            modelBuilder.Entity("danj_backend.Model.Tokenization", b =>
                {
                    b.Property<int>("tokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tokenId"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("isExpired")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("isValid")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("tokenId");

                    b.ToTable("tokenization");
                });

            modelBuilder.Entity("danj_backend.Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isstatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("verified")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("danj_backend.Model.SystemGenerator", b =>
                {
                    b.HasOne("danj_backend.Model.ProductManagement", "ProductManagement")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductManagement");
                });
#pragma warning restore 612, 618
        }
    }
}
