
namespace TollFeeCalculator
{
    public interface IVehicle
    {
        Guid Id { get; }
        string RegistrationNumber { get; }
        VehicleType Type { get; }
    }
}