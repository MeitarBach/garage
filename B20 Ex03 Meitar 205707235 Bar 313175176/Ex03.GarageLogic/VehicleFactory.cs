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
