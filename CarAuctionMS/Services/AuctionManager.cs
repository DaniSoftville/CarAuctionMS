using System;
using System.Collections.Generic;
using System.Linq;
using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public class VehicleAuctionManager
    {
        // Reference to the VehicleManager to manage vehicles
        private readonly VehicleManager _vehicleManager;

        // A dictionary to hold the active auctions keyed by vehicle ID
        private readonly Dictionary<Guid, Auction> _activeAuctions;

        // Constructor initializing the VehicleManager and the dictionary for active auctions
        public VehicleAuctionManager(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager ?? throw new ArgumentNullException(nameof(vehicleManager));
            _activeAuctions = new Dictionary<Guid, Auction>(); // Ensure no duplicate field or shadowing
        }

        // Starts an auction for a given vehicle
        public void StartAuction(Vehicle vehicle)
        {
            // 🔍 Check if vehicle exists in the inventory
            var allVehicles = _vehicleManager.GetAllVehicles();
            if (!allVehicles.Any(v => v.Id == vehicle.Id))
                throw new InvalidOperationException("Vehicle does not exist in the inventory.");

            // 🔍 Check if auction is already active
            if (_activeAuctions.ContainsKey(vehicle.Id))
                throw new InvalidOperationException($"Auction for {vehicle.Model} is already active.");

            var auction = new Auction(vehicle, vehicle.StartingBid);
            auction.StartAuction();
            _activeAuctions[vehicle.Id] = auction;

            Console.WriteLine($"Auction started for {vehicle.Model} with starting bid {vehicle.StartingBid}.");
        }
        // 4) c)  Places a bid on an active auction
        public void PlaceBid(Vehicle vehicle, int bidAmount, string bidder)
        {
            // Check if the auction for the vehicle is active
            if (!_activeAuctions.TryGetValue(vehicle.Id, out var auction))
                throw new InvalidOperationException("Auction not found or closed for this vehicle.");

            // Ensure the new bid is higher than the current highest bid or the vehicle's starting bid
            if (bidAmount <= (auction.Bids.Count > 0 ? auction.Bids.Last().Amount : vehicle.StartingBid))
            {
                throw new InvalidOperationException("Bid amount must be higher than the current highest bid.");
            }

            // Create the new bid object and place it in the auction
            var bid = new Bid(bidder, bidAmount);
            auction.PlaceBid(bid);
            // ✅ Log the bid placement
            Console.WriteLine($"{bidder} placed a bid of {bidAmount} on {vehicle.Model}.");
        }

        // Closes the auction for a given vehicle
        public void CloseAuction(Vehicle vehicle)
        {
            if (!_activeAuctions.TryGetValue(vehicle.Id, out var auction))
                throw new InvalidOperationException("Auction not found or already closed for this vehicle.");

            // Close the auction and remove it from the active auctions
            auction.CloseAuction();
            _activeAuctions.Remove(vehicle.Id);

            Console.WriteLine($"Auction closed for {vehicle.Model}. Winning bid: {auction.WinningBidAmount} by {auction.WinningBidder}.");
        }
    }
}
