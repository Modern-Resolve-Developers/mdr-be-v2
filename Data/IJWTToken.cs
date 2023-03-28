namespace danj_backend.Data;

public interface IJWTToken
{
     int jwtId { get; set; }
     string jwtusername { get; set; }
     string jwtpassword { get; set; }
     char isValid { get; set; }
}