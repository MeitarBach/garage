using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octane95 = 1,
        Octane96,
        Octane98,
        Soler
    }

    public enum eColor
    {
        Red = 1,
        Blue,
        Black,
        Gray
    }

    public enum eVehicleStatus
    {
        InRepair = 1,
        Repaired,
        PayedFor
    }

    public enum eLicenseType
    {
        A = 1,
        A1,
        AA,
        B
    }

    public enum eNumOfDoors
    {
        Two = 2,
        Three,
        Four,
        Five
    }

    public enum eVehicleType
    {
        FuelBasedMotorcycle = 1,
        ElectricMotorcycle,
        FuelBasedCar,
        ElectricCar,
        FuelBasedTruck,
    }
}
