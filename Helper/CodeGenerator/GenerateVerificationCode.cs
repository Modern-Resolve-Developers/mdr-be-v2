namespace danj_backend.Helper.CodeGenerator;

public class GenerateVerificationCode
{
    private const int CodeLength = 6;
    private const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string GenerateCode()
    {
        var random = new Random();
        var code = "";
        for (int i = 0; i < CodeLength; i++)
        {
            var index = random.Next(0, AllowedChars.Length);
            code += AllowedChars[index];
        }
        return code;
    }
}