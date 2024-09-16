using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class CargoTests
    {
        public static void RunMe()
        {
            // Populate the items for testing
            CargoTransportConsole.items.Add(new CargoItem("Laptop", 2.5, 0.003, true, 1200));
            CargoTransportConsole.items.Add(new CargoItem("Table", 25, 1.5, false, 200));
            CargoTransportConsole.items.Add(new CargoItem("Chair", 7, 0.5, false, 50));
            // Add more items...

            CargoTransportConsole.MainMenu();  // Call the main menu
        }
    }

}

