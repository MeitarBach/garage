using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_WheelsList;
        private VehicleOwner m_Owner;
        private eVehicleStatus m_VehicleStatus;
        private Engine m_Engine;

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_Engine.EnergyPercentage;
            }
            set
            {
                m_Engine.EnergyPercentage = value;
            }
        }

        public Vehicle(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_ModelName;
            r_WheelsList = new List<Wheel>();
            m_Engine = i_Engine;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> WheelsList
        {
            get
            {
                return r_WheelsList;
            }
        }

        public VehicleOwner Owner
        {
            get
            {
                return m_Owner;
            }
            set
            {
                m_Owner = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        public void InflateTiresToMax()
        {
            foreach(Wheel wheel in WheelsList)
            {
                float airToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.InflateWheel(airToAdd);
            }
        }

        private string wheelsSpecification()
        {
            StringBuilder wheelsSpecifaction = new StringBuilder();
            foreach(Wheel wheel in r_WheelsList)
            {
                wheelsSpecifaction.Append(Environment.NewLine);
                wheelsSpecifaction.Append(wheel);
            }

            return wheelsSpecifaction.ToString();
        }

        public override string ToString()
        {
            string ownerName = Owner == null ? string.Empty : Owner.Name;

            string description = string.Format(
@"License Number: {0}
Model: {1}
Owner: {2}
Status: {3}
Tires specifications:{4}
{5}", r_LicenseNumber, r_ModelName, ownerName, m_VehicleStatus, wheelsSpecification(), m_Engine);

            return description;
        }
    }
}
