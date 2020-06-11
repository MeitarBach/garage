using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmount;
        private readonly float r_MaxFuelAmount;
        private const float k_MinFuelAmount = 0;

        public FuelEngine(eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(i_CurrentFuelAmount, k_MinFuelAmount, i_MaxFuelAmount);
            }

            r_FuelType = i_FuelType;
            m_CurrentFuelAmount = i_CurrentFuelAmount;
            r_MaxFuelAmount = i_MaxFuelAmount;
            EnergyPercentage = CalcEnergyPercantage(i_CurrentFuelAmount, i_MaxFuelAmount);
        }

        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException(String.Format("Wrong Fuel Type, this engine runs on {0}", r_FuelType));
            }

            if (i_FuelToAdd < k_MinFuelAmount)
            {
                throw new ValueOutOfRangeException(i_FuelToAdd, k_MinFuelAmount,
                    r_MaxFuelAmount - m_CurrentFuelAmount);
            }

            CurrentFuelAmount += i_FuelToAdd;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }

            set
            {
                if (value > r_MaxFuelAmount || value < 0)
                {
                    throw new ValueOutOfRangeException(value, k_MinFuelAmount,
                        r_MaxFuelAmount - m_CurrentFuelAmount);
                }

                m_CurrentFuelAmount = value;
                UpdateEnergyPercantage();
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return r_MaxFuelAmount;
            }
        }

        public override void UpdateEnergyPercantage()
        {
            EnergyPercentage = CalcEnergyPercantage(m_CurrentFuelAmount, r_MaxFuelAmount);
        }
    }
}
