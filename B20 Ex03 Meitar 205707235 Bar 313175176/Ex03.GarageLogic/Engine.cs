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

        public abstract void UpdateEnergyPercantage();

        public static float CalcEnergyPercantage(float i_CurrentEnergyAmount, float i_MaxEnergyAnount)
        {
            return (i_CurrentEnergyAmount / i_MaxEnergyAnount) * 100;
        }
    }
}
