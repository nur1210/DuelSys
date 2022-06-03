using Logic.Models;

namespace Logic.Interfaces;

public interface IUserDB
{
    void AddUser(User user, string hashPassword);
    void UpdateUser(User user);
    void UpdateUser(User user, string hashPassword);
    void DeleteUser(User user);
    List<User> GetAllUsers();
    User GetUserById(int userId);
    User GetUserByEmail(string email);
    void RegisterUserToTournament(int userId, int tournamentId);
    Dictionary<int, string> GetAllUsersIdAndFullName();
    List<string> GetAllRegisteredTournamentsNamesPerUser(int userId);
    DateTime GetUpcomingMatchDate(int userId);
    List<Tournament> GetAllTournamentsPerUser(int userId);
}