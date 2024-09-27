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
            CargoTransportConsole.items.Add(new CargoItem("Cloth", 0.2, 0.003, false, 20));     
            CargoTransportConsole.items.Add(new CargoItem("Phone", 0.5, 0.002, true, 800));     
            CargoTransportConsole.items.Add(new CargoItem("Galaxy Phone", 0.6, 0.002, true, 900)); 
            CargoTransportConsole.items.Add(new CargoItem("Flashlight", 0.3, 0.001, false, 30)); 
            CargoTransportConsole.items.Add(new CargoItem("Computer", 7, 0.5, true, 1500));     
            CargoTransportConsole.items.Add(new CargoItem("Glasses", 0.1, 0.0005, true, 100));  
            CargoTransportConsole.items.Add(new CargoItem("Pencil", 0.02, 0.0001, false, 1));  
            CargoTransportConsole.items.Add(new CargoItem("Shoes", 1, 0.004, false, 80));       
            CargoTransportConsole.items.Add(new CargoItem("Jeans", 0.5, 0.003, false, 50));     
            CargoTransportConsole.items.Add(new CargoItem("Belt", 0.2, 0.001, false, 20));      
            CargoTransportConsole.items.Add(new CargoItem("Plate", 1, 0.002, true, 30));       
            CargoTransportConsole.items.Add(new CargoItem("Hat", 0.1, 0.0008, false, 25));


            CargoTransportConsole.MainMenu();  // Call the main menu
        }
    }

}

