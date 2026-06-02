using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;

namespace VEGG.TABLE.Infrastructure.Data;

public class LikeRepository : ILikeRepository
{
    private readonly DBContext _context;

    public LikeRepository(DBContext context)
    {
        _context = context;
    }

    public UserProduceLike? AddLike(int userId, int produceId)
    {
        var existing = _context.LikedTable.Find(userId, produceId);
        if (existing != null) return existing;

        var like = new UserProduceLike
        {
            UserId = userId,
            User = null!,
            ProduceId = produceId,
            Produce = null!
        };

        _context.LikedTable.Add(like);
        _context.SaveChanges();
        return like;
    }

    public bool RemoveLike(int userId, int produceId)
    {
        var like = _context.LikedTable.Find(userId, produceId);
        if (like == null) return false;

        _context.LikedTable.Remove(like);
        _context.SaveChanges();
        return true;
    }

    public List<UserProduceLike> GetLikesByUser(int userId)
    {
        return _context.LikedTable
            .Where(l => l.UserId == userId)
            .ToList();
    }
}
