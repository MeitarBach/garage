using System;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Validation
    {
        public static void ValidRange(float i_Value, float i_MinValue, float i_MaxValue)
        {
            if (i_Value < i_MinValue || i_Value > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_Value, i_MinValue, i_MaxValue);
            }
        }

        public static void ValidRange(float i_Value, float i_MinValue)
        {
            if (i_Value < i_MinValue)
            {
                throw new ValueOutOfRangeException(i_Value, i_MinValue);
            }
        }

        public static void ValidFuelVehicle(Vehicle i_Vehicle)
        {
            if(!(i_Vehicle.Engine is FuelEngine))
            {
                throw new ArgumentException("The vehicle is not fuel based");
            }
        }

        public static void ValidElectricVehicle(Vehicle i_Vehicle)
        {
            if (!(i_Vehicle.Engine is ElectricEngine))
            {
                throw new ArgumentException("The vehicle is not electric");
            }
        }

        public static void ValidFuelType(eFuelType i_EnteredFuelType, eFuelType i_ExpectedFuelType)
        {
            if(i_EnteredFuelType != i_ExpectedFuelType)
            {
                throw new ArgumentException(string.Format("Wrong Fuel Type, this engine runs on {0}, but you entered {1}",
                                                                i_ExpectedFuelType, i_EnteredFuelType));
            }
        }

        public static float ValidateAndParseFloat(string i_FloatValue)
        {
            float floatNumber;

            if (!float.TryParse(i_FloatValue, out floatNumber))
            {
                throw new FormatException("Invalid choice. Please enter a number");
            }

            return floatNumber;
        }

        public static int ValidateAndParseInt(string i_FloatValue)
        {
            int intNumber;

            if (!int.TryParse(i_FloatValue, out intNumber))
            {
                throw new FormatException("Invalid choice. Please enter an integer number");
            }

            return intNumber;
        }

        public static bool ValidateAndParseBool(string i_FloatValue)
        {
            bool boolValue = true;
            
            switch(i_FloatValue.ToLower())
            {
                case "yes":
                    break;
                case "no":
                    boolValue = !boolValue;
                    break;
                default:
                    throw new FormatException("Invalid choice. Please enter Yes / No");
            }

            return boolValue;
        }

        public static T ValidateAndParseEnum<T>(string i_EnumValue) where T : struct
        {
            T enumValue;

            if(!Enum.TryParse<T>(i_EnumValue, out enumValue) || !Enum.GetNames(typeof(T)).Contains(i_EnumValue))
            {
                bool enumListWithNumbers = false;
                throw new FormatException(string.Format("Invalid Choice. Enter one of the following: {0}", EnumOperations.ListEnumValues<T>(enumListWithNumbers)));
            }

            return enumValue;
        }
    }
}
