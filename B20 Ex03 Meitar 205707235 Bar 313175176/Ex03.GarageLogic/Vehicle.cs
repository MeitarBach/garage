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
        private eVehicleType m_VehicleType;
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
            m_Owner = new VehicleOwner();
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

        public void AddWheels(int i_NumOfWheels, float i_WheelMaxPressure)
        {
            for(int i = 0; i < i_NumOfWheels; i++)
            {
                r_WheelsList.Add(new Wheel(i_WheelMaxPressure));
            }
        }

        public void SetWheelsPressure(float i_CurrentPressure)
        {
            foreach(Wheel wheel in r_WheelsList)
            {
                wheel.CurrentAirPressure = i_CurrentPressure;
            }
        }

        public void SetWheelsManufacturer(string i_WheelsManufacturer)
        {
            foreach (Wheel wheel in r_WheelsList)
            {
                wheel.Manufacturer = i_WheelsManufacturer;
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

        public eVehicleType VehicleType
        {
            get
            {
                return m_VehicleType;
            }

            set
            {
                m_VehicleType = value;
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
                wheelsSpecifaction.Append("\t");
                wheelsSpecifaction.Append(wheel);
            }

            return wheelsSpecifaction.ToString();
        }

        public override string ToString()
        {
            string ownerName = Owner == null ? string.Empty : Owner.Name;
            string description = string.Format(
@"License Number: {0}
Vehicle Type: {1}
Model: {2}
Owner: {3}
Status: {4}
Tires specifications:{5}
{6}
Energy Percentage: {7:0.00}%", r_LicenseNumber, m_VehicleType, r_ModelName, ownerName, m_VehicleStatus, wheelsSpecification(), m_Engine, RemainingEnergyPercentage);

            return description;
        }
    }
}
