using Abstractions.Repositories;
using Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString =
        "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

    public async Task<User?> FindByUsername(string username)
    {
        Console.WriteLine("hello from findBy");
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = """
                           SELECT user_id, user_name, user_password, user_balance
                           FROM UserBank
                           WHERE user_name = :username
                           """;
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("username", username);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            long userId = reader.GetInt64(0);
            string userName = reader.GetString(1);
            string userPassword = reader.GetString(2);

            // Создаем объект UserBalance и устанавливаем начальный баланс
            var balance = new UserBalance(reader.GetInt64(3));

            // Создаем объект User с использованием UserBalance
            return new User(userId, userName, userPassword, balance);
        }

        return null;
    }

    public async Task<RegistrationResult> AddUser(User user)
    {
        user = user ?? throw new ArgumentNullException(nameof(user));
        User? existingUser = await FindByUsername(user.Username);
        if (existingUser != null)
        {
            Console.WriteLine("names collision");
            return new RegistrationResult.CollisionUsernames();
        }

        User? existingUserWithSamePassword = await FindByPassword(user.Password);
        if (existingUserWithSamePassword != null)
        {
            Console.WriteLine("passwords collision");
            return new RegistrationResult.CollisionPasswords();
        }

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = """
                           INSERT INTO UserBank (user_name, user_password, user_balance)
                           VALUES (:username, :user_password, 0)
                           """;

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("username", user.Username);
        command.Parameters.AddWithValue("user_password", user.Password);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0
            ? new RegistrationResult.SuccessRegistration()
            : new RegistrationResult.FailureRegistration();
    }

    public async Task<long> GetBalance(string username)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = """
                           SELECT user_balance
                           FROM UserBank
                           WHERE user_name = :username;
                           """;

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("username", username);

        object? result = await command.ExecuteScalarAsync();

        return result != null ? Convert.ToInt64(result, System.Globalization.CultureInfo.InvariantCulture) : 0;
    }

    public async Task<DecreaseMoneyResult> CashWithdrawal(string username, long amount)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        long currentBalance = await GetBalance(username);

        if (currentBalance < amount)
        {
            return new DecreaseMoneyResult.Failed();
        }

        const string withdrawalSql = """
                                     UPDATE UserBank
                                     SET user_balance = user_balance - :amount
                                     WHERE user_name = :username;
                                     """;

        using var withdrawalCommand = new NpgsqlCommand(withdrawalSql, connection);
        withdrawalCommand.Parameters.AddWithValue("amount", amount);
        withdrawalCommand.Parameters.AddWithValue("username", username);

        int rowsAffected = await withdrawalCommand.ExecuteNonQueryAsync();

        if (rowsAffected > 0)
        {
            return new DecreaseMoneyResult.Success();
        }
        else
        {
            return new DecreaseMoneyResult.Failed();
        }
    }

    public async Task<IncreaseMoneyResult> AddingMoney(string username, long amount)
    {
        if (amount <= 0)
        {
            return new IncreaseMoneyResult.Failed();
        }

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = """
                           UPDATE UserBank
                           SET user_balance = user_balance + :amount
                           WHERE user_name = :username
                           ;
                           """;

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("username", username);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0 ? new IncreaseMoneyResult.Success() : new IncreaseMoneyResult.Failed();
    }

    public async Task<User?> SignIn(string username, string password)
    {
        User? existingUser = await FindByUsername(username);

        if (existingUser != null && existingUser.Password == password)
        {
            return existingUser;
        }

        return null;
    }

    private async Task<User?> FindByPassword(string password)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = """
                               SELECT user_id, user_name, user_password, user_balance
                               FROM UserBank
                               WHERE user_password = :user_password
                           """;
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("user_password", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            long userId = reader.GetInt64(0);
            string username = reader.GetString(1);
            string userPassword = reader.GetString(2);

            var balance = new UserBalance(reader.GetInt64(3));

            return new User(userId, username, userPassword, balance);
        }

        return null;
    }
}
