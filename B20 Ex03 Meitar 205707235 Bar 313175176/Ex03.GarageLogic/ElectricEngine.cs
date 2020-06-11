namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_RemainingTimeInHours;
        private readonly float r_MaxTimeInHours;

        public ElectricEngine(float i_RemainingTimeInHours, float i_MaxTimeInHours) 
            : base((ushort)((i_RemainingTimeInHours / i_MaxTimeInHours) * 100))
        {
            m_RemainingTimeInHours = i_RemainingTimeInHours;
            r_MaxTimeInHours = i_MaxTimeInHours;
        }

    }
}
