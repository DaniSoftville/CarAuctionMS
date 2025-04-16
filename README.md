# CarAuctionMS

C# object-oriented solution for an auction management system.  
This project demonstrates clean object-oriented design principles without relying on any database or UI — entirely in-memory and testable.

---

## 🚗 Domain Overview

The system simulates a vehicle auction, supporting:

- Adding vehicles
- Searching vehicles
- Starting auctions
- Placing bids
- Closing auctions

All logic is modeled using C# classes and designed with clean architecture and separation of concerns in mind.

---

## 🧱 Core Entities

### `Vehicle`

Represents a car with basic information.

```csharp
public class Vehicle
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }
    public int StartingBid { get; set; }
    public string VehicleType { get; set; } // Sedan, SUV, Truck, etc.

    public override string ToString()
    {
        return $"{Year} {Manufacturer} {Model} ({Color}) - {Mileage} km";
    }
}

Bid
Represents a bid made on an auction.

public class Bid
{
    public string Bidder { get; set; }
    public int Amount { get; set; }
    public DateTime TimePlaced { get; set; } = DateTime.UtcNow;
}
Auction
Handles the lifecycle of an auction.

public class Auction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Vehicle Vehicle { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? StartedAt { get; private set; }
    public DateTime? EndedAt { get; private set; }
    public int? WinningBidAmount { get; private set; }
    public string? WinningBidder { get; private set; }

    public List<Bid> Bids { get; private set; } = new();

    public bool IsOpen => StartedAt.HasValue && !EndedAt.HasValue;

    public void StartAuction() { ... }
    public void PlaceBid(Bid bid) { ... }
    public void CloseAuction() { ... }
}

Tests
Unit tests are included using xUnit and validate key behaviors like:

Bidding only when auction is open

Only accepting higher bids

Correctly setting winning bid on auction close

Preventing duplicate auction starts

💡 Design Principles

Principle	Used In	Description
Encapsulation	private set & guard clauses	Protects internal state with validation
Abstraction	StartAuction(), PlaceBid()	Exposes simple methods hiding complex logic
Object Modeling	Vehicle, Bid classes	Mirrors real-world entities cleanly
No Persistence	In-memory only	Easy to test, no external DB dependencies

✅ How to Run
bash
Copy
Edit
git clone https://github.com/YourUsername/CarAuctionMS.git
cd CarAuctionMS
dotnet run

✅ How to Test
bash
Copy
Edit
dotnet test
📂 Folder Structure
Copy
Edit
CarAuctionMS/
├── Entities/
│   ├── Vehicle.cs
│   ├── Auction.cs
│   └── Bid.cs
├── Tests/
│   └── AuctionTests.cs
├── Program.cs
└── README.md

🧑‍💻 Author
    Luis Hernandez
📧 danisoftville@gmail.com

📝 License
MIT License — feel free to fork and modify for learning or hobby use!

```
