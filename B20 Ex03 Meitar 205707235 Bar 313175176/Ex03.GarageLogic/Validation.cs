using System;

namespace Ex03.GarageLogic
{
    class Validation
    {
        public static void ValidRange(float i_Value, float i_MinValue, float i_MaxValue)
        {
            if (i_Value < i_MinValue || i_Value > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_Value, i_MinValue, i_MaxValue);
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

        public static float ValidateAndParseFloat(string i_FieldValue)
        {
            float floatNumber;

            if (!float.TryParse(i_FieldValue, out floatNumber))
            {
                throw new FormatException("Not a valid fuel amount");
            }

            return floatNumber;
        }
    }
}
