using System;
using System.Collections.Generic;
using System.Linq;
using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public class VehicleManager : IVehicleManager
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();

        //1)  Add a vehicle to the system
        public void AddVehicle(Vehicle vehicle)
        {
            // Check if the vehicle ID already exists
            if (_vehicles.Exists(v => v.Id == vehicle.Id))
            {
                Console.WriteLine($"Error: Vehicle with ID {vehicle.Id} already exists.");
                // or throw new InvalidOperationException($"Vehicle with ID {vehicle.Id} already exists.");
                return;  // 	Calls return before adding the vehicle. Do not add the vehicle if it's a duplicate
            }

            _vehicles.Add(vehicle);
            Console.WriteLine($"Vehicle added: {vehicle}");
        }

        //2)  Search vehicles by type
        public List<Vehicle> SearchVehiclesByType(VehicleType type)
        {
            return _vehicles.FindAll(v => v.VehicleType == type);
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