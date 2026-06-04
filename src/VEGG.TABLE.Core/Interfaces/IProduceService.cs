using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IProduceService
{
    List<Produce> GetAllProduces();
    Produce? GetProduceById(int id);
    List<Produce>? GetProduceByUserId(int userId);
    List<Produce>? GetProduceByUserIdAll(int userId);
    List<Produce>? GetAllProduceOnSale();
    Produce AddProduce(ProduceDTO produceDTO);
    bool DeleteProduce(int id);
}