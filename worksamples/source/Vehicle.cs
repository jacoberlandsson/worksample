using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public interface IVehicle
    {
        int Id { get; }
        string Name { get; }
        string Make { get; }
        string Owner { get; }
        string GetVehicleType();
        VehicleType Type { get; }
    }

    public class Car : IVehicle
    {
        public string GetVehicleType()
        {
            return "Car";
        }
    }

    public class Motorbike : IVehicle
    {
        public string GetVehicleType()
        {
            return "MotorBike";
        }
    }


    public class Tractor : IVehicle
    {
        public string GetVehicleType()
        {
            return "Tractor";
        }
    }

    public class Emergency : IVehicle
    {
        public string GetVehicleType()
        {
            return "Emergency";
        }
    }

    public class Diplomat : IVehicle
    {
        public string GetVehicleType()
        {
            return "Diplomat";
        }
    }

    public class Foreign : IVehicle
    {
        public string GetVehicleType()
        {
            return "Foreign";
        }
    }

    public class Military : IVehicle
    {
        public string GetVehicleType()
        {
            return "Military";
        }
    }

    public enum VehicleType
    {
    Car,
    Truck,
    Motorbike,
    Tractor,
    Emergency,
    Diplomat,
    Foreign,
    Military
    }

}