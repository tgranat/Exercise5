using System;
using System.Linq;

namespace Exercise5
{
    public class GarageMenu
    {
        private GarageHandler handler;
        private IGarage garage;
        private IUI ui;  

        public void Run()
        {
            Initialize();
            MainMenu();
        }

        private void Initialize()
        {
            ui = new ConsoleUI(); 
            handler = new GarageHandler();
            // Creates a default garage
            garage = handler.CreateGarage(10); 
         }
        private void MainMenu()
        {
            ui.PrintLine("Garage 1.0");
            do
            {
                ui.PrintLine("0 - Quit");
                ui.PrintLine("1 - Create new garage");
                ui.PrintLine("2 - Manage vehicles (add, remove, display info)"); 
                ui.PrintLine("3 - Searches (list and search in garage)");
                ui.PrintLine("4 - Populate garage with testdata");
                ui.PrintLine("5 - Resize garage");

                int choice = ui.ReadInt();
               
                switch (choice)
                {
                    case 1:
                        CreateGarage();
                        break;
                    case 2:
                        VehiclesManagement();
                        break;
                    case 3:
                        GarageSearch();
                        break;
                    case 4:
                        handler.PopulateWithTestData(garage);
                        ui.PrintLine("Garage has been populated with test data");
                        break;
                    case 5:
                        int newSize = ui.ReadInt($"Current size  is {garage.Capacity}. If size is reduced, data may be lost. New size: ");
                        garage.Resize(newSize);
                        break;
                    case 0:
                        ui.PrintLine("Exiting.");
                        return;
                        
                    default:
                        ui.PrintLine("Please enter a valid input.");
                        break;
                }
            }
            while (true);
        }

        // Creates a garage. Overwrites the existing garage.
        private void CreateGarage()
        {
            int capacity = ui.ReadInt("Enter capacity of the garage (max size 1000): ", 0, 1000);
            garage = handler.CreateGarage(capacity);
            ui.PrintLine($"New garage created with capacity: {capacity}");
        }

        private void VehiclesManagement()
        {
            ui.PrintLine("Manage vehicles");
            do
            {
                ui.PrintLine("0 - Back to main menu");
                ui.PrintLine("1 - Add a car"); 
                ui.PrintLine("2 - Add a bus");
                ui.PrintLine("3 - Add a motorcycle");
                ui.PrintLine("4 - Add a boat");
                ui.PrintLine("5 - Add an airplane");
                ui.PrintLine("6 - Display vehicle based on registration number");
                ui.PrintLine("7 - Remove a vehicle based on registration number");

                int choice = ui.ReadInt();
               
                switch (choice)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        AddBus();
                        break;
                    case 3:
                        AddMotorcycle();
                        break;
                    case 4:
                        AddBoat();
                        break;
                    case 5:
                        AddAirplane();
                        break;
                    case 6:
                        DisplayVehicle();
                        break;
                    case 7:
                        RemoveVehicle();
                        break;
                    case 0:
                        ui.PrintLine("Exiting mangage vehicles.");
                        return;

                    default:
                        ui.PrintLine("Please enter a valid input.");
                        break;
                }
            }
            while (true);
        }

        private void DisplayVehicle()
        {
            var regNumber = ui.ReadLine("Enter registration number: ");
            var vehicle = garage.GetVehicle(regNumber);
            if (vehicle != null)
                ui.PrintLine(vehicle.ToString());
            else
                ui.PrintLine($"Vehicle with registration number {regNumber} not found.");
        }
        private void RemoveVehicle()
        {
            var regNumber = ui.ReadLine("Enter registration number: ");
            if (IsVehicleParked(regNumber))
            {
                ui.PrintLine(garage.RemoveVehicle(regNumber) ?
                   $"Vehicle with registration number {regNumber} has been removed." :
                   $"Vehicle with registration number {regNumber} could not be removed.");
            }
            else
            {
                ui.PrintLine($"Vehicle with registration number {regNumber} not found.");
            }
        }

        private void AddCar()
        { 
            if (IsGarageFull)
            {
                ui.PrintLine("Garage is full!");
                return;
            }

            var (regNumber, color, wheels) = GetBasicVehicleInfo();
            
            // Get specific Car info
            ui.PrintLine("Enter fuel type (enter digit)");
            foreach (var enumValue in Enum.GetValues(typeof(FuelType)))
            {
                ui.PrintLine($"{(int)enumValue} - {enumValue}");
            }
            
            int fuel = ui.ReadInt(
                Enum.GetValues(typeof(FuelType)).Cast<int>().Min(),     // Getting min and max int values for enum 
                Enum.GetValues(typeof(FuelType)).Cast<int>().Max());    // (got this from Stackoverflow)

            if (IsVehicleParked(regNumber))
            {
                ui.PrintLine($"A vehicle with registration number {regNumber} is already parked.");
            }
            else
            {
                ui.PrintLine(garage.Add(new Car(regNumber, color, wheels, (FuelType)fuel)) ? "Successfully added car." : "Failed to add car.");
            }
        }

        private void AddBus()
        {
            if (IsGarageFull)
            {
                ui.PrintLine("Garage is full!");
                return;
            }
            var (regNumber, color, wheels) = GetBasicVehicleInfo();
            // Get Bus specific info
            int seats = ui.ReadInt("Enter number of seats: ");

            if (IsVehicleParked(regNumber))
            {
                ui.PrintLine($"A vehicle with registration number {regNumber} is already parked.");
            }
            else
            {
                ui.PrintLine(garage.Add(new Bus(regNumber, color, wheels, seats)) ? "Successfully added bus." : "Failed to add bus.");
            }
        }

        private void AddMotorcycle()
        {
            if (IsGarageFull)
            {
                ui.PrintLine("Garage is full!");
                return;
            }
            var (regNumber, color, wheels) = GetBasicVehicleInfo();

            int volume = ui.ReadInt("Enter cylinder volume: ");

            if (IsVehicleParked(regNumber))
            {
                ui.PrintLine($"A vehicle with registration number {regNumber} is already parked.");
            }
            else
            {
                ui.PrintLine(garage.Add(new Motorcycle(regNumber, color, wheels, volume)) ? "Successfully added MC." : "Failed to add MC.");
            }
        }

        private void AddBoat()
        {
            if (IsGarageFull)
            {
                ui.PrintLine("Garage is full!");
                return;
            }
            var (regNumber, color, wheels) = GetBasicVehicleInfo();

            int length = ui.ReadInt("Enter length: ");

            if (IsVehicleParked(regNumber))
            {
                ui.PrintLine($"A vehicle with registration number {regNumber} is already parked.");
            }
            else
            {
                ui.PrintLine(garage.Add(new Boat(regNumber, color, wheels, length)) ? "Successfully added boat." : "Failed to add boat.");
            }
        }

        private void AddAirplane()
        {
            if (IsGarageFull)
            {
                ui.PrintLine("Garage is full!");
                return;
            }
            var (regNumber, color, wheels) = GetBasicVehicleInfo();

            int wingSpan = ui.ReadInt("Enter wingspan: ");

            if (IsVehicleParked(regNumber))
            {
                ui.PrintLine($"A vehicle with registration number {regNumber} is already parked.");
            }
            else
            {
                ui.PrintLine(garage.Add(new Airplane(regNumber, color, wheels, wingSpan)) ? "Successfully added airplane." : "Failed to add airplane.");
            }
        }

        private (string regNumber, string color, int wheels) GetBasicVehicleInfo()
        {
            string regNumber = ui.ReadLine("Enter registration number: ");
            string color = ui.ReadLine("Enter color: ");
            int wheels = ui.ReadInt("Enter number of wheels: ");
            return (regNumber, color, wheels);
        }

        private void GarageSearch()
        {
            ui.PrintLine("Search and list in garage");
            do
            {
                ui.PrintLine("0 - Back to main menu");
                ui.PrintLine("1 - List all vehicles");
                ui.PrintLine("2 - List all parking spaces and vehicles");
                ui.PrintLine("3 - List number of vehicle types");
                ui.PrintLine("4 - List vehicles based on color");
                ui.PrintLine("5 - List vehicles based on type");
                ui.PrintLine("6 - List vehicles based on type, color and number of wheels");

                int choice = ui.ReadInt();

                switch (choice)
                {
                    case 1:
                        ParkedVehicles();
                        break;
                    case 2:
                        ParkingSpaces();
                        break;
                    case 3:
                        VehicleTypes();
                        break;
                    case 4:
                        VehiclesColor();
                        break;
                    case 5:
                        VehicleType();
                        break;
                    case 6:
                        VehiclesTypeColorWheel();
                        break;
                    case 0:
                        ui.PrintLine("Exiting search and list.");
                        return;
                    default:
                        ui.PrintLine("Please enter a valid input.");
                        break;
                }
            }
            while (true);
        }

        private void ParkedVehicles()
        {
            ui.PrintLine("Parked vehicles:");
            foreach (var item in garage)
            {
                if (item != null) ui.PrintLine(item.ToString());
            }
        }
        private void ParkingSpaces()
        {
            ui.PrintLine("Parking spaces:");
            for (int i = 0; i < garage.Capacity; i++)
            {
                if (garage[i] == null)
                    ui.PrintLine($"{i}.\tFree space");
                else
                    ui.PrintLine($"{i}.\t{garage[i]}");
            }
        }
        private void VehicleTypes()
        {
            ui.PrintLine("Number of vehicle types:");
            // Get the data in List of tuples. Print Item1 and Item2 in the tuples.
            garage.GetNumberOfVehiclesPerType().ForEach(t => ui.PrintLine($"{t.Item1}:\t{t.Item2}"));
        }

        private void VehiclesColor()
        {
            var color = ui.ReadLine("Enter color: ");
            ui.PrintLine($"Vehicles with color {color}:");
            garage.GetVehicles(color).ForEach(i => ui.PrintLine(i.ToString()));
        }

        private void VehicleType()
        {
            VehicleType type = InputVehicleType();
            ui.PrintLine($"Vehicles of type {(VehicleType)type}:");
            garage.GetVehicles(type).ForEach(i => ui.PrintLine(i.ToString()));
        }

        private void VehiclesTypeColorWheel()
        {
            VehicleType type1 = InputVehicleType();
            var color1 = ui.ReadLine("Enter color: ");
            var wheels = ui.ReadInt("Number of wheels: ");
            ui.PrintLine("Vehicles found:");
            garage.GetVehicles(type1, color1, wheels).ForEach(i => ui.PrintLine(i.ToString()));
        }

        private VehicleType InputVehicleType()
        {
            ui.PrintLine("Enter vehicle type to list (enter digit)");
            foreach (var enumValue in Enum.GetValues(typeof(VehicleType)))
            {
                ui.PrintLine($"{(int)enumValue} - {enumValue}");
            }

            int type = ui.ReadInt(
                Enum.GetValues(typeof(VehicleType)).Cast<int>().Min(),
                Enum.GetValues(typeof(VehicleType)).Cast<int>().Max());
            return (VehicleType)type;
        }

        private bool IsGarageFull => garage.GetFreeSpotIndex < 0;
        private bool IsVehicleParked(string regNumber) => garage.GetVehicle(regNumber) != null;
    }
}
