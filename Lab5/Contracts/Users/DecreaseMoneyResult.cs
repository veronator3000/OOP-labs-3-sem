namespace Contracts.Users;

public abstract record DecreaseMoneyResult
{
    private DecreaseMoneyResult() { }

    public sealed record Success : DecreaseMoneyResult;

    public sealed record Failed : DecreaseMoneyResult;
}
