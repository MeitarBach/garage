using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class MainMenu
    {
        private void run()
        {
            while(true)
            {
                displayOptions();
            }
        }


        private void displayOptions()
        {
            string option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    break;
                case "2":
                    break;
            }
        }



        private void enterToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
