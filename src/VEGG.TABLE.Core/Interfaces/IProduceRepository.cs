using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IProduceRepository
{
    List<Produce> GetAllProduces();
    Produce? GetProduceById(int id);
    Produce AddProduce(Produce produce);
    bool DeleteProduce(int id);
}