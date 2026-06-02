using VEGG.TABLE.Core.Entities;

namespace VEGG.TABLE.Core.Interfaces;

public interface ILikeRepository
{
    UserProduceLike? AddLike(int userId, int produceId);
    bool RemoveLike(int userId, int produceId);
    List<UserProduceLike> GetLikesByUser(int userId);
}
