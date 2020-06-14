using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            new MainMenu().OpenGarage();


            ////// CreateVehicle Test
            //VehicleFactory factory = new VehicleFactory();
            //Vehicle electricCar = factory.CreateVehicle("123", "ibiza", eVehicleType.FuelBasedCar);
            ////electricCar.Owner = new VehicleOwner("bar", "056ADFA");
            //Console.WriteLine(electricCar);
            //Console.ReadLine();


            //// Vehicle TEST
            //Engine fuelEngine = new FuelEngine(eFuelType.Octane95, 20, 100);
            //Vehicle vehicle = new Vehicle("1234", "Ibiza", fuelEngine);
            //vehicle.WheelsList.Add(new Wheel("Michelin", 29, 32));
            //vehicle.WheelsList.Add(new Wheel("Michelin", 26, 32));
            //vehicle.WheelsList.Add(new Wheel("BarTires", 20, 27));
            //VehicleOwner bar = new VehicleOwner("bar", "0546");
            //vehicle.Owner = bar;
            //Console.WriteLine(vehicle);
            //Console.ReadLine();



            //Wheel wheel = new Wheel("Michelin", 28, 30);
            //// Owner Test
            //VehicleOwner bar = new VehicleOwner("bar", "056 ואת השאר תנחש");
            //Console.WriteLine(bar.PhoneNumber + "\n" + bar.Name);
            //Console.ReadLine();


            //// Wheel Tests
            //Console.WriteLine(wheel.Manufacturer);
            //Console.ReadLine();
            //wheel.InflateWheel(1);
            //Console.WriteLine(wheel.CurrentAirPressure);
            //wheel.InflateWheel(5);


            //// Engines TESTS
            //Engine fuelEngine = new FuelEngine(eFuelType.Octane95, 20, 100);
            //    Console.WriteLine(fuelEngine.EnergyPercentage);
            //    Engine electricEngine = new ElectricEngine(30, 100);
            //    Console.WriteLine(electricEngine.EnergyPercentage);

            //    (fuelEngine as FuelEngine).Refuel(20, eFuelType.Octane96);
            //    Console.WriteLine(fuelEngine.EnergyPercentage);

            //    Console.ReadLine();
        }
    }
}