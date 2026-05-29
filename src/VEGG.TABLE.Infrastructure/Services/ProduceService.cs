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
    }
}
