using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IProduceRepository
{
    List<ProduceDTO> GetAllProduces();
    ProduceDTO? GetProduceById(int id);
    ProduceDTO AddProduce(ProduceDTO produce);
    bool DeleteProduce(int id);
}
