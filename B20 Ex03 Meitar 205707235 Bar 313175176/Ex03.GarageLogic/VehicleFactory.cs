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
                case "Owner Name":
                    i_Vehicle.Owner.Name = i_FieldValue;
                    break;
                case "Owner Phone Number":
                    i_Vehicle.Owner.PhoneNumber = i_FieldValue;
                    break;
                case "Wheels Manufacturer":
                    i_Vehicle.SetWheelsManufacturer(i_FieldValue);
                    break;
                case "Wheels Pressure":
                    float wheelsPressure = Validation.ValidateAndParseFloat(i_FieldValue);
                    i_Vehicle.SetWheelsPressure(wheelsPressure);
                    break;
                case "Current Fuel Amount":
                    float currentFuelAmount = Validation.ValidateAndParseFloat(i_FieldValue);
                    (i_Vehicle.Engine as FuelEngine).CurrentFuelAmount = currentFuelAmount;
                    break;
                case "Time left in Battery":
                    float currentTimeInBattery = Validation.ValidateAndParseFloat(i_FieldValue);
                    (i_Vehicle.Engine as ElectricEngine).RemainingTimeInHours = currentTimeInBattery;
                    break;
                case "Color":
                    eColor color = Validation.ValidateAndParseEnum<eColor>(i_FieldValue);
                    (i_Vehicle as Car).Color = color;
                    break;
                case "Number Of Doors":
                    eNumOfDoors numOfDoors = Validation.ValidateAndParseEnum<eNumOfDoors>(i_FieldValue);
                    (i_Vehicle as Car).NumOfDoors = numOfDoors;
                    break;
                case "License Type":
                    eLicenseType licenseType = Validation.ValidateAndParseEnum<eLicenseType>(i_FieldValue);
                    (i_Vehicle as Motorcycle).LicenseType = licenseType;
                    break;
                case "Engine Volume":
                    int engineVolume = Validation.ValidateAndParseInt(i_FieldValue);
                    (i_Vehicle as Motorcycle).EngineVolume = engineVolume;
                    break;
                case "if it Contains Dangerous Materials":
                    bool containsDangerousMaterials = Validation.ValidateAndParseBool(i_FieldValue);
                    (i_Vehicle as Truck).ContainsDangerousMaterials = containsDangerousMaterials;
                    break;
                case "Volume of Cargo":
                    float volumeOfCargo = Validation.ValidateAndParseFloat(i_FieldValue);
                    (i_Vehicle as Truck).VolumeOfCargo = volumeOfCargo;
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

        private List<string> getBasicParametersList(eVehicleType i_VehicleType)
        {
            //// Basic user display parameters
            List<string> parameterList =
                new List<string>() { "Owner Name", "Owner Phone Number", "Wheels Manufacturer", "Wheels Pressure" };

            switch (i_VehicleType)
            {
                case eVehicleType.FuelBasedCar:
                case eVehicleType.FuelBasedMotorcycle:
                case eVehicleType.FuelBasedTruck:
                    parameterList.Add("Current Fuel Amount");
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    parameterList.Add("Time left in Battery");
                    break;
            }

            return parameterList;
        }

        public List<string> GetExtendedParametersList(eVehicleType i_VehicleType)
        {
            //// Basic user display parameters + specific parameters for each vehicle
            List<string> parameterList = getBasicParametersList(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelBasedCar:
                    parameterList.Add("Color");
                    parameterList.Add("Number Of Doors");
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelBasedMotorcycle:
                    parameterList.Add("License Type");
                    parameterList.Add("Engine Volume");
                    break;
                case eVehicleType.FuelBasedTruck:
                    parameterList.Add("if it Contains Dangerous Materials");
                    parameterList.Add("Volume of Cargo");
                    break;
            }

            return parameterList;
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
