namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private ushort m_EnergyPercentage;

        public ushort EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public abstract void UpdateEnergyPercantage();

        public static ushort CalcEnergyPercantage(float i_CurrentEnergyAmount, float i_MaxEnergyAnount)
        {
            return (ushort)((i_CurrentEnergyAmount / i_MaxEnergyAnount) * 100);
        }

    }
}
