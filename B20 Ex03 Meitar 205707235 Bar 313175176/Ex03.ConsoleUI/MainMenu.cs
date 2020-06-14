using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B20_Ex02;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class MainMenu
    {
        private const int k_MaxOptionsMainMenu = 6;
        private const int k_MaxOptionsDisplayListOfVehiclesInGgarage = 2;
        private const int k_MaxOptionseVehicleStatus = 3;
        private readonly GarageManager r_GarageManager = new GarageManager();
        private readonly VehicleFactory r_VehicleFactory = new VehicleFactory();

        internal void OpenGarage()
        {
            const bool v_GarageIsActive = true;

            MessageDisplayer.DisplayMessage(MessageDisplayer.Welcome);
            while (v_GarageIsActive)
            {
                displayOptions();
            }
        }

        private void displayOptions()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.MainMenuMessage);
            int option = getOptionFromUser(k_MaxOptionsMainMenu);

            switch (option)
            {
                case 1:
                    insertVehicle();
                    break;
                case 2:
                    //DisplayListOfVehiclesIGgarage();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }

        private int getOptionFromUser(int i_MaxOptionNumber)
        {
            int option = 0;
            bool v_InvalidInput = true;

            while (v_InvalidInput)
            {
                if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= i_MaxOptionNumber)
                {
                    break;
                }

                MessageDisplayer.InvalidOptionRange(i_MaxOptionNumber);
            }

            return option;
        }

        private void insertVehicle()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.InsertLicneseNumber);
            string licenseNumber = Console.ReadLine();
            Vehicle vehicle;

            if (!r_GarageManager.FindVehicle(licenseNumber, out vehicle))
            {
                eVehicleType vehicleType = getVehicleTypeFromUser();
                MessageDisplayer.DisplayMessage(MessageDisplayer.InsertModelName);
                string modelName = Console.ReadLine();
                vehicle = r_VehicleFactory.CreateVehicle(licenseNumber, modelName, vehicleType);
                vehicle.VehicleType = vehicleType;
                r_GarageManager.AddVehicle(vehicle);
            }
            else
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.VehicleIsInGarage);
            }

            setVehicleProperties(vehicle);
        }

        private eVehicleType getVehicleTypeFromUser()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.ChooseVehicleType);
            MessageDisplayer.ListVehicleTypes();
            int numOfVehicleTypes = Enum.GetNames(typeof(eVehicleType)).Length;
            int vehicleTypeChosen = getOptionFromUser(numOfVehicleTypes);
            eVehicleType vehicleType = (eVehicleType)vehicleTypeChosen;

            return vehicleType;
        }

        private void setVehicleProperties(Vehicle i_Vehicle)
        {
            i_Vehicle.VehicleStatus = eVehicleStatus.InRepair;
            setEnergy(i_Vehicle);
            setWheels(i_Vehicle);

            switch(i_Vehicle.VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.FuelBasedCar:
                    setColor(i_Vehicle);
                    setNumOfDoors(i_Vehicle);
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.FuelBasedMotorcycle:
                    setLicenseType(i_Vehicle);
                    setEngineVolume(i_Vehicle);
                    break;
                case eVehicleType.FuelBasedTruck:
                    setDangerousMaterials(i_Vehicle);
            }

            setOwner(i_Vehicle);
        }

        AskForAdditionalInfo(eVehicleType i_VehicleType)
        {
            List<string> aditionalParmas = r_VehicleFactory.WhatToAskFor(i_VehicleType);
            foreach(string paramKey in aditionalParmas)
            {
                MessageDisplayer.DisplayMessage(string.Format("Please enter {0}:", paramKey));
                string paramValue = Console.ReadLine();
                r_VehicleFactory.SendParameter(i_VehicleType, paramKey, paramValue);
            }
        }

        private void enterToContinue()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        //public void DisplayListOfVehiclesIGgarage()
        //{
        //    int option = getOptionFromUser(k_MaxOptionsDisplayListOfVehiclesInGgarage);
        //    string listOfVehiclesToDisplay;

        //    MessageDisplayer.DisplayMessage(InsertTypeOfListToDisplay);
        //    Console.Clear();
        //    if (option == 1)
        //    {
        //        listOfVehiclesToDisplay = r_GarageManager.DisplayAllVehicles();
        //    }
        //    else
        //    {
        //        MessageDisplayer.DisplayMessage(MessageDisplayer.InsertTypeOfSpecificList);
        //        listOfVehiclesToDisplay = r_GarageManager.DisplayVehiclesByStatus((eVehicleStatus)getOptionFromUser(k_MaxOptionseVehicleStatus));
        //    }

        //    Console.Clear();
        //    MessageDisplayer.DisplayMessage(listOfVehiclesToDisplay);
        //    enterToContinue();
        //}
    }
}
