using System;
using System.Collections.Generic;
using System.Threading;
using B20_Ex02;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class MainMenu
    {
        private const int k_MenuNumberOfOptions = 7;
        private const int k_TwoOptions = 2;
        private const bool k_EnumListWithNumbers = true;
        private readonly int r_NumOfVehicleStatuses = Enum.GetNames(typeof(eVehicleStatus)).Length;
        private readonly int r_NumOfFuelTypes = Enum.GetNames(typeof(eFuelType)).Length;
        private readonly GarageManager r_GarageManager = new GarageManager();
        private readonly VehicleFactory r_VehicleFactory = new VehicleFactory();

        internal void OpenGarage()
        {
            bool garageIsActive = true;

            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.Welcome);
            while (garageIsActive)
            {
                garageIsActive = displayOptions();
                Console.Clear();
            }

            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.GoodBye);
            Thread.Sleep(2000);
        }

        private bool displayOptions()
        {
            Console.WriteLine(MessageDisplayer.MainMenuMessage);
            int option = getOptionFromUser(k_MenuNumberOfOptions);
            bool userWantToStay = true;

            switch (option)
            {
                case 1:
                    insertVehicle();
                    break;
                case 2:
                    displayListOfVehiclesInGarage();
                    break;
                case 3:
                    changeVehicleStatus();
                    break;
                case 4:
                    inflateAllTiresToMax();
                    break;
                case 5:
                    fillEnergy();
                    break;
                case 6:
                    displayVehicleInformation();
                    break;
                case 7:
                    userWantToStay = !userWantToStay;
                    break;
            }

            return userWantToStay;
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
            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.InsertLicneseNumber);
            string licenseNumber = Console.ReadLine();
            Vehicle vehicle;

            if (!r_GarageManager.FindVehicle(licenseNumber, out vehicle))
            {
                eVehicleType vehicleType = getVehicleTypeFromUser();
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.InsertModelName);
                string modelName = Console.ReadLine();
                vehicle = r_VehicleFactory.CreateVehicle(licenseNumber, modelName, vehicleType);
                vehicle.VehicleType = vehicleType;
                r_GarageManager.AddVehicle(vehicle);
            }
            else
            {
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.VehicleIsInGarage);
            }

            setVehicleProperties(vehicle);
        }

        private eVehicleType getVehicleTypeFromUser()
        {
            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.ChooseVehicleType);
            Console.WriteLine(EnumOperations.ListEnumValues<eVehicleType>(k_EnumListWithNumbers));
            int numOfVehicleTypes = Enum.GetNames(typeof(eVehicleType)).Length;
            int vehicleTypeChosen = getOptionFromUser(numOfVehicleTypes);
            eVehicleType vehicleType = (eVehicleType)vehicleTypeChosen;

            return vehicleType;
        }

        private void setVehicleProperties(Vehicle i_Vehicle)
        {
            i_Vehicle.VehicleStatus = eVehicleStatus.InRepair;
            List<string> parametersList = r_VehicleFactory.GetExtendedParametersList(i_Vehicle.VehicleType);

            foreach (string parameterKey in parametersList)
            {
                bool v_InvalidInput = true;

                while(v_InvalidInput)
                {
                    Console.WriteLine("Please enter {0}:", parameterKey);
                    string parameterValue = Console.ReadLine();

                    try
                    {
                        r_VehicleFactory.SetFieldValue(i_Vehicle, parameterKey, parameterValue);
                        break;
                    }
                    catch(ValueOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.InsertedVehicle);
            Console.WriteLine(i_Vehicle.ToString());
            enterToContinue();
        }

        private void enterToContinue()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private void printAndEnterToContinue(string i_Msg)
        {
            MessageDisplayer.ClearAndDisplayMessage(i_Msg);
            enterToContinue();
        }

        private void displayListOfVehiclesInGarage()
        {
            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.SelectListType);
            int option = getOptionFromUser(k_TwoOptions);
            string listOfVehiclesToDisplay = string.Empty;

            switch (option)
            {
                case 1:
                    listOfVehiclesToDisplay = r_GarageManager.DisplayAllVehicles();
                    break;
                case 2:
                    MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.SelectSpecificList);
                    Console.WriteLine(EnumOperations.ListEnumValues<eVehicleStatus>(k_EnumListWithNumbers));
                    eVehicleStatus statusOfVehiclesToShow = (eVehicleStatus)getOptionFromUser(r_NumOfVehicleStatuses);
                    listOfVehiclesToDisplay = r_GarageManager.DisplayVehiclesByStatus(statusOfVehiclesToShow);
                    break;
            }

            if(listOfVehiclesToDisplay == string.Empty)
            {
                listOfVehiclesToDisplay = MessageDisplayer.EmptyList;
            }

            printAndEnterToContinue(listOfVehiclesToDisplay);
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = insertLicenseNumber();
            Vehicle vehicle;

            if (r_GarageManager.FindVehicle(licenseNumber, out vehicle))
            {
                bool v_InvalidInput = true;

                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.SelectVehicleStatus);
                Console.WriteLine(EnumOperations.ListEnumValues<eVehicleStatus>(k_EnumListWithNumbers));
                while (v_InvalidInput)
                {
                    int newStatus = getOptionFromUser(r_NumOfVehicleStatuses);
                    try
                    {
                        r_GarageManager.ChangeVehicleStatus(licenseNumber, (eVehicleStatus)newStatus);
                        MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.StatusHasBeenChanged);
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.VehicleIsNotInGarage);
            }

            enterToContinue();
        }

        private void inflateAllTiresToMax()
        {
            string licenseNumber = insertLicenseNumber();
            bool filledTiresSuccesfully = r_GarageManager.FillTiresToMaximum(licenseNumber);
            string succeededToFillAllTires = filledTiresSuccesfully ? 
                                                 MessageDisplayer.FilledAllTires : MessageDisplayer.VehicleIsNotInGarage;

            printAndEnterToContinue(succeededToFillAllTires);
        }

        private void fillEnergy()
        {
            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.RefuelOrRecharge);
            int option = getOptionFromUser(k_TwoOptions);
            string licenseNumber = insertLicenseNumber();

            if (r_GarageManager.FindVehicle(licenseNumber, out Vehicle vehicle))
            {
                switch(option)
                {
                    case 1:
                        refuleVehicle(licenseNumber);
                        break;
                    case 2:
                        rechargeVehicle(licenseNumber);
                        break;
                }
            }
            else
            {
                 MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.VehicleIsNotInGarage);
            }
        }

        private void refuleVehicle(string i_LicenseNumber)
        {
            try
            {
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.SelectFuelType);
                Console.WriteLine(EnumOperations.ListEnumValues<eFuelType>(k_EnumListWithNumbers));
                eFuelType fuelChoice = (eFuelType)getOptionFromUser(r_NumOfFuelTypes);
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.EnterFuelAmount);
                float fuelToAdd;

                while(!float.TryParse(Console.ReadLine(), out fuelToAdd))
                {
                    Console.WriteLine(MessageDisplayer.InvalidNumberInserted);
                }

                r_GarageManager.RefuleVehicle(i_LicenseNumber, fuelChoice, fuelToAdd);
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.RefueledSuccessfully);
            }
            catch(Exception e)
            {
                MessageDisplayer.ClearAndDisplayMessage(e.Message);
            }
            
            enterToContinue();
        }

        private void rechargeVehicle(string i_LicenseNumber)
        {
            try
            {
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.EnterMinutesToCharge);
                float minutesToCharge;

                while (!float.TryParse(Console.ReadLine(), out minutesToCharge))
                {
                    Console.WriteLine(MessageDisplayer.InvalidNumberInserted);
                }

                r_GarageManager.RechargeVehicle(i_LicenseNumber, minutesToCharge);
                MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.RechargedSuccesfully);
            }
            catch (Exception e)
            {
                MessageDisplayer.ClearAndDisplayMessage(e.Message);
            }

            enterToContinue();
        }

        private void displayVehicleInformation()
        {
            string licenseNumber = insertLicenseNumber();
            Vehicle vehicle;
            string vehicleDescription = r_GarageManager.FindVehicle(licenseNumber, out vehicle)
                                            ? vehicle.ToString()
                                            : MessageDisplayer.VehicleIsNotInGarage;

            printAndEnterToContinue(vehicleDescription);
        }

        private string insertLicenseNumber()
        {
            MessageDisplayer.ClearAndDisplayMessage(MessageDisplayer.InsertLicneseNumber);
            return Console.ReadLine();
        }
    }
}
