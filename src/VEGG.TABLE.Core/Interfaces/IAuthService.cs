using System;
using System.Collections.Generic;
using System.Text;

using VEGG.TABLE.Core.Entities.DTOs;

namespace VEGG.TABLE.Core.Interfaces;

public interface IAuthService
{
    UserResponseDTO? Authenticate(string email, string password);
}
