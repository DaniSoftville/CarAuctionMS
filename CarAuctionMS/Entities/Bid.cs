using System;

namespace CarAuctionMS.Entities
{
    public class Bid
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;

        public Bid(string bidder, int amount)
        {
            Bidder = bidder;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Bidder} bid {Amount} at {PlacedAt:u}";
        }
    }
}

