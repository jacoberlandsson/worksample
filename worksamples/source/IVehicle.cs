
namespace TollFeeCalculator
{
    public interface IVehicle
    {
        Guid Id { get; }
        string Name { get; }
        string Make { get; }
        string RegistrationNumber { get; }
        string Owner { get; }
        VehicleType Type { get; }
    }
}