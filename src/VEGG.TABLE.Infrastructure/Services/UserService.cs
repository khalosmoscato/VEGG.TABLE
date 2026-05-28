using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;
using VEGG.TABLE.Infrastructure.Data;
namespace VEGG.TABLE.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext _context;
        public UserService(DBContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.UserTable.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.UserTable.Find(id);
        }

        public User AddUser(User user)
        {
            _context.UserTable.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? UpdateUser(int id, User user)
        {
            var existingUser = _context.UserTable.Find(id);
            if (existingUser == null) return null;
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            _context.SaveChanges();
            return existingUser;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.UserTable.Find(id);
            if (user == null) return false;
            _context.UserTable.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}