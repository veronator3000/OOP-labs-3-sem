using Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Administrators;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly string _connectionString
        = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

    public async Task<Administrator?> GetAccess(string password)
    {
        const string sql = """
                           SELECT admin_id, admin_password
                            FROM Admins
                           WHERE admin_password = :password
""";

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("password", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            long adminId = reader.GetInt64(reader.GetOrdinal("admin_id"));
            return new Administrator(reader.GetString(reader.GetOrdinal("admin_password")), adminId);
        }

        return null;
    }
}