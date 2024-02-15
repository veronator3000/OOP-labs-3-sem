namespace Contracts.Users;

public abstract record LoginResult
{
    private LoginResult() { }
    public sealed record UserSuccess : LoginResult;
    public sealed record AdminSuccess : LoginResult;
    public sealed record AdminNotFound : LoginResult;
    public sealed record UserNotFound : LoginResult;
}