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

    public User AddUser(UserDTO userDTO)
    {
        int currentMaxId = _context.UserTable.Any()
        ? _context.UserTable.Max(x => x.Id)
        : 0;

        int newId = currentMaxId + 1;

        User user = new User
        { 
            Id = newId,
            Email = userDTO.Email,
            Name = userDTO.Name,
            Password = userDTO.Password,
            UserType = userDTO.UserType,
        };

        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User? UpdateUser(int id, UserDTO userDTO)
    {
        var existing = _context.UserTable.FirstOrDefault(x => x.Id == id);
        if (existing == null) return null;
        existing.Name = userDTO.Name;
        existing.Email = userDTO.Email;
        existing.UserType = userDTO.UserType;
        _context.SaveChanges();
        return existing;
    }

    public (bool, List<User>) DeleteUser(int id)
    {
        var existing = _context.UserTable.FirstOrDefault(x => x.Id == id);
        if (existing == null) 
        { return (false, _context.UserTable.ToList()); }
        _context.UserTable.Remove(existing);
        _context.SaveChanges();
        var currentUsers = _context.UserTable.ToList();
        return (true, currentUsers);
    }
}