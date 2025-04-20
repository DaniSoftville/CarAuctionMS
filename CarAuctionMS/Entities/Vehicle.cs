using System;

namespace CarAuctionMS.Entities
{
    public enum VehicleType
    {
        Sedan,
        SUV,
        Truck,
        Hatchback
    }

    public abstract class Vehicle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }
        public int Mileage { get; set; }
        public string? ImageUrl { get; set; }
        public int StartingBid { get; set; }
        public VehicleType VehicleType { get; set; }  // To store the type of the vehicle (Sedan, SUV, etc.)

        public abstract string GetVehicleDetails();

        // ✅ Added ToString() override
        public override string ToString()
        {
            return $"{Year} {Manufacturer} {Model}";
        }
    }

    // Sedan
    public class Sedan : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Sedan(string manufacturer, string model, int year, string color, int mileage, string imageUrl, int startingBid, int numberOfDoors)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Color = color;
            Mileage = mileage;
            ImageUrl = imageUrl;
            StartingBid = startingBid;
            VehicleType = VehicleType.Sedan;
            NumberOfDoors = numberOfDoors;
        }

        public override string GetVehicleDetails()
        {
            return $"{Year} {Manufacturer} {Model} Sedan - {Color}, {Mileage} km, {NumberOfDoors} doors, Starting Bid: {StartingBid}";
        }
    }

    // SUV
    public class SUV : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public SUV(string manufacturer, string model, int year, string color, int mileage, string imageUrl, int startingBid, int numberOfSeats)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Color = color;
            Mileage = mileage;
            ImageUrl = imageUrl;
            StartingBid = startingBid;
            VehicleType = VehicleType.SUV;
            NumberOfSeats = numberOfSeats;
        }

        public override string GetVehicleDetails()
        {
            return $"{Year} {Manufacturer} {Model} SUV - {Color}, {Mileage} km, {NumberOfSeats} seats, Starting Bid: {StartingBid}";
        }
    }

    // Truck
    public class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public Truck(string manufacturer, string model, int year, string color, int mileage, string imageUrl, int startingBid, double loadCapacity)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Color = color;
            Mileage = mileage;
            ImageUrl = imageUrl;
            StartingBid = startingBid;
            VehicleType = VehicleType.Truck;
            LoadCapacity = loadCapacity;
        }

        public override string GetVehicleDetails()
        {
            return $"{Year} {Manufacturer} {Model} Truck - {Color}, {Mileage} km, Load Capacity: {LoadCapacity} tons, Starting Bid: {StartingBid}";
        }
    }

    // Hatchback
    public class Hatchback : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Hatchback(string manufacturer, string model, int year, string color, int mileage, string imageUrl, int startingBid, int numberOfDoors)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Color = color;
            Mileage = mileage;
            ImageUrl = imageUrl;
            StartingBid = startingBid;
            VehicleType = VehicleType.Hatchback;
            NumberOfDoors = numberOfDoors;
        }

        public override string GetVehicleDetails()
        {
            return $"{Year} {Manufacturer} {Model} Hatchback - {Color}, {Mileage} km, {NumberOfDoors} doors, Starting Bid: {StartingBid}";
        }
    }
}
