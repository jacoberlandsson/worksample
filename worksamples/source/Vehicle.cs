using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TollFeeCalculator //alla filer ligger inom samma namspace för nåbarhet
{

    public class Car : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Car;

        public Car(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }

    public class Motorbike : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Motorbike;

        public Motorbike(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }


    public class Tractor : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Tractor;

        public Tractor(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }


    public class Emergency : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Emergency;

        public Emergency(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }


    public class Diplomat : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Diplomat;

        public Diplomat(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }


    public class Foreign : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Foreign;

        public Foreign(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }

    public class Military : IVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RegistrationNumber { get; private set; }
        public VehicleType Type { get; } = VehicleType.Military;

        public Military(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
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