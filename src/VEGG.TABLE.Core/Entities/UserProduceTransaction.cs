namespace VEGG.TABLE.Core.Entities;
public class UserProduceTransaction
    {
        public required int BuyerId { get; set; }
        public required User Buyer { get; set; }

        public required int SellerId { get; set; }
        public required User Seller { get; set; }


        public required int ProduceId { get; set; }
        public required Produce Produce { get; set; }

        public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
    }

