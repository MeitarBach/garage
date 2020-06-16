using System;

namespace B20_Ex02
{
    internal class Messages
    {
        private const string k_Welcome = "Welcome to Meitar&Bar's Garage!";
        private const string k_MainMenuMessage =
@"What would you like to do? (choose an option between 1-6)
1. Insert a new vehicle to the garage
2. Display a list of the vehicles in the garage
3. Change a certain vehicle's status
4. Inflate vehicle's tires to maximum
5. Fill vehicle energy source (fuel or electric)
6. Display vehicle information
7. Exit";
        private const string k_InsertLicenseNumber = "Insert vehicle License Number";
        private const string k_ChooseVehicleType = "Choose your vehicle type:";
        private const string k_InsertModelName = "Insert vehicle's Model:";
        private const string k_VehicleIsInGarage = "The vehicle is already in the garage";
        private const string k_InsertedVehicle = "The vehicle was successfully inserted:";
        private const string k_SelectVehicleStatus = "Please select vehicle status:";
        private const string k_VehicleIsNotInGarage = "The vehicle is not in the garage";
        private const string k_SelectListType =
@"Please select the type of list to display:
1. A list of all vehicles in the garage
2. A list of vehicles sorted by status";
        private const string k_SelectSpecificList = "Please select the type of specific list";
        private const string k_StatusHasBeenChanged = "The vehicle status has been changed";
        private const string k_FilledAllTires = "All tires have been filled to maximum";
        private const string k_EmptyList = "There are no vehicles on this list";
        private const string k_InvalidNumberInserted = "Invalid input. Please enter a number";
        private const string k_RefuelOrRecharge =
@"Would you like to refuel or recharge a vehicle?
1. Refuel
2. Recharge";
        private const string k_SelectFuelType = "Choose the type of fuel:";
        private const string k_EnterFuelAmount = "Enter fuel amount in Liters:";
        private const string k_RefueledSuccessfully = "The vehicle was succesfully refueled";
        private const string k_EnterMinutesToCharge = "Enter desired time to charge in minutes:";
        private const string k_RechargedSuccesfully = "The vehicle was succesfully recharged";
        private const string k_GoodBye = "The garage is closed, have a nice day :-)";

        internal static void InvalidOptionRange(int i_MaxOptionNumber)
        {
            Console.WriteLine("Invalid option range, choose an option between 1-{0}", i_MaxOptionNumber);
        }

        internal static string Welcome
        {
            get
            {
                return k_Welcome;
            }
        }
        
        internal static string MainMenuMessage
        {
            get
            {
                return k_MainMenuMessage;
            }
        }
        
        internal static string InsertLicenseNumber
        {
            get
            {
                return k_InsertLicenseNumber;
            }
        }
        
        internal static string ChooseVehicleType
        {
            get
            {
                return k_ChooseVehicleType;
            }
        }
        
        internal static string InsertModelName
        {
            get
            {
                return k_InsertModelName;
            }
        }
        
        internal static string VehicleIsInGarage
        {
            get
            {
                return k_VehicleIsInGarage;
            }
        }

        internal static string InsertedVehicle
        {
            get
            {
                return k_InsertedVehicle;
            }
        }

        internal static string SelectVehicleStatus
        {
            get
            {
                return k_SelectVehicleStatus;
            }
        }

        internal static string VehicleIsNotInGarage
        {
            get
            {
                return k_VehicleIsNotInGarage;
            }
        }

        internal static string SelectListType
        {
            get
            {
                return k_SelectListType;
            }
        }

        internal static string SelectSpecificList
        {
            get
            {
                return k_SelectSpecificList;
            }
        }
        
        internal static string StatusHasBeenChanged
        {
            get
            {
                return k_StatusHasBeenChanged;
            }
        }

        internal static string FilledAllTires
        {
            get
            {
                return k_FilledAllTires;
            }
        }
        
        internal static string EmptyList
        {
            get
            {
                return k_EmptyList;
            }
        }

        internal static string RefuelOrRecharge
        {
            get
            {
                return k_RefuelOrRecharge;
            }
        }
        
        internal static string InvalidNumberInserted
        {
            get
            {
                return k_InvalidNumberInserted;
            }
        }

        internal static string SelectFuelType
        {
            get
            {
                return k_SelectFuelType;
            }
        }

        internal static string EnterFuelAmount
        {
            get
            {
                return k_EnterFuelAmount;
            }
        }

        internal static string RefueledSuccessfully
        {
            get
            {
                return k_RefueledSuccessfully;
            }
        }

        internal static string EnterMinutesToCharge
        {
            get
            {
                return k_EnterMinutesToCharge;
            }
        }

        internal static string RechargedSuccesfully
        {
            get
            {
                return k_RechargedSuccesfully;
            }
        }

        internal static string GoodBye
        {
            get
            {
                return k_GoodBye;
            }
        }

        internal static void ClearAndDisplayMessage(string i_Msg)
        {
            Console.Clear();
            Console.WriteLine(i_Msg);
        }
    }
}
