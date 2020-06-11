using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Wheel wheel = new Wheel("Michelin", 28, 30);
            wheel.InflateWheel(1);
            Console.WriteLine(wheel.CurrentAirPressure);
            wheel.InflateWheel(5);
            Console.ReadLine();
        }
    }
}