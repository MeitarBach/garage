using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_Garage = new Dictionary<string, Vehicle>();

        public bool FindVehicle(string i_LicenseNumber, out Vehicle o_Vehicle)
        {
            return r_Garage.TryGetValue(i_LicenseNumber, out o_Vehicle);
        }

        public bool AddVehicle(Vehicle i_Vehicle)
        {
            //// Vehicle is added successfully only if it's not in the garage already
            bool addedVehicle = !r_Garage.ContainsKey(i_Vehicle.LicenseNumber);

            if(addedVehicle)
            {
                r_Garage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
            }

            return addedVehicle;
        }

        public string DisplayVehiclesByStatus(eVehicleStatus i_Status)
        {
            StringBuilder vehiclesStringBuilder = new StringBuilder();

            foreach(Vehicle vehicle in r_Garage.Values)
            {
                if(vehicle.VehicleStatus == i_Status)
                {
                    vehiclesStringBuilder.Append(Environment.NewLine);
                    vehiclesStringBuilder.Append(vehicle.LicenseNumber);
                }
            }

            return vehiclesStringBuilder.ToString();
        }

        public string DisplayAllVehicles()
        {
            StringBuilder vehiclesStringBuilder = new StringBuilder();
            foreach(eVehicleStatus vehicleStatus in Enum.GetValues(typeof(eVehicleStatus)))
            {
                vehiclesStringBuilder.Append(DisplayVehiclesByStatus(vehicleStatus));
            }

            return vehiclesStringBuilder.ToString();
        }

        public bool ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            Vehicle vehicle;
            bool vehicleInGarage = FindVehicle(i_LicenseNumber, out vehicle);

            if(vehicleInGarage)
            {
                vehicle.VehicleStatus = i_NewStatus;
            }

            return vehicleInGarage;
        }

        public bool FillTiresToMaximum(string i_LicenseNumber)
        {
            Vehicle vehicle;
            bool vehicleInGarage = FindVehicle(i_LicenseNumber, out vehicle);

            if (vehicleInGarage)
            {
                vehicle.InflateTiresToMax();
            }

            return vehicleInGarage;
        }

        public bool RefuleVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            Vehicle vehicle;
            bool vehicleInGarage = FindVehicle(i_LicenseNumber, out vehicle);

            Validation.ValidFuelVehicle(vehicle);
            (vehicle.Engine as FuelEngine).Refuel(i_FuelAmountToAdd, i_FuelType);

            return vehicleInGarage;
        }

        public bool RechargeVehicle(string i_LicenseNumber, float i_MintuesToCharge)
        {
            Vehicle vehicle;
            bool vehicleInGarage = FindVehicle(i_LicenseNumber, out vehicle);

            Validation.ValidElectricVehicle(vehicle);
            float hoursToCharge = i_MintuesToCharge / 60;
            (vehicle.Engine as ElectricEngine).Recharge(hoursToCharge);

            return vehicleInGarage;
        }

        public string GetVehicleDescription(string i_LicneseNumber) // Maybe in UI
        {
            Vehicle vehicle;
            string vehicleDescription = "Vehicle is not in garage";

            if(FindVehicle(i_LicneseNumber, out vehicle))
            {
                vehicleDescription = vehicle.ToString();
            }

            return vehicleDescription;
        }
    }
}
