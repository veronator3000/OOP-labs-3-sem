using Abstractions.Repositories;
using Models.Transactions;
using Npgsql;

namespace DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly string _connectionString
        = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

    public async Task<IList<TransactionHistory>> GetTransactionHistory(long userId)
    {
        const string sql = """
                SELECT user_id, transaction_type, balance_amount
                FROM Transaction
                WHERE user_id = :user_id
                """;

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("user_id", userId);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var transactionHistories = new List<TransactionHistory>();

        while (await reader.ReadAsync())
        {
            long user_id = reader.GetInt64(reader.GetOrdinal("user_id"));
            TransactionType transactionType = Enum.Parse<TransactionType>(reader.GetString(reader.GetOrdinal("transaction_type")));
            long balanceAmount = reader.GetInt64(reader.GetOrdinal("balance_amount"));
            var historyTransaction = new TransactionHistory(user_id, transactionType, balanceAmount);
            transactionHistories.Add(historyTransaction);
        }

        return transactionHistories;
    }

    public async Task<IList<TransactionHistory>> GetAllTransaction()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        const string sql = """
                SELECT user_id, transaction_type, balance_amount
                FROM Transaction
                ORDER BY user_id
                """;

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var transactionHistories = new List<TransactionHistory>();

        while (await reader.ReadAsync())
        {
            long user_id = reader.GetInt64(reader.GetOrdinal("user_id"));
            TransactionType transactionType = Enum.Parse<TransactionType>(reader.GetString(reader.GetOrdinal("transaction_type")));
            long balanceAmount = reader.GetInt64(reader.GetOrdinal("balance_amount"));

            var historyTransaction = new TransactionHistory(user_id, transactionType, balanceAmount);
            transactionHistories.Add(historyTransaction);
        }

        return transactionHistories;
    }

    public async Task UpdateTransactionIncreaseMoney(long id, TransactionType transactionType, long amount)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        const string sql = """
                INSERT INTO Transaction (user_id, transaction_type, balance_amount)
                VALUES (:user_id, 'IncreaseInvoiceAmount', :amount);
                """;

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("user_id", id);
        command.Parameters.AddWithValue("amount", amount);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateTransactionCashWithdrawal(long id, TransactionType transactionType, long amount)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        const string sql = """
                           INSERT INTO Transaction (user_id, transaction_type, balance_amount)
                           VALUES (:user_id, 'CashWithdrawal', :amount);
                           """;

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("user_id", id);
        command.Parameters.AddWithValue("amount", amount);
        await command.ExecuteNonQueryAsync();
    }
}