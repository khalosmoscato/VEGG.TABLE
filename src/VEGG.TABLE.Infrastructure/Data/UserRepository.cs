using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;

namespace VEGG.TABLE.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly DBContext _context;

    public UserRepository(DBContext context)
    {
        _context = context;
    }

    public List<User> GetAllUsers()
    {
        return _context.UserTable.ToList();
    }

    public User? GetUserById(int id)
    {
        return _context.UserTable.FirstOrDefault(x => x.Id == id);
    }

    public User AddUser(User user)
    {
        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User? UpdateUser(int id, User user)
    {
        var existing = _context.UserTable.FirstOrDefault(x => x.Id == id);
        if (existing == null) return null;
        existing.Name = user.Name;
        existing.Email = user.Email;
        existing.UserType = user.UserType;
        _context.SaveChanges();
        return existing;
    }

    public bool DeleteUser(int id)
    {
        var existing = _context.UserTable.FirstOrDefault(x => x.Id == id);
        if (existing == null) return false;
        _context.UserTable.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}