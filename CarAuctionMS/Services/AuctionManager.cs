using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public class VehicleAuctionManager : IAuctionManager
    {
        private readonly IVehicleManager _vehicleManager;
        private readonly Dictionary<Guid, Auction> _activeAuctions;

        public VehicleAuctionManager(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager ?? throw new ArgumentNullException(nameof(vehicleManager));
            _activeAuctions = new Dictionary<Guid, Auction>();
        }

        public void StartAuction(string vehicleId)
        {
            if (!Guid.TryParse(vehicleId, out Guid parsedId))
                throw new ArgumentException("Invalid vehicle ID format.");

            var vehicle = _vehicleManager.GetAllVehicles().FirstOrDefault(v => v.Id == parsedId)
                          ?? throw new InvalidOperationException("Vehicle does not exist in the inventory.");

            // Check if the auction is already active for this vehicle
            if (_activeAuctions.ContainsKey(vehicle.Id))
                throw new InvalidOperationException($"Auction for {vehicle.Model} is already active.");

            // Start a new auction
            var auction = new Auction(vehicle, vehicle.StartingBid);
            auction.StartAuction();
            _activeAuctions[vehicle.Id] = auction;

            Console.WriteLine($"Auction started for {vehicle.Model} with starting bid {vehicle.StartingBid}.");
        }


        public void CloseAuction(string vehicleId)
        {
            if (!Guid.TryParse(vehicleId, out Guid parsedId))
                throw new ArgumentException("Invalid vehicle ID format.");

            if (!_activeAuctions.TryGetValue(parsedId, out var auction))
            {
                // Add a log for better debugging
                Console.WriteLine($"Error: Auction not found for vehicle ID {vehicleId}.");
                throw new InvalidOperationException("Auction not found or already closed for this vehicle.");
            }

            // Close the auction
            auction.CloseAuction();
            _activeAuctions.Remove(parsedId);

            Console.WriteLine($"Auction closed for {auction.Vehicle.Model}. Winning bid: {auction.WinningBidAmount} by {auction.WinningBidder}.");
        }
        public void PlaceBid(string vehicleId, Bid bid)
        {
            if (!Guid.TryParse(vehicleId, out Guid parsedId))
                throw new ArgumentException("Invalid vehicle ID format.");

            if (!_activeAuctions.TryGetValue(parsedId, out var auction))
                throw new InvalidOperationException("Auction not found or closed for this vehicle.");

            var currentBid = auction.Bids.Count > 0 ? auction.Bids.Last().Amount : auction.Vehicle.StartingBid;
            if (bid.Amount <= currentBid)
                throw new InvalidOperationException("Bid amount must be higher than the current highest bid.");

            auction.PlaceBid(bid);

            Console.WriteLine($"{bid.Bidder} placed a bid of {bid.Amount} on {auction.Vehicle.Model}.");
        }

        public Auction? GetAuction(string vehicleId)
        {
            if (!Guid.TryParse(vehicleId, out Guid parsedId))
                throw new ArgumentException("Invalid vehicle ID format.");

            _activeAuctions.TryGetValue(parsedId, out var auction);
            return auction;
        }
    }
}
