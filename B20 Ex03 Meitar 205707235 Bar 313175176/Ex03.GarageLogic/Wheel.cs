using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;
        private const float k_MinAirPressure = 0;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        } 

        public void InflateWheel(float i_AirPressureToAdd)
        {
            if (i_AirPressureToAdd < k_MinAirPressure)
            {
                throw new ValueOutOfRangeException(i_AirPressureToAdd, k_MinAirPressure,
                    r_MaxAirPressure - m_CurrentAirPressure);
            }

            CurrentAirPressure += i_AirPressureToAdd;
        }

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value < k_MinAirPressure || value > r_MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(value, k_MinAirPressure,
                        r_MaxAirPressure - m_CurrentAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
    }
}
