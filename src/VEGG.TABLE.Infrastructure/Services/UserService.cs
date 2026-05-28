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
        public User AddUser(User user) => _userRepository.AddUser(user);
        public User? UpdateUser(int id, User user) => _userRepository.UpdateUser(id, user);
        public bool DeleteUser(int id) => _userRepository.DeleteUser(id);
    }
}