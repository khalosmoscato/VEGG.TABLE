using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User AddUser(User user);
        User? UpdateUser(int id, User user);
        bool DeleteUser(int id);
    }
}