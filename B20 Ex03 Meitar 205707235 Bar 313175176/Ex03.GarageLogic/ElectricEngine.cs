namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_RemainingTimeInHours;
        private readonly float r_MaxTimeInHours;
        private const float k_MinTimeInHours = 0;

        public ElectricEngine(float i_RemainingTimeInHours, float i_MaxTimeInHours) 
        {
            if(i_RemainingTimeInHours > i_MaxTimeInHours)
            {
                throw new ValueOutOfRangeException(i_RemainingTimeInHours, k_MinTimeInHours, i_MaxTimeInHours);
            }

            m_RemainingTimeInHours = i_RemainingTimeInHours;
            r_MaxTimeInHours = i_MaxTimeInHours;
            EnergyPercentage = CalcEnergyPercantage(i_RemainingTimeInHours, i_MaxTimeInHours);
        }

        public void Recharge(float i_HoursToCharge)
        {
            Validation.ValidRange(i_HoursToCharge, k_MinTimeInHours, r_MaxTimeInHours);
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
    }
}
