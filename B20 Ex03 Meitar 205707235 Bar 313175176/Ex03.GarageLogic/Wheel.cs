using System;
using System.Runtime.Serialization;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirPressure = 0;
        private readonly float r_MaxAirPressure;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        } 

        public void InflateWheel(float i_AirPressureToAdd)
        {
            Validation.ValidRange(i_AirPressureToAdd, k_MinAirPressure, r_MaxAirPressure);
            CurrentAirPressure += i_AirPressureToAdd;
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
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
                Validation.ValidRange(value, k_MinAirPressure, r_MaxAirPressure);
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

        public override string ToString()
        {
            return string.Format("Manufacturer: {0},  Air Pressure: {1}", m_Manufacturer, m_CurrentAirPressure);
        }
    }
}
