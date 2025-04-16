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

/*Bid Class
This class is used to represent a bid placed by a bidder in the auction. A bid consists of:

A unique identifier (Id).

The identity of the person placing the bid (Bidder).

The amount of the bid (Amount).

 Properties:
csharp
Copy
Edit
public Guid Id { get; set; } = Guid.NewGuid();
public string Bidder { get; set; }
public int Amount { get; set; }
public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
Id: This is a unique identifier for the bid. It uses Guid.NewGuid() to automatically generate a new unique ID every time a new bid is created. This ensures that each bid can be uniquely identified.

Bidder: This property holds the name or identifier of the bidder placing the bid. It is a string, but it could be extended to hold more complex data (like a Bidder class) if you need more information about the bidder (e.g., contact details, account info).

Amount: The value of the bid. It is an integer representing the amount the bidder is offering.

PlacedAt: This is a DateTime property that records when the bid was placed. The default value is DateTime.UtcNow, which means the bid's timestamp will be set to the current UTC time when the bid is created.

2. Constructor:
csharp
Copy
Edit
public Bid(string bidder, int amount)
{
    Bidder = bidder;
    Amount = amount;
}
This constructor is used to initialize the Bid object.

It accepts two parameters:

bidder: A string representing the identity of the person placing the bid.

amount: The amount of the bid.

When a new bid is created, these two properties (Bidder and Amount) are assigned values.
3. Override ToString() Method:
csharp
Copy
Edit
public override string ToString()
{
    return $"{Bidder} bid {Amount} at {PlacedAt:u}";
}
This is an overridden method of the Object class that is used to return a string representation of the Bid object.

The method formats the bid’s information into a readable string, showing:

The bidder's name (Bidder).

The bid amount (Amount).

The time the bid was placed (PlacedAt), formatted as a UTC timestamp (:u for "round-trip" format).

For example, if a bid is placed by a person named John Doe, with an amount of 1000, the output might look like:

yaml
Copy
Edit
John Doe bid 1000 at 2025-04-16 18:30:00Z
4. Usage Example:
csharp
Copy
Edit
var bid1 = new Bid("John Doe", 1000);
Console.WriteLine(bid1);  // Output: John Doe bid 1000 at 2025-04-16 18:30:00Z
When you create a new Bid object with the Bid constructor, the ToString() method will be used when printing or logging the bid. This will output the information in the format: "{Bidder} bid {Amount} at {PlacedAt:u}".
Key Concepts:
Encapsulation: The class hides its internal details and provides a clean interface (through properties like Amount, Bidder, and PlacedAt). It doesn’t expose unnecessary details to the outside world but offers controlled access via its constructor and properties.

Data Integrity: The PlacedAt property is automatically set to the current UTC time when a bid is created, ensuring that each bid is timestamped correctly. Similarly, Id is automatically generated with Guid.NewGuid(), ensuring unique identification.

Override ToString(): By overriding the ToString() method, the class provides a custom string representation of the object, which is very useful for debugging, logging, or displaying information to the user.

How It Fits in the Auction System:
In your auction system, this class would be used to represent individual bids placed on an auction. Each Bid object is created when someone places a bid, and it is associated with the auction process. You can store multiple bids for an auction and evaluate the highest bid when closing the auction.
*/