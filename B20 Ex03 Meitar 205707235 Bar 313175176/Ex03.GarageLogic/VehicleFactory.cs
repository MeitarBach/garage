using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        //// Car constants
        private const float k_ElectricCarMaxHours = 2.1f;
        private const float k_CarMaxFuel = 60f;
        private const eFuelType k_CarFuelType = eFuelType.Octane96;
        private const ushort k_CarNumOfWheels = 4;
        private const float k_CarMaxAirPressure = 32f;

        //// Motorcycle Constants
        private const float k_ElectricMotorcycleMaxHours = 1.2f;
        private const float k_MotorcycleMaxFuel = 7f;
        private const eFuelType k_MotorCycleFuelType = eFuelType.Octane95;
        private const ushort k_MotorcycleNumOfWheels = 2;
        private const float k_MotorcycleMaxAirPressure = 30f;

        //// Truck Constants
        private const float k_TruckMaxFuel = 120f;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private const ushort k_TruckNumOfWheels = 16;
        private const float k_TruckMaxAirPressure = 28f;

        public Vehicle CreateVehicle(string i_LicenseNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;
            Engine engine = createEngine(i_VehicleType);

            switch(i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelBasedCar:
                    vehicle = new Car(i_LicenseNumber, i_ModelName, engine);
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelBasedMotorcycle:
                    vehicle = new Motorcycle(i_LicenseNumber, i_ModelName, engine);
                    break;
                case eVehicleType.FuelBasedTruck:
                    vehicle = new Truck(i_LicenseNumber, i_ModelName, engine);
                    break;
            }

            addWheels(vehicle, i_VehicleType);

            return vehicle;
        }

        public void SetFieldValue(Vehicle i_Vehicle, string i_FieldKey, string i_FieldValue)
        {
            switch(i_FieldKey)
            {
                case "Current Fuel Amount":
                    float currentFuelAmount = Validation.ValidateAndParseFloat(i_FieldValue);
                    (i_Vehicle.Engine as FuelEngine).CurrentFuelAmount = currentFuelAmount;
                    break;
                case "Time left in Battery":
                    float currentTimeInBattery = Validation.ValidateAndParseFloat(i_FieldValue);
                    (i_Vehicle.Engine as FuelEngine).CurrentFuelAmount = currentTimeInBattery;
                    break;
                case "Volume of Cargo":
                    float volumeOfCargo = Validation.ValidateAndParseFloat(i_FieldValue);
                    (i_Vehicle as Truck).VolumeOfCargo = volumeOfCargo;
                    break;
                case "Wheel Pressure":
                    float wheelsPressure = Validation.ValidateAndParseFloat(i_FieldValue);
                    i_Vehicle.SetWheelsPressure(wheelsPressure);
                    break;
            }
        }

        private Engine createEngine(eVehicleType i_VehicleType)
        {
            Engine engine = null;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    engine = new ElectricEngine(k_ElectricCarMaxHours);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    engine = new ElectricEngine(k_ElectricMotorcycleMaxHours);
                    break;
                case eVehicleType.FuelBasedCar:
                    engine = new FuelEngine(k_CarFuelType, k_CarMaxFuel);
                    break;
                case eVehicleType.FuelBasedMotorcycle:
                    engine = new FuelEngine(k_MotorCycleFuelType, k_MotorcycleMaxFuel);
                    break;
                case eVehicleType.FuelBasedTruck:
                    engine = new FuelEngine(k_TruckFuelType, k_TruckMaxFuel);
                    break;
            }

            return engine;
        }

        private Dictionary<string, string> getEmptyParameterDictionary()
        {
            Dictionary<string, string> parameterDictionary =
                new Dictionary<string, string>()
                    {
                        {"Current Fuel Amount", string.Empty},
                        //{"Owner Name", string.Empty},
                        //{"Owner Phone", string.Empty},
                        //{"Wheel Manufacturer", string.Empty},
                        {"Wheel Pressure", string.Empty}
                    };

            return parameterDictionary;
        }

        private Dictionary<string, string> getEmptyParameterDictionary(eVehicleType i_VehicleType)
        {
            Dictionary<string, string> parameterDictionary = getEmptyParameterDictionary();

            switch(i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelBasedCar:
                    //parameterDictionary.Add("Color", string.Empty);
                    //parameterDictionary.Add("Number Of Doors", string.Empty);
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelBasedMotorcycle:
                    //parameterDictionary.Add("License Type", string.Empty);
                    //parameterDictionary.Add("Engine Volume", string.Empty);
                    break;
                case eVehicleType.FuelBasedTruck:
                    parameterDictionary.Add("Contains Dangerous Materials", string.Empty);
                    parameterDictionary.Add("Volume of Cargo", string.Empty);
                    break;
            }

            return parameterDictionary;
        }

        public Dictionary<string, string> GetEmptyParameterDictionary(eVehicleType i_VehicleType)
        {
            Dictionary<string, string> parameterDictionary = getEmptyParameterDictionary(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.FuelBasedCar:
                case eVehicleType.FuelBasedMotorcycle:
                case eVehicleType.FuelBasedTruck:
                    //parameterDictionary.Add("Current Fuel Amount ", string.Empty);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    parameterDictionary.Add("Time left in Battery", string.Empty);
                    break;
            }

            return parameterDictionary;
        }

        private void addWheels(Vehicle i_Vehicle, eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelBasedCar:
                    i_Vehicle.AddWheels(k_CarNumOfWheels, k_CarMaxAirPressure);
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelBasedMotorcycle:
                    i_Vehicle.AddWheels(k_MotorcycleNumOfWheels, k_MotorcycleMaxAirPressure);
                    break;
                case eVehicleType.FuelBasedTruck:
                    i_Vehicle.AddWheels(k_TruckNumOfWheels, k_TruckMaxAirPressure);
                    break;
            }
        }
    }
}
