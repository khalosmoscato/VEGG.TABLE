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

        public List<ProduceDTO> GetAllProduces() => _produceRepository.GetAllProduces();
        public ProduceDTO? GetProduceById(int id) => _produceRepository.GetProduceById(id);
        public ProduceDTO AddProduce(ProduceDTO produce) => _produceRepository.AddProduce(produce);
        public bool DeleteProduce(int id) => _produceRepository.DeleteProduce(id);
    }
}
