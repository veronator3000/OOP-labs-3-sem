namespace Models.Transactions;

public record TransactionHistory(long Id, TransactionType TypeOfTransaction, long BalanceAmount);