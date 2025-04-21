using CarAuctionMS.Entities;


namespace CarAuctionMS.Services
{
    public class AuctionService
    {
        private readonly IAuctionManager _auctionManager;

        public AuctionService(IAuctionManager auctionManager)
        {
            _auctionManager = auctionManager ?? throw new ArgumentNullException(nameof(auctionManager));
        }

        public void RunAuctionFlow(string vehicleId)
        {
            Console.WriteLine("\n--- Auction Lifecycle Demo ---");

            // Start auction for the vehicle
            _auctionManager.StartAuction(vehicleId);

            // Place bids
            _auctionManager.PlaceBid(vehicleId, new Bid("Alice", 36000));
            _auctionManager.PlaceBid(vehicleId, new Bid("Bob", 37000));

            // Close the auction
            _auctionManager.CloseAuction(vehicleId);

            Console.WriteLine("--- Auction completed ---");
        }
    }
}
