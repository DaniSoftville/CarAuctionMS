using System;
using System.Collections.Generic;

namespace CarAuctionMS.Entities
{
    public class Auction
    {
        // The unique identifier for the auction. This is set to a new GUID by default.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Each auction is tied to a specific vehicle. This creates a one-to-one relationship.
        public Vehicle Vehicle { get; private set; }

        // Date the auction was created. This is set when the auction is instantiated.
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // The time the auction started. Initially null, it will be set when the auction starts.
        public DateTime? StartedAt { get; private set; }

        // The time the auction ended. Initially null, it will be set when the auction is closed.
        public DateTime? EndedAt { get; private set; }

        // The amount of the winning bid, which is set when the auction is closed.
        public int? WinningBidAmount { get; private set; }

        // The winning bidder's information. Set when the auction is closed.
        public string? WinningBidder { get; private set; }

        // A list of all bids placed during the auction. This is initialized as an empty list.
        public List<Bid> Bids { get; private set; } = new();

        // A derived property that indicates whether the auction is open.
        // The auction is open if it has started and has not ended yet.
        public bool IsOpen => StartedAt.HasValue && !EndedAt.HasValue;

        //  initialize auction with a vehicle and a starting bid
        public Auction(Vehicle vehicle, int startingBid)
        {
            Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
            Vehicle.StartingBid = startingBid;
        }

        // Starts the auction. This sets the StartedAt time and ensures no auction can be started twice.
        public void StartAuction()
        {
            // Guard clause to prevent re-starting an already started auction.
            if (IsOpen)
                throw new InvalidOperationException("Auction is already started.");

            // Sets the time when the auction was started.
            StartedAt = DateTime.UtcNow;
        }

        // Places a bid on the auction. The bid must be greater than the current highest bid or the vehicle's starting bid.
        public void PlaceBid(Bid bid)
        {
            // Guard clause to ensure the auction is open before placing a bid.
            if (!IsOpen)
                throw new InvalidOperationException("Auction is not open.");

            // Ensures the new bid is higher than the current highest bid.
            // If there are no bids yet, it ensures the new bid is higher than the starting bid.
            if (bid.Amount <= (Bids.Count > 0 ? Bids[^1].Amount : Vehicle.StartingBid))
                throw new InvalidOperationException("Bid amount must be higher than current highest bid.");

            // Adds the new bid to the list of bids.
            Bids.Add(bid);
        }

        // Closes the auction. No more bids can be placed once the auction is closed.
        public void CloseAuction()
        {
            // Guard clause to ensure the auction is open before closing it.
            if (!IsOpen)
                throw new InvalidOperationException("Auction is not open or already closed.");

            // Sets the time when the auction was closed.
            EndedAt = DateTime.UtcNow;

            // If there were any bids, set the winning bid and bidder.
            if (Bids.Count > 0)
            {
                // The last bid in the list is the winning bid (as bids are added in order).
                var winningBid = Bids[^1];
                WinningBidAmount = winningBid.Amount;
                WinningBidder = winningBid.Bidder;
            }
        }
    }
}