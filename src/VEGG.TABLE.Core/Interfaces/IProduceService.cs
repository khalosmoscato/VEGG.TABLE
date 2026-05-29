using VEGG.TABLE.Core.Entities;
namespace VEGG.TABLE.Core.Interfaces;

public interface IProduceService
{
    List<Produce> GetAllProduces();
    Produce? GetProduceById(int id);
}
