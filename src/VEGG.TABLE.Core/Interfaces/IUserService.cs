using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IUserService
{
    List<User> GetAllUsers();
    User? GetUserById(int id);
    User AddUser(UserDTO userDTO);
    User? UpdateUser(int id, User user);
    bool DeleteUser(int id);
}