using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IProduceRepository
{
    List<Produce> GetAllProduces();
    Produce? GetProduceById(int id);
    List<Produce>? GetProduceByUserId(int userId);
    List<Produce>? GetProduceByUserIdAll(int userId);
    Produce AddProduce(Produce produce);
    bool DeleteProduce(int id);
}