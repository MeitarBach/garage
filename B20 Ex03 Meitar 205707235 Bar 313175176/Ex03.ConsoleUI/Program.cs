using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Wheel wheel = new Wheel("Michelin", 28, 30);
            
            //// Vehicle Test
            


            //// Owner Test
            VehicleOwner bar = new VehicleOwner("bar", "056 ואת השאר תנחש");
            Console.WriteLine(bar.PhoneNumber + "\n" + bar.Name);
            Console.ReadLine();


            //// Wheel Tests
            //Console.WriteLine(wheel.Manufacturer);
            //Console.ReadLine();
            //wheel.InflateWheel(1);
            //Console.WriteLine(wheel.CurrentAirPressure);
            //wheel.InflateWheel(5);


            //// Engines TESTS
            Engine fuelEngine = new FuelEngine(eFuelType.Octane95, 20, 100);
            Console.WriteLine(fuelEngine.EnergyPercentage);
            Engine electricEngine = new ElectricEngine(30, 100);
            Console.WriteLine(electricEngine.EnergyPercentage);

            (fuelEngine as FuelEngine).Refuel(20, eFuelType.Octane96);
            Console.WriteLine(fuelEngine.EnergyPercentage);

            Console.ReadLine();
        }
    }
}