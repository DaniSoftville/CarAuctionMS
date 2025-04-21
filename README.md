# 🚗 CarAuctionMS - Car Auction Management System

A simple, object-oriented C# application for managing car auctions. This system supports different vehicle types, provides vehicle inventory management, and handles auction and bidding logic. Built with testability and clean design in mind — no database or UI, just pure logic and unit tests.

🔗 **Live Repo**: [github.com/DaniSoftville/CarAuctionMS](https://github.com/DaniSoftville/CarAuctionMS)

---

## 📌 Problem Statement

You are tasked with implementing a Car Auction Management System that:

- Supports various vehicle types: **Sedans**, **SUVs**, **Hatchbacks**, and **Trucks**
- Allows adding and searching vehicles by multiple criteria
- Handles auction lifecycle: start, bid, close
- Includes robust error handling and input validation
- Focuses on clean object-oriented design and unit testing

---

## ✅ Features

- Add vehicles to inventory with unique IDs and type-specific attributes
- Search vehicles by type, manufacturer, model, or year
- Start and close auctions for vehicles
- Place bids (only during active auctions)
- Full error and edge-case handling
- Unit tests for all core functionality

---

## 🧠 Design Decisions

### 1. Object-Oriented Approach

Each vehicle type (e.g. `Sedan`, `SUV`, `Truck`, `Hatchback`) is modeled as a class extending a common `Vehicle` base class, allowing shared logic and polymorphism.

### 2. Manager Classes

Two key manager classes are used:

- `VehicleManager` – handles inventory and search logic
- `AuctionManager` – manages auction states and bidding

This separation improves cohesion and testability.

### 3. Dependency Injection (Optional/Future)

Dependency Injection (DI) has been introduced to improve the **scalability**, **maintainability**, and **testability** of the application. The main benefits include:

- **Scalability**: As new features or services are added, they can be easily integrated without altering the existing logic.
- **Maintainability**: By decoupling the system components, the code becomes easier to manage and extend.
- **Testability**: DI makes unit testing more straightforward by allowing us to inject mock services or substitutes for real-world components.

### Key Points of DI in This Project:

- Services like `VehicleManager`, `AuctionManager`, and `AuctionService` are now injected into the application's components using `Microsoft.Extensions.DependencyInjection`.
- **Singleton** and **Transient** lifetimes are used to manage service instances.
- DI helps in creating a clean separation of concerns, where the logic of vehicle management and auction management is decoupled from the instantiation of these services.

### 4. In-Memory Storage

All vehicle and auction data is stored in-memory as per project scope — there is no database integration or persistence layer.

---

## 🧾 Assumptions

- The system does not persist data beyond runtime.
- Vehicle IDs are unique across all vehicle types.
- Only one active auction is allowed per vehicle at any given time.
- Bid amounts must be higher than the current highest bid to be accepted.
- The system does not account for concurrency, multiple users, or time-based auction expiration.

---

## 🧪 Testing

Unit tests are implemented using **xUnit** and cover:

- Adding vehicles and checking for duplicate IDs
- Searching vehicles by multiple filters
- Auction lifecycle operations: start, bid, and close
- Validation for edge cases and error handling (e.g., invalid bids, nonexistent vehicle IDs)

To run tests:

```bash
dotnet test

```

## 🛠️ How to Run

- 1. Clone the repo:

git clone https://github.com/DaniSoftville/CarAuctionMS.git
cd CarAuctionMS

- 2. Build the Project:

dotnet build

- 3. Run unit tests:

dotnet test

## 📁 Project Structure

CarAuctionMS/
├── CarAuctionMS/ # Core project with logic and entities
│ ├── Entities/ # Vehicle classes (Sedan, SUV, etc.)
│ ├── Services/ # VehicleManager, AuctionManager
│ └── Program.cs # Entry point
├── CarAuctionMS.Tests/ # xUnit test project
├── CarAuctionMS.sln # Solution file

## 🤝 Contributing

Pull requests are welcome! If you plan to contribute a significant feature, please open an issue to discuss the direction first.

## 📄 License

This project is open-source and available under the MIT License.
