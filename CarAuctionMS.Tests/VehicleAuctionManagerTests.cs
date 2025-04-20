using System;
using Xunit;
using CarAuctionMS.Entities;
using CarAuctionMS.Services;
using System.Linq;

namespace CarAuctionMS.Tests
{
    public class VehicleAuctionManagerTests
    {
        // Test: Add multiple vehicle types
        [Fact]
        public void AddMultipleVehicleTypes_ShouldAddSuccessfully()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var auctionManager = new VehicleAuctionManager(vehicleManager);

            // Adding multiple vehicles with English brands
            var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "", 10000, 4);
            var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "", 20000, 7);
            var truck = new Truck("Bentley", "Bentayga", 2021, "Red", 40000, "", 30000, 10000);

            // Act
            vehicleManager.AddVehicle(sedan);
            vehicleManager.AddVehicle(suv);
            vehicleManager.AddVehicle(truck);

            // Assert
            Assert.Equal(3, vehicleManager.GetAllVehicles().Count);
        }

        // Test: Search vehicles by type
        [Fact]
        public void SearchVehiclesByType_ShouldReturnCorrectResults()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "", 10000, 4);
            var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "", 20000, 7);
            vehicleManager.AddVehicle(sedan);
            vehicleManager.AddVehicle(suv);

            // Act
            var searchResults = vehicleManager.SearchVehiclesByType(VehicleType.Sedan);

            // Assert
            Assert.Single(searchResults);
            Assert.Equal("DBX", searchResults.First().Model);
        }

        // Test: Search vehicles by manufacturer
        [Fact]
        public void SearchVehiclesByManufacturer_ShouldReturnCorrectResults()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "", 10000, 4);
            var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "", 20000, 7);
            vehicleManager.AddVehicle(sedan);
            vehicleManager.AddVehicle(suv);

            // Act
            var searchResults = vehicleManager.SearchVehiclesByManufacturer("Jaguar");

            // Assert
            Assert.Single(searchResults);
            Assert.Equal("F-Pace", searchResults.First().Model);
        }

        // Test: Search vehicles by model (case-insensitive)
        [Fact]
        public void SearchVehiclesByModel_ShouldReturnCorrectResults_CaseInsensitive()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "", 10000, 4);
            var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "", 20000, 7);
            vehicleManager.AddVehicle(sedan);
            vehicleManager.AddVehicle(suv);

            // Act
            var searchResults = vehicleManager.SearchVehiclesByModel("f-pace");

            // Assert
            Assert.Single(searchResults);
            Assert.Equal("F-Pace", searchResults.First().Model);
        }

        // Test: Search vehicles by year
        [Fact]
        public void SearchVehiclesByYear_ShouldReturnCorrectResults()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var sedan = new Sedan("Aston Martin", "DBX", 2021, "White", 30000, "", 10000, 4);
            var suv = new SUV("Jaguar", "F-Pace", 2022, "Black", 25000, "", 20000, 7);
            vehicleManager.AddVehicle(sedan);
            vehicleManager.AddVehicle(suv);

            // Act
            var searchResults = vehicleManager.SearchVehiclesByYear(2021);

            // Assert
            Assert.Single(searchResults);
            Assert.Equal("DBX", searchResults.First().Model);
        }

        // Other tests...
    }
}
