namespace Exercise5
{
    public interface IVehicle
    {
        string Color { get; }
        int NumberOfWheels { get; }
        string RegNumber { get; }
        VehicleType Type { get; }
    }
}