using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User AddUser(UserDTO userDTO);
        User? UpdateUser(int id, UserDTO userDTO);
        (bool, List<User>) DeleteUser(int id);
        public User? GetByEmail(string email);
    }
}