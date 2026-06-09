using VEGG.TABLE.Client.Resources;
using VEGG.TABLE.Core.Entities;

namespace VEGG.TABLE.Client.Services;

public class produceLoader
{
    private List<Produce>? produces;

    private const bool UseMockData = true;

    private readonly IHttpClientFactory _clientFactory;

    public produceLoader(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<List<Produce>?> GetTheProduceAsync()
    {
        if (UseMockData)
        {
            produces = DummyProduce._DummyProduceList;
            Console.WriteLine($"Produces null? {produces == null}");
            Console.WriteLine($"Count: {produces?.Count}");
        }
        else
        {
            var http = _clientFactory.CreateClient("PublicAPI");

            produces = await http.GetFromJsonAsync<List<Produce>>(
                "api/produce");
        }
        return produces;
    }

    public async Task<List<Produce>?> GetTheUsersProduceAsync(int id)
    {
        if (UseMockData)
        {
            produces = DummyProduce._DummyProduceList;
            Console.WriteLine($"Produces null? {produces == null}");
            Console.WriteLine($"Count: {produces?.Count}");
        }
        else
        {
            var http = _clientFactory.CreateClient("PublicAPI");

            produces = await http.GetFromJsonAsync<List<Produce>>(
                "api/produce/seller/all/{id}");
        }
        return produces;
    }
}