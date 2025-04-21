using CarAuctionMS.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarAuctionMS
{
  class Program
  {
    static void Main(string[] args)
    {
      // Set up the dependency injection container
      var serviceProvider = new ServiceCollection()
          .AddSingleton<IVehicleManager, VehicleManager>()  // Register VehicleManager
          .AddSingleton<IAuctionManager>(provider =>
          {
            var vehicleManager = provider.GetRequiredService<IVehicleManager>();  // Resolve IVehicleManager dependency
            return new VehicleAuctionManager(vehicleManager);  // Return a new instance of VehicleAuctionManager with the vehicleManager
          })
          .AddSingleton<AuctionService>()  // Register AuctionService to manage auction lifecycle, we need 1 instance to be shared across the app
          .BuildServiceProvider();  // Build the service provider to resolve dependencies

      // Retrieve services from the container
      var vehicleManager = serviceProvider.GetRequiredService<IVehicleManager>();  // Get the vehicle manager instance
      var auctionService = serviceProvider.GetRequiredService<AuctionService>();  // Get the auction service instance

      Console.WriteLine("Hello World! Program started...");

      try
      {
        // Create and add vehicles to the inventory
        VehicleService.CreateAndAddVehicles(vehicleManager);  // Use static method

        // Retrieve a specific vehicle (F-Pace) to start the auction
        var suv = vehicleManager.GetAllVehicles().FirstOrDefault(v => v.Model == "F-Pace");

        if (suv == null)
        {
          Console.WriteLine("SUV not found in inventory.");
          return;
        }

        // Search for vehicles based on predefined criteria
        VehicleService.SearchVehicles(vehicleManager);  // Use static method

        // Run the auction flow using the AuctionService, delegating the entire auction lifecycle
        auctionService.RunAuctionFlow(suv.Id.ToString());  // Pass the vehicle ID to the AuctionService
      }
      catch (Exception ex)
      {
        // Handle any exceptions that occur during the process
        Console.WriteLine($"An error occurred: {ex.Message}");
        Console.WriteLine(ex.StackTrace);
      }
    }
  }
}
