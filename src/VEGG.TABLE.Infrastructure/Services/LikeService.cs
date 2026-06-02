using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;

namespace VEGG.TABLE.Infrastructure.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public UserProduceLike? AddLike(int userId, int produceId) => _likeRepository.AddLike(userId, produceId);
        public bool RemoveLike(int userId, int produceId) => _likeRepository.RemoveLike(userId, produceId);
        public List<UserProduceLike> GetLikesByUser(int userId) => _likeRepository.GetLikesByUser(userId);
    }
}