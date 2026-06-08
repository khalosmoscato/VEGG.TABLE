using System;
using System.Collections.Generic;
using System.Text;

using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Entities.DTOs;

namespace VEGG.TABLE.Core.Interfaces;

public interface IFarmService
{
    Task<IEnumerable<FarmDTO>> GetFarms();
}