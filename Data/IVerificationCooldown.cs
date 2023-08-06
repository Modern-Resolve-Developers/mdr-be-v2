namespace danj_backend.Data;

public interface IVerificationCooldown
{
    int id { get; set; }
    int resendCount { get; set; }
    long cooldown { get; set; }
}