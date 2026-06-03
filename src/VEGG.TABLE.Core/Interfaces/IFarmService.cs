using System;
using System.Collections.Generic;
using System.Text;

using VEGG.TABLE.Core.Entities;

namespace VEGG.TABLE.Core.Interfaces;

public interface IFarmService
{
    Task<IEnumerable<Farm>> GetFarms();
}
