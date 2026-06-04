using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.Infrastructure.Data;

public class FarmRepository : IFarmRepository
{
    private readonly DBContext _context;
    public FarmRepository(DBContext context) => _context = context;

    public async Task<IEnumerable<FarmDTO>> GetFarms()
    {
        return await _context.Farms
            .Select(f => new FarmDTO
            {
                Id = f.Id,
                Name = f.Name,
                Lat = f.Lat,
                Lng = f.Lng,
                OwnerName = f.Owner != null ? f.Owner.Name : "Unknown",
                OwnerEmail = f.Owner != null ? f.Owner.Email : "No email available"
            })
            .ToListAsync();
    }
}