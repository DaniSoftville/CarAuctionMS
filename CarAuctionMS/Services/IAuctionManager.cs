using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public interface IAuctionManager
    {
        void StartAuction(string vehicleId);
        void CloseAuction(string vehicleId);
        void PlaceBid(string vehicleId, Bid bid);
        Auction? GetAuction(string vehicleId);
    }
}