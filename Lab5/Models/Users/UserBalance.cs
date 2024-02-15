namespace Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

public class UserBalance
{
    public UserBalance(long initialBalance)
    {
        Balance = initialBalance;
    }

    public long Balance { get; private set; }

    public void UpdateBalance(long amount)
    {
        Balance += amount;
    }
}