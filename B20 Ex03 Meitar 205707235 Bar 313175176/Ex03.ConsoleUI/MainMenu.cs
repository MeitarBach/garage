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
        private const ushort k_MaxOptionsMainMenu = 6;
        private const ushort k_MaxOptionsDisplayListOfVehiclesInGgarage = 2;
        private const ushort k_MaxOptionseVehicleStatus = 3;
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
            ushort option = getOptionFromUser(k_MaxOptionsMainMenu);

            switch(option)
            {
                case 1:
                    insertVehicle();
                    break;
                case 2:
                    DisplayListOfVehiclesIGgarage();
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

        private ushort getOptionFromUser(ushort i_MaxOptionNumber)
        {
            ushort option = 0;
            bool v_InvalidInput = true;

            while(v_InvalidInput)
            {
                if(ushort.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= i_MaxOptionNumber)
                {
                    break;
                }

                Console.Clear();
                MessageDisplayer.InvalidOptionRange(i_MaxOptionNumber);
            }

            return option;
        }

        private void insertVehicle()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.InsertLicneseNumber);
            string licenseNumber = Console.ReadLine();
            Vehicle vehicle;

            if(!r_GarageManager.FindVehicle(licenseNumber, out vehicle))
            { 
                eVehicleType vehicleType = getVehicleType(); 
                string modelName = getModelName();
                vehicle = r_VehicleFactory.CreateVehicle(licenseNumber, modelName, vehicleType);
            }

            setVehicleProperties(vehicle);
        }

        private eVehicleType getVehicleType()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.ChooseVehicleType);
            ushort option = getOptionFromUser(k_MaxOptionsMainMenu);

            ushort.TryParse(option, out vehicleTypeInput);
            

            eVehicleType vehicleType = (eVehicleType)vehicleTypeInput;
        }

        private void enterToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void DisplayListOfVehiclesIGgarage()
        {
            ushort option = getOptionFromUser(k_MaxOptionsDisplayListOfVehiclesInGgarage);
            string listOfVehiclesToDisplay;

            MessageDisplayer.DisplayMessage(InsertTypeOfListToDisplay);
            Console.Clear();
            if (option == 1)
            {
                listOfVehiclesToDisplay =  r_GarageManager.DisplayAllVehicles();
            }
            else
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InsertTypeOfSpecificList);
                listOfVehiclesToDisplay = r_GarageManager.DisplayVehiclesByStatus((eVehicleStatus)getOptionFromUser(k_MaxOptionseVehicleStatus));
            }

            Console.Clear();
            MessageDisplayer.DisplayMessage(listOfVehiclesToDisplay);
            enterToContinue();
        }
    }
}
