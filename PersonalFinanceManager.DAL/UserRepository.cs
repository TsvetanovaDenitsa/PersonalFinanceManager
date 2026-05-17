
using Microsoft.Data.SqlClient;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL;

public class UserRepository
{
    private readonly DatabaseManager _db;

    public UserRepository(DatabaseManager db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public bool AddUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        const string sql = @"
INSERT INTO Users
(
    Username,
    Email,
    PasswordHash,
    FirstName,
    LastName
)
VALUES
(
    @Username,
    @Email,
    @PasswordHash,
    @FirstName,
    @LastName
)";

        try
        {
            using SqlConnection connection =
                _db.GetConnection();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Username",
                user.Username);

            command.Parameters.AddWithValue(
                "@Email",
                user.Email);

            command.Parameters.AddWithValue(
                "@PasswordHash",
                user.PasswordHash);

            command.Parameters.AddWithValue(
                "@FirstName",
                string.IsNullOrWhiteSpace(user.FirstName)
                    ? DBNull.Value
                    : user.FirstName);

            command.Parameters.AddWithValue(
                "@LastName",
                string.IsNullOrWhiteSpace(user.LastName)
                    ? DBNull.Value
                    : user.LastName);

            connection.Open();

            int affectedRows =
                command.ExecuteNonQuery();

            return affectedRows > 0;
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException(
                "Database error while adding user.",
                ex);
        }
    }

    public bool ValidateLogin(
        string username,
        string password)
    {
        const string sql = @"
SELECT COUNT(*)
FROM Users
WHERE Username = @Username
AND PasswordHash = @PasswordHash";

        try
        {
            using SqlConnection connection =
                _db.GetConnection();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Username",
                username);

            command.Parameters.AddWithValue(
                "@PasswordHash",
                password);

            connection.Open();

            int count =
                Convert.ToInt32(
                    command.ExecuteScalar());

            return count > 0;
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException(
                "Database error while validating login.",
                ex);
        }
    }

    public bool UserExistsByUsername(string username)
    {
        const string sql = @"
SELECT COUNT(*)
FROM Users
WHERE Username = @Username";

        try
        {
            using SqlConnection connection =
                _db.GetConnection();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Username",
                username);

            connection.Open();

            int count =
                Convert.ToInt32(
                    command.ExecuteScalar());

            return count > 0;
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException(
                "Database error while checking username.",
                ex);
        }
    }

    public bool UserExistsByEmail(string email)
    {
        const string sql = @"
SELECT COUNT(*)
FROM Users
WHERE Email = @Email";

        try
        {
            using SqlConnection connection =
                _db.GetConnection();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Email",
                email);

            connection.Open();

            int count =
                Convert.ToInt32(
                    command.ExecuteScalar());

            return count > 0;
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException(
                "Database error while checking email.",
                ex);
        }
    }

    public User? GetUserByUsername(string username)
    {
        const string sql = @"
SELECT
    Id,
    Username,
    Email,
    PasswordHash,
    FirstName,
    LastName
FROM Users
WHERE Username = @Username";

        try
        {
            using SqlConnection connection =
                _db.GetConnection();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Username",
                username);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return MapReaderToUser(reader);
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException(
                "Database error while retrieving user.",
                ex);
        }
    }

    private static User MapReaderToUser(
        SqlDataReader reader)
    {
        return new User
        {
            Id = reader.GetInt32(
                reader.GetOrdinal("Id")),

            Username = reader.GetString(
                reader.GetOrdinal("Username")),

            Email = reader.GetString(
                reader.GetOrdinal("Email")),

            PasswordHash = reader.GetString(
                reader.GetOrdinal("PasswordHash")),

            FirstName = reader.IsDBNull(
                reader.GetOrdinal("FirstName"))
                    ? string.Empty
                    : reader.GetString(
                        reader.GetOrdinal("FirstName")),

            LastName = reader.IsDBNull(
                reader.GetOrdinal("LastName"))
                    ? string.Empty
                    : reader.GetString(
                        reader.GetOrdinal("LastName"))
        };
    }



}
