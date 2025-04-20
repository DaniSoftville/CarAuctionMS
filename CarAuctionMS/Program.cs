using System;
using CarAuctionMS.Entities;
using CarAuctionMS.Services;

namespace CarAuctionMS
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");  // Check if this prints

      try
      {
        Console.WriteLine("Program started...");

        // Create VehicleManager
        VehicleManager vehicleManager = new VehicleManager();
        Console.WriteLine("VehicleManager created...");

        // Create and add vehicles (Using English car brands and models)
        var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "imageUrl", 15000, 4);  // English car brand
        var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "imageUrl", 35000, 5);  // English car brand
        var truck = new Truck("Bentley", "Continental GT", 2021, "Red", 120000, "imageUrl", 70000, 15);  // English luxury car
        var hatchback = new Hatchback("Mini", "Cooper", 2019, "White", 30000, "imageUrl", 15000, 5);  // British brand

        Console.WriteLine("Vehicles created...");

        // Add vehicles to the manager
        vehicleManager.AddVehicle(sedan);
        vehicleManager.AddVehicle(suv);
        vehicleManager.AddVehicle(truck);
        vehicleManager.AddVehicle(hatchback);

        Console.WriteLine("Vehicles added to the manager...");

        // Search by manufacturer
        var astonMartinVehicles = vehicleManager.SearchVehiclesByManufacturer("Aston Martin");
        Console.WriteLine("Searching for vehicles by manufacturer 'Aston Martin'...");
        foreach (var vehicle in astonMartinVehicles)
        {
          Console.WriteLine(vehicle.GetVehicleDetails());
        }

        // Search by vehicle type
        var sedans = vehicleManager.SearchVehiclesByType(VehicleType.Sedan);
        Console.WriteLine("Searching for vehicles by type 'Sedan'...");
        foreach (var vehicle in sedans)
        {
          Console.WriteLine(vehicle.GetVehicleDetails());
        }

        // --- Auction Lifecycle Demonstration ---
        Console.WriteLine("\n--- Auction Lifecycle Demo ---");

        // Create VehicleAuctionManager
        VehicleAuctionManager auctionManager = new VehicleAuctionManager(vehicleManager);
        Console.WriteLine("AuctionManager created...");

        // Start an auction for the SUV
        auctionManager.StartAuction(suv);

        // Place bids
        auctionManager.PlaceBid(suv, 36000, "Alice");
        auctionManager.PlaceBid(suv, 37000, "Bob");

        // Optional: Print bid history (commented out for future use)
        /*
        var allVehicles = vehicleManager.GetAllVehicles();
        var auction = allVehicles.FirstOrDefault(v => v.Id == suv.Id);
        if (auction != null)
        {
          Console.WriteLine("Bid history:");
          foreach (var bid in auction.Bids)
          {
            Console.WriteLine($"Bidder: {bid.Bidder}, Amount: {bid.Amount}");
          }
        }
        */

        // Close the auction
        auctionManager.CloseAuction(suv);

        Console.WriteLine("--- Auction completed ---");

        // Wait for user input before closing
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine(); // Keep the console window open
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
        Console.WriteLine(ex.StackTrace); // Log the stack trace for debugging
      }
    }
  }
}
