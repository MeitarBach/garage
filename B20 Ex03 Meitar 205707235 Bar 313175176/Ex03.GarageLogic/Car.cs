﻿namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;

        public Car(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Engine)
        {
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Car Color: {1}
Number Of Doors: {2}", base.ToString(), m_Color, m_NumOfDoors);
        }
    }
}
