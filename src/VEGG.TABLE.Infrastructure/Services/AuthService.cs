using System;
using System.Collections.Generic;
using System.Text;

using VEGG.TABLE.Core.Entities.DTOs;

namespace VEGG.TABLE.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public UserResponseDTO? Authenticate(string email, string password)
    {
        var user = _userRepository.GetByEmail(email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;

        return new UserResponseDTO
        {
            Email = user.Email,
            Name = user.Name,
            UserType = user.UserType
        };
    }
}
