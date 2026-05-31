using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;

namespace VEGG.TABLE.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers() => _userRepository.GetAllUsers();
        public User? GetUserById(int id) => _userRepository.GetUserById(id);
        public User AddUser(UserDTO userDTO) => _userRepository.AddUser(userDTO);
        public User? UpdateUser(int id, UserDTO userDTO) => _userRepository.UpdateUser(id, userDTO);
        public bool DeleteUser(int id) => _userRepository.DeleteUser(id);
    }
}