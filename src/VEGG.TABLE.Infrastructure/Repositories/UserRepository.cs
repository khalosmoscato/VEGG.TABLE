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
       

        User user = new User
        {
            //Id is automatically set by DB
            Email = userDTO.Email,
            Name = userDTO.Name,
            Password = userDTO.Password,
            UserType = UserType.Buyer,
        };

        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User? UpdateUser(int id, UserDTO userDTO)
    {
        var existing = _context.UserTable.FirstOrDefault(x => x.Id == id);
        if (existing == null) return null;

        if (userDTO.Name != null && userDTO.Name != existing.Name)
        {
            existing.Name = userDTO.Name;
        }

        if (userDTO.Email != null && userDTO.Email != existing.Email)
        {
            existing.Email = userDTO.Email;
        }

        //if (userDTO.UserType != existing.UserType)
        //{
        //    existing.UserType = userDTO.UserType;
        //}

        _context.SaveChanges();
        return existing;
    }

    public User? UpdateUserName(int id, string name)
    {
        var existing = _context.UserTable.FirstOrDefault(x => x.Id == id);
        if (existing == null) return null;
        existing.Name = name;
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
    public User? GetByEmail(string email)
        => _context.UserTable.FirstOrDefault(u => u.Email == email.ToLower());
}