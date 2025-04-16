using System;
using System.Collections.Generic;
using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public class AuctionManager
    {
        private readonly VehicleManager _vehicleManager;
        private readonly Dictionary<Guid, Auction> _activeAuctions;

        public AuctionManager(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
            _activeAuctions = new Dictionary<Guid, Auction>();
        }

        // Start an auction for a vehicle
        public void StartAuction(Vehicle vehicle)
        {
            if (_activeAuctions.ContainsKey(vehicle.Id))
                throw new InvalidOperationException($"Auction for {vehicle.Model} is already active.");

            // ✅ MODIFIED: Pass both vehicle and vehicle.StartingBid to match Auction constructor
            var auction = new Auction(vehicle, vehicle.StartingBid);

            auction.StartAuction(); // Start the auction
            _activeAuctions[vehicle.Id] = auction;

            Console.WriteLine($"Auction started for {vehicle.Model} with starting bid {vehicle.StartingBid}.");
        }

        // Place a bid on an active auction
        public void PlaceBid(Vehicle vehicle, int bidAmount, string bidder)
        {
            if (!_activeAuctions.TryGetValue(vehicle.Id, out var auction))
                throw new InvalidOperationException("Auction not found or closed for this vehicle.");

            // Check if the bid amount is greater than the current highest bid or the vehicle's starting bid
            if (bidAmount <= (auction.Bids.Count > 0 ? auction.Bids.Last().Amount : vehicle.StartingBid))
            {
                throw new InvalidOperationException("Bid amount must be higher than the current highest bid.");
            }

            // Create the Bid object
            var bid = new Bid(bidder, bidAmount);

            // Place the bid in the auction
            auction.PlaceBid(bid);
        }


        // Close an auction for a vehicle
        public void CloseAuction(Vehicle vehicle)
        {
            if (!_activeAuctions.TryGetValue(vehicle.Id, out var auction))
                throw new InvalidOperationException("Auction not found or already closed for this vehicle.");

            auction.CloseAuction();
            _activeAuctions.Remove(vehicle.Id); // ✅ Remove closed auction

            Console.WriteLine($"Auction closed for {vehicle.Model}. Winning bid: {auction.WinningBidAmount} by {auction.WinningBidder}.");
        }
    }
}
