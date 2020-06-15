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
        private const int k_SixOptions = 6;
        private const int k_TwoOptions = 2;
        private const int k_ThreeOptions = 3;
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
            int option = getOptionFromUser(k_SixOptions);

            switch (option)
            {
                case 1:
                    insertVehicle();
                    break;
                case 2:
                    DisplayListOfVehiclesInGgarage();
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
            MessageDisplayer.ListEnumValues<eVehicleType>();
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

            MessageDisplayer.DisplayMessage(MessageDisplayer.InsertedVehicle);
            Console.WriteLine(i_Vehicle.ToString());
            enterToContinue();
        }

        private void enterToContinue()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void DisplayListOfVehiclesInGgarage()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.SortedOrUnsortedList);
            int option = getOptionFromUser(k_TwoOptions);
            string listOfVehiclesToDisplay;

            switch(option)
            {
                case 1:
                    listOfVehiclesToDisplay = r_GarageManager.DisplayAllVehicles();
                    break;
                case 2:
                    MessageDisplayer.DisplayMessage(MessageDisplayer.InsertTypeOfSpecificList);
                    listOfVehiclesToDisplay =
                        r_GarageManager.DisplayVehiclesByStatus((eVehicleStatus)getOptionFromUser(k_ThreeOptions));
                    break;
            }

            MessageDisplayer.DisplayMessage(listOfVehiclesToDisplay);
            enterToContinue();
        }
    }
}
