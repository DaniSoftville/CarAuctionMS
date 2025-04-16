using Xunit;
using Moq;
using CarAuctionMS.Entities;
using CarAuctionMS.Services;
using System;

namespace CarAuctionMS.Tests
{
  public class AuctionManagerTests
  {
    private readonly Mock<VehicleManager> _mockVehicleManager;
    private readonly AuctionManager _auctionManager;

    public AuctionManagerTests()
    {
      // Mocking VehicleManager to simulate behavior in the AuctionManager tests
      _mockVehicleManager = new Mock<VehicleManager>();
      _auctionManager = new AuctionManager(_mockVehicleManager.Object);
    }

    [Fact]
    public void StartAuction_ShouldStartAuction_WhenValidVehicle()
    {
      // Arrange
      var vehicle = new SUV("Toyota", "Land Cruiser", 2022, "Black", 10000, "url", 50000, 5);
      _mockVehicleManager.Setup(v => v.AddVehicle(It.IsAny<Vehicle>())).Verifiable();

      // Act
      _auctionManager.StartAuction(vehicle);

      // Assert
      _mockVehicleManager.Verify(v => v.AddVehicle(vehicle), Times.Once, "AddVehicle should have been called once.");
    }

    [Fact]
    public void StartAuction_ShouldThrowException_WhenVehicleAlreadyInAuction()
    {
      // Arrange
      var vehicle = new SUV("Toyota", "Land Cruiser", 2022, "Black", 10000, "url", 50000, 5);
      _auctionManager.StartAuction(vehicle);

      // Act & Assert
      var exception = Assert.Throws<InvalidOperationException>(() => _auctionManager.StartAuction(vehicle));
      Assert.Equal("The vehicle is already in the auction.", exception.Message);
    }

    [Fact]
    public void PlaceBid_ShouldPlaceBid_WhenValidBid()
    {
      // Arrange
      var vehicle = new SUV("Toyota", "Land Cruiser", 2022, "Black", 10000, "url", 50000, 5);
      _auctionManager.StartAuction(vehicle);

      // Simulating that the vehicle is available for bidding
      _mockVehicleManager.Setup(v => v.GetVehicleDetails(It.IsAny<string>())).Returns(vehicle);
      _mockVehicleManager.Setup(v => v.UpdateVehicle(It.IsAny<Vehicle>())).Verifiable();

      // Act
      _auctionManager.PlaceBid(vehicle, 60000, "John");

      // Assert
      _mockVehicleManager.Verify(v => v.UpdateVehicle(It.IsAny<Vehicle>()), Times.Once, "UpdateVehicle should have been called once.");
    }

    [Fact]
    public void PlaceBid_ShouldThrowException_WhenBidIsLowerThanStartingBid()
    {
      // Arrange
      var vehicle = new SUV("Toyota", "Land Cruiser", 2022, "Black", 10000, "url", 50000, 5);
      _auctionManager.StartAuction(vehicle);

      // Act & Assert
      var exception = Assert.Throws<InvalidOperationException>(() => _auctionManager.PlaceBid(vehicle, 40000, "John"));
      Assert.Equal("Bid is lower than the starting bid.", exception.Message);
    }

    [Fact]
    public void CloseAuction_ShouldCloseAuction_WhenValidVehicle()
    {
      // Arrange
      var vehicle = new SUV("Toyota", "Land Cruiser", 2022, "Black", 10000, "url", 50000, 5);
      _auctionManager.StartAuction(vehicle);

      // Simulating that the vehicle is closed from the auction
      _mockVehicleManager.Setup(v => v.RemoveVehicle(It.IsAny<Vehicle>())).Verifiable();

      // Act
      _auctionManager.CloseAuction(vehicle);

      // Assert
      _mockVehicleManager.Verify(v => v.RemoveVehicle(vehicle), Times.Once, "RemoveVehicle should have been called once.");
    }
  }
}
