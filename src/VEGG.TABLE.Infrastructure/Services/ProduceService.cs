using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;

namespace VEGG.TABLE.Infrastructure.Services
{
    public class ProduceService : IProduceService
    {
        private readonly IProduceRepository _produceRepository;

        public ProduceService(IProduceRepository produceRepository)
        {
            _produceRepository = produceRepository;
        }

        public List<Produce> GetAllProduces() => _produceRepository.GetAllProduces();
        public Produce? GetProduceById(int id) => _produceRepository.GetProduceById(id);
        public List<Produce>? GetProduceByUserId(int userId) => _produceRepository.GetProduceByUserId(userId);
        public List<Produce>? GetProduceByUserIdAll(int userId) => _produceRepository.GetProduceByUserIdAll(userId);
        public List<Produce>? GetAllProduceOnSale() => _produceRepository.GetAllProduceOnSale();
        public Produce AddProduce(CreateProduceDTO produceDTO) => _produceRepository.AddProduce(produceDTO);
        public Produce UpdateProduce(int id, ProduceDTO produceDTO) => _produceRepository.UpdateProduce(id, produceDTO);
        public bool DeleteProduce(int id) => _produceRepository.DeleteProduce(id);
    }
}