using Logic.Models;

namespace Logic.Interfaces;

public interface IUserDB
{
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    List<User> GetAllUsers();
    User GetUserById(int userId);
    User GetUserByEmail(string email);
}