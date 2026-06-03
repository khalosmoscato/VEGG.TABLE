using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.Infrastructure.Data;

public class FarmRepository : IFarmRepository
{
    private readonly DBContext _context;
    public FarmRepository(DBContext context) => _context = context;

    public async Task<IEnumerable<Farm>> GetFarms()
    {
        return await _context.Farms.ToListAsync();
    }
}