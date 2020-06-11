using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private readonly string m_ModelName;
        private readonly string m_LicenseNumber;
        private float m_RemainingEnergyPercantage;
        private readonly List<Wheel> m_WheelsList;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Engine m_Engine;

        public Vehicle()
        {
            
        }
    }
}
