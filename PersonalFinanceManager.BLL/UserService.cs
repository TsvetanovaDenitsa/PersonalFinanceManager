
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService()
    {
        DatabaseManager databaseManager = new DatabaseManager();

        _userRepository = new UserRepository(databaseManager);
    }

    public bool RegisterUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        ValidateUser(user);

        bool usernameExists =
            _userRepository.UserExistsByUsername(user.Username);

        if (usernameExists)
        {
            throw new Exception("Username already exists.");
        }

        bool emailExists =
            _userRepository.UserExistsByEmail(user.Email);

        if (emailExists)
        {
            throw new Exception("Email already exists.");
        }

        return _userRepository.AddUser(user);
    }

    public bool LoginUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new Exception("Username is required.");
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Password is required.");
        }

        return _userRepository.ValidateLogin(username, password);
    }

    private void ValidateUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Username))
        {
            throw new Exception("Username is required.");
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            throw new Exception("Email is required.");
        }

        if (string.IsNullOrWhiteSpace(user.PasswordHash))
        {
            throw new Exception("Password is required.");
        }

        if (user.PasswordHash.Length < 6)
        {
            throw new Exception("Password must be at least 6 characters.");
        }

        if (!user.Email.Contains("@"))
        {
            throw new Exception("Invalid email.");
        }
    }
}