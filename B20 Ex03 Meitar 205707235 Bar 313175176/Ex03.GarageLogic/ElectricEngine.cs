using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private const float k_MinTimeInHours = 0;
        private readonly float r_MaxTimeInHours;
        private float m_RemainingTimeInHours;
        
        public ElectricEngine(float i_MaxTimeInHours) 
        {
            r_MaxTimeInHours = i_MaxTimeInHours;
        }

        public void Recharge(float i_HoursToCharge)
        {
            Validation.ValidRange(i_HoursToCharge * 60, k_MinTimeInHours, (r_MaxTimeInHours - m_RemainingTimeInHours) * 60); // The time is inserted in minutes
            RemainingTimeInHours += i_HoursToCharge;
        }

        public float RemainingTimeInHours
        {
            get
            {
                return m_RemainingTimeInHours;
            }

            set
            {
                Validation.ValidRange(value, k_MinTimeInHours, r_MaxTimeInHours);
                m_RemainingTimeInHours = value;
                UpdateEnergyPercantage();
            }
        }

        public float MaxTimeInHours
        {
            get
            {
                return r_MaxTimeInHours;
            }
        }

        public override void UpdateEnergyPercantage()
        {
            EnergyPercentage = CalcEnergyPercantage(m_RemainingTimeInHours, r_MaxTimeInHours);
        }

        public override string ToString()
        {
            return string.Format("Battery Status: {0}/{1} Hours left", m_RemainingTimeInHours, r_MaxTimeInHours);
        }
    }
}
