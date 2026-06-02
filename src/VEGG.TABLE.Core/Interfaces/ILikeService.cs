using VEGG.TABLE.Core.Entities;

namespace VEGG.TABLE.Core.Interfaces;

public interface ILikeService
{
    UserProduceLike? AddLike(int userId, int produceId);
    bool RemoveLike(int userId, int produceId);
    List<UserProduceLike> GetLikesByUser(int userId);
}
