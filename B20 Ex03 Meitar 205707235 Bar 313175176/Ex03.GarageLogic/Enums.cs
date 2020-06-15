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

    public class EnumOperations
    {
        public static string ListEnumValues<T>(bool i_ListWithNumbers)
        {
            StringBuilder enumValuesStringBuilder = new StringBuilder();
            string[] enumValues = Enum.GetNames(typeof(T));

            for (int i = 0; i < enumValues.Length; i++)
            {
                if(i_ListWithNumbers)
                {
                    enumValuesStringBuilder.Append(string.Format("{0}. {1}", i + 1, enumValues[i]));
                    if (enumValues.Length - 1 != i)
                    {
                        enumValuesStringBuilder.Append(Environment.NewLine);
                    }
                }
                else
                {
                    enumValuesStringBuilder.Append(Environment.NewLine);
                    enumValuesStringBuilder.Append(enumValues[i]);
                }
            }

            return enumValuesStringBuilder.ToString();
        }
    }
}
