using CarAuctionMS.Entities;
using CarAuctionMS.Services;

namespace CarAuctionMS
{
    public static class VehicleService
    {
        public static void CreateAndAddVehicles(IVehicleManager vehicleManager)
        {
            var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "imageUrl", 15000, 4);
            var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "imageUrl", 35000, 5);
            var truck = new Truck("Bentley", "Continental GT", 2021, "Red", 120000, "imageUrl", 70000, 15);
            var hatchback = new Hatchback("Mini", "Cooper", 2019, "White", 30000, "imageUrl", 15000, 5);

            vehicleManager.AddVehicle(sedan);
            vehicleManager.AddVehicle(suv);
            vehicleManager.AddVehicle(truck);
            vehicleManager.AddVehicle(hatchback);

            Console.WriteLine("Vehicles added.");
        }

        public static void SearchVehicles(IVehicleManager vehicleManager)
        {
            // Search by manufacturer
            var astonMartinVehicles = vehicleManager.SearchVehiclesByManufacturer("Aston Martin");
            Console.WriteLine("Vehicles by Aston Martin:");
            foreach (var vehicle in astonMartinVehicles)
            {
                Console.WriteLine(vehicle.GetVehicleDetails());
            }

            // Search by vehicle type
            var sedans = vehicleManager.SearchVehiclesByType(VehicleType.Sedan);
            Console.WriteLine("Vehicles of type Sedan:");
            foreach (var vehicle in sedans)
            {
                Console.WriteLine(vehicle.GetVehicleDetails());
            }
        }
    }
}
