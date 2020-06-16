namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private const float k_MinFuelAmount = 0;
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelAmount;
        private float m_CurrentFuelAmount;

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelAmount = i_MaxFuelAmount;
        }

        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            Validation.ValidFuelType(i_FuelType, r_FuelType);
            Validation.ValidRange(i_FuelToAdd, k_MinFuelAmount, r_MaxFuelAmount - m_CurrentFuelAmount);
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
                Validation.ValidRange(value, k_MinFuelAmount, r_MaxFuelAmount);
                m_CurrentFuelAmount = value;
                UpdateEnergyPercentage();
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return r_MaxFuelAmount;
            }
        }

        public override void UpdateEnergyPercentage()
        {
            EnergyPercentage = CalcEnergyPercentage(m_CurrentFuelAmount, r_MaxFuelAmount);
        }

        public override string ToString()
        {
            return string.Format("Fuel Status: {0}/{1} Liters of type {2}", m_CurrentFuelAmount, r_MaxFuelAmount, r_FuelType);
        }
    }
}
