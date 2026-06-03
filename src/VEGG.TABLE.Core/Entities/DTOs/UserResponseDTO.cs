using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.Core.Entities.DTOs;

public class UserResponseDTO
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public UserType UserType { get; set; } = UserType.Buyer;
    public string Token { get; set; } = string.Empty;
}