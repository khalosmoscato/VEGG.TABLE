namespace VEGG.TABLE.Core.Entities;

public class UserProduceLike
    {
        public required int UserId { get; set; }
        public required User User { get; set; }

        public required int ProduceId { get; set; }
        public required Produce Produce { get; set; }

        public DateTime LikedAt { get; set; } = DateTime.UtcNow;
    }
