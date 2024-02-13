using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TollFeeCalculator //alla filer ligger inom samma namspace för nåbarhet
{

    public class Car : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Car;
        }
    }

    public class Motorbike : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Motorbike;
        }
    }


    public class Tractor : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Tractor;
        }
    }

    public class Emergency : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Emergency;
        }
    }

    public class Diplomat : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Diplomat;
        }
    }

    public class Foreign : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Foreign;
        }
    }

    public class Military : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Military;
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