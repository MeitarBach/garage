﻿namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private readonly eNumOfDoors r_NumOfDoors;

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
                return r_NumOfDoors;
            }
        }
    }
}
