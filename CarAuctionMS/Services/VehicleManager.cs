
using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public class VehicleManager : IVehicleManager
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();

        // 1) Add a vehicle to the system
        public void AddVehicle(Vehicle vehicle)
        {
            // Check if the vehicle ID already exists
            if (_vehicles.Exists(v => v.Id == vehicle.Id))
            {
                Console.WriteLine($"Error: Vehicle with ID {vehicle.Id} already exists.");
                return;  // Do not add the vehicle if it's a duplicate
            }

            _vehicles.Add(vehicle);
            // Printing more detailed information for the vehicle
            Console.WriteLine($"Vehicle added: {vehicle.GetVehicleDetails()}");
        }

        // 2) Search vehicles by type
        public List<Vehicle> SearchVehiclesByType(VehicleType type)
        {
            return _vehicles.Where(v => v.VehicleType == type).ToList();
        }

        // Search vehicles by manufacturer
        public List<Vehicle> SearchVehiclesByManufacturer(string manufacturer)
        {
            return _vehicles.Where(v => v.Manufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Search vehicles by model
        public List<Vehicle> SearchVehiclesByModel(string model)
        {
            return _vehicles.Where(v => v.Model.Equals(model, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Search vehicles by year
        public List<Vehicle> SearchVehiclesByYear(int year)
        {
            return _vehicles.Where(v => v.Year == year).ToList();
        }

        // Get all vehicles

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }
    }
}
