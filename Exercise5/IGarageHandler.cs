namespace Exercise5
{
    public interface IGarageHandler
    {
        IVehicle CreateAirplane(string regNumber, string color, int wheels, int wingSpan);
        IVehicle CreateBoat(string regNumber, string color, int wheels, int length);
        IVehicle CreateBus(string regNumber, string color, int wheels, int seats);
        IVehicle CreateCar(string regNumber, string color, int wheels, FuelType fuel);
        IGarage CreateGarage(int size);
        IVehicle CreateMotorCycle(string regNumber, string color, int wheels, int volume);
    }
}