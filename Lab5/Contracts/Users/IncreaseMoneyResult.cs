namespace Contracts.Users;

public abstract record IncreaseMoneyResult
{
    private IncreaseMoneyResult() { }

    public sealed record Success : IncreaseMoneyResult;

    public sealed record Failed : IncreaseMoneyResult;
}