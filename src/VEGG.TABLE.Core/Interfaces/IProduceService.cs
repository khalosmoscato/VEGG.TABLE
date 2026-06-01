using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IProduceService
{
    List<ProduceDTO> GetAllProduces();
    ProduceDTO? GetProduceById(int id);
    ProduceDTO AddProduce(ProduceDTO produce);
    bool DeleteProduce(int id);
}
