using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.Infrastructure.Data;

public interface IFarmRepository
{
    Task<List<Farm>> GetAllFarms();
    Task<Farm> GetFarmById(int id);
    Task AddFarm(Farm farm);
    Task UpdateFarm(Farm farm);
    Task DeleteFarm(int id);
}
internal class FarmRepository : IFarmRepository
{
    private readonly string path = "farms.json";
    public async Task<List<Farm>> GetAllFarms()
    {
        return await Utils.DeserializeFromFileAsync<List<Farm>>(path);
    }
    public async Task<Farm> GetFarmById(int id)
    {
        var farms = await GetAllFarms();
        return farms?.Find(f => f.Id == id);
    }
    public async Task AddFarm(Farm farm)
    {
        var farms = await GetAllFarms() ?? new List<Farm>();
        farm.Id = farms.Count > 0 ? farms[^1].Id + 1 : 1;
        farms.Add(farm);
        await Utils.SerializeObjectsToFileAsync(farms, path);
    }
    public async Task UpdateFarm(Farm farm)
    {
        var farms = await GetAllFarms();
        if (farms == null) return;
        var index = farms.FindIndex(f => f.Id == farm.Id);
        if (index == -1) return;
        farms[index] = farm;
        await Utils.SerializeObjectsToFileAsync(farms, path);
    }
    public async Task DeleteFarm(int id)
    {
        var farms = await GetAllFarms();
        if (farms == null) return;
        farms.RemoveAll(f => f.Id == id);
        await Utils.SerializeObjectsToFileAsync(farms, path);
    }
}
