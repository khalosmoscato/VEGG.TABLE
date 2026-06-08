using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using VEGG.TABLE.Core.Entities.DTOs;

namespace VEGG.TABLE.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    public UserResponseDTO? Authenticate(string email, string password)
    {
        var user = _userRepository.GetByEmail(email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;

        var token = GenerateJwtToken(user);

        return new UserResponseDTO
        {
            Email = user.Email,
            Name = user.Name,
            UserType = user.UserType,
            Token = token
        };
    }

    private string GenerateJwtToken(User user)
    {
        // 1. Get the raw string first
        var keyString = _configuration["Jwt:Key"];

        // 2. Log it to check what is actually being loaded
        Console.WriteLine($"DEBUG: JWT Key used for signing is: {keyString}");

        // 3. Define the key variable only once
        var key = Encoding.UTF8.GetBytes(keyString!);

        var claims = new[] {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.UserType.ToString())
    };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            // 4. Use the single 'key' variable defined above
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}