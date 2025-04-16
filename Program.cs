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

        // Create and add vehicles
        var sedan = new Sedan("Ford", "Focus", 2020, "Blue", 50000, "imageUrl", 12000, 4);
        var suv = new SUV("Land Rover", "Range Rover", 2021, "Black", 25000, "imageUrl", 35000, 5);
        var truck = new Truck("Volvo", "FH16", 2018, "Red", 120000, "imageUrl", 70000, 15);
        var hatchback = new Hatchback("Volkswagen", "Golf", 2019, "White", 30000, "imageUrl", 15000, 5);

        Console.WriteLine("Vehicles created...");


        vehicleManager.AddVehicle(sedan);
        vehicleManager.AddVehicle(suv);
        vehicleManager.AddVehicle(truck);
        vehicleManager.AddVehicle(hatchback);

        Console.WriteLine("Vehicles added to the manager...");

        // Search by manufacturer
        var fordVehicles = vehicleManager.SearchVehiclesByManufacturer("Ford");
        Console.WriteLine("Searching for vehicles by manufacturer 'Ford'...");
        foreach (var vehicle in fordVehicles)
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

        Console.WriteLine("Press Enter to exit..."); return 0;
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
