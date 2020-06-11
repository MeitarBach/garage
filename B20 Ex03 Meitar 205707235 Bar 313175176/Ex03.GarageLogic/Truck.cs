using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_ContainsDangerousMaterials;
        private float m_VolumeOfCargo;

        public Truck(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Engine)
        {
        }

        public bool ContainsDangerousMaterials
        {
            get
            {
                return m_ContainsDangerousMaterials;
            }

            set
            {
                m_ContainsDangerousMaterials = value;
            }
        }

        public float VolumeOfCargo
        {
            get
            {
                return m_VolumeOfCargo;
            }

            set
            {
                m_VolumeOfCargo = value;
            }
        }
    }
}
