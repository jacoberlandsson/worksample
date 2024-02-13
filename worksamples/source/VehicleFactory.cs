
namespace TollFeeCalculator //alla filer ligger inom samma namspace f�r n�barhet
{
    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.Car:
                    return new Car();
                case VehicleType.Motorbike:
                    return new Motorbike();
                case VehicleType.Tractor:
                    return new Tractor();
                case VehicleType.Emergency:
                    return new Emergency();
                case VehicleType.Diplomat:
                    return new Diplomat();
                case VehicleType.Foreign:
                    return new Foreign();
                case VehicleType.Military:
                    return new Military();
                default:
                    throw new ArgumentException("Invalid vehicle type", nameof(type));
            }
        }
    }
}