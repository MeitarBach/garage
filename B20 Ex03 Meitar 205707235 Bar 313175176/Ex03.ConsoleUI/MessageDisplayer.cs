using System;
using System.Text;
using Ex03.GarageLogic;

namespace B20_Ex02
{
    internal class MessageDisplayer
    {
        private const string k_Welcome = "Welcome to Meitar&Bar's Garage!";
        private const string k_MainMenuMessage =
@"What would you like to do? (choose an option between 1-6)
1. Insert a new vehicle to the garage
2. Display a list of the vehicles in the garage
3. Change a certain vehicle's status
4. Inflate vehicle's tires to maximum
5. Fill vehicle energy source (fuel or electric)
6. Display vehicle information";
        private const string k_InsertLicneseNumber = "Insert vehicle License Number";
        private const string k_ChooseVehicleType = "Choose your vehicle type:";
        private const string k_InsertModelName = "Insert vehicle's Model:";
        private const string k_VehicleIsInGarage = "The vehicle is already in the garage";
        private const string k_InsertedVehicle = "The vehicle was successfully inserted:";
        private const string k_EnterBoardHeight = "Please enter the board's height: (4-6)";
        private const string k_NotANumber = "Invalid input: Not a Number";
        private const string k_InvalidWidth = "Invalid Width: Not in range 4-6";
        private const string k_InvalidHeight = "Invalid Height: Not in range 4-6";
        private const string k_InvalidSize = "Invalid Size: Width X Height is not even";
        private const string k_Turn = "'s turn:";
        private const string k_EnterMove = "Enter a cell (i.e: B3) or Q to exit";
        private const string k_InvalidMoveSyntaxError = "Invalid move: Enter a cell in the correct syntax (i.e: B3) or Q to exit";
        private const string k_InvalidMoveOutOfRange = "Invalid move: You entered a cell which is not in the board's range";
        private const string k_InvalidMoveCellRevealed = "Invalid move: You entered a cell which is revealed";
        private const string k_TheWinnerIs = "The winner is: ";
        private const string k_CongratulationsToWinner = "$$$ Congratulations to the winner $$$";
        private const string k_Draw = "It's a draw, maybe next time we'll have a winner :-(";
        private const string k_PlayAnotherGame = "Play another game? insert: YES/NO";
        private const string k_InvalidPlayAnotherGame = "Invalid input: insert: YES/NO";
        private const string k_GoodBye = "Thanks for playing, See you later :-)";

        internal static void InvalidOptionRange(int i_MaxOptionNumber)
        {
            Console.WriteLine("Invalid option range, choose an option between 1-{0}", i_MaxOptionNumber);
        }

        internal static void ListEnumValues<T>()
        {
            StringBuilder enumValuesStringBuilder = new StringBuilder(); 
            string[] enumValues = Enum.GetNames(typeof(T));

            for(int i = 0 ; i < enumValues.Length ; i++)
            {
                enumValuesStringBuilder.Append(string.Format("{0}. {1}", i + 1, enumValues[i]));
                if(enumValues.Length - 1 != i)
                {
                    enumValuesStringBuilder.Append(Environment.NewLine);
                }
            }

            Console.WriteLine(enumValuesStringBuilder.ToString());
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
        
        internal static string InsertLicneseNumber
        {
            get
            {
                return k_InsertLicneseNumber;
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

        internal static string EnterBoardHeight
        {
            get
            {
                return k_EnterBoardHeight;
            }
        }

        internal static string NotANumber
        {
            get
            {
                return k_NotANumber;
            }
        }

        internal static string InvalidWidth
        {
            get
            {
                return k_InvalidWidth;
            }
        }

        internal static string InvalidHeight
        {
            get
            {
                return k_InvalidHeight;
            }
        }
        
        internal static string InvalidSize
        {
            get
            {
                return k_InvalidSize;
            }
        }

        internal static string Turn
        {
            get
            {
                return k_Turn;
            }
        }
        
        internal static string EnterMove
        {
            get
            {
                return k_EnterMove;
            }
        }

        internal static string InvalidMoveOutOfRange
        {
            get
            {
                return k_InvalidMoveOutOfRange;
            }
        }
        
        internal static string InvalidMoveSyntaxError
        {
            get
            {
                return k_InvalidMoveSyntaxError;
            }
        }

        internal static string InvalidMoveCellRevealed
        {
            get
            {
                return k_InvalidMoveCellRevealed;
            }
        }

        internal static string TheWinnerIs
        {
            get
            {
                return k_TheWinnerIs;
            }
        }

        internal static string CongratulationsToWinner
        {
            get
            {
                return k_CongratulationsToWinner;
            }
        }

        internal static string Draw
        {
            get
            {
                return k_Draw;
            }
        }

        internal static string PlayAnotherGame
        {
            get
            {
                return k_PlayAnotherGame;
            }
        }

        internal static string InvalidPlayAnotherGame
        {
            get
            {
                return k_InvalidPlayAnotherGame;
            }
        }

        internal static string GoodBye
        {
            get
            {
                return k_GoodBye;
            }
        }

        internal static void DisplayMessage(string i_Msg)
        {
            Console.Clear();
            Console.WriteLine(i_Msg);
        }
    }
}
