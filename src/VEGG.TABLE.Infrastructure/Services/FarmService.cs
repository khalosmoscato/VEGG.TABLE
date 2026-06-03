using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.Infrastructure.Services;

public class FarmService : IFarmService
{
    private readonly IFarmRepository _repository;

    public FarmService(IFarmRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Farm>> GetFarms()
    {
        return await _repository.GetAllFarmsAsync();
    }
}
