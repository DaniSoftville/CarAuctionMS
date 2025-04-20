using CarAuctionMS.Entities;
using CarAuctionMS.Services;
using Xunit;
using System.Linq;  // Added missing namespace

namespace CarAuctionMS.Tests
{
    public class VehicleManagerTests
    {
        [Fact]
        public void TestAddVehicle()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var sedan = new Sedan(
                "Aston Martin",  // Changed to English brand
                "DBX",           // Changed to English model
                2021,
                "White",
                30000,
                "https://example.com/aston-martin-dbx.jpg",  // Example image URL
                15000,
                4
            );

            // Act
            vehicleManager.AddVehicle(sedan);
            var addedVehicle = vehicleManager.GetAllVehicles().FirstOrDefault(v => v.Manufacturer == "Aston Martin" && v.Model == "DBX");

            // Assert
            Assert.NotNull(addedVehicle);
            Assert.Equal("Aston Martin", addedVehicle.Manufacturer);
            Assert.Equal("DBX", addedVehicle.Model);
            Assert.Equal(2021, addedVehicle.Year);
            Assert.Equal("White", addedVehicle.Color);
            Assert.Equal(30000, addedVehicle.Mileage);
            Assert.Equal(4, ((Sedan)addedVehicle).NumberOfDoors);  // Casting to access Sedan-specific property
            Assert.Equal(15000, addedVehicle.StartingBid);
        }

        [Fact]
        public void TestGetVehicleDetails()
        {
            // Arrange
            var vehicleManager = new VehicleManager();
            var sedan = new Sedan(
                "Aston Martin",  // Changed to English brand
                "DBX",           // Changed to English model
                2021,
                "White",
                30000,
                "https://example.com/aston-martin-dbx.jpg",  // Example image URL
                15000,
                4
            );

            // Act
            vehicleManager.AddVehicle(sedan);
            var vehicleDetails = sedan.GetVehicleDetails();

            // Assert
            Assert.Equal("2021 Aston Martin DBX Sedan - White, 30000 km, 4 doors, Starting Bid: 15000", vehicleDetails);
        }
    }
}
