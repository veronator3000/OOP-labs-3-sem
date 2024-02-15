namespace Contracts.Users;

public abstract record RegistrationResult
{
    private RegistrationResult() { }

    public sealed record SuccessRegistration : RegistrationResult;
    public sealed record FailureRegistration : RegistrationResult;
    public sealed record CollisionUsernames : RegistrationResult;
    public sealed record CollisionPasswords : RegistrationResult;
}