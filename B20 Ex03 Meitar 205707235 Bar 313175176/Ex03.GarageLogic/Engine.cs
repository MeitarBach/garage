namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_EnergyPercentage;

        public float EnergyPercentage
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

        public static float CalcEnergyPercentage(float i_CurrentEnergyAmount, float i_MaxEnergyAmount)
        {
            return (i_CurrentEnergyAmount / i_MaxEnergyAmount) * 100;
        }

        public abstract void UpdateEnergyPercentage();
    }
}
