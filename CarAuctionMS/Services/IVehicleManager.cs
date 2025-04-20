using System;
using System.Collections.Generic;
using CarAuctionMS.Entities;

namespace CarAuctionMS.Services
{
    public interface IVehicleManager
    {
        void AddVehicle(Vehicle vehicle);
        List<Vehicle> SearchVehiclesByManufacturer(string manufacturer);
        List<Vehicle> GetAllVehicles();
    }
}