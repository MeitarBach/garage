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
    }
}
