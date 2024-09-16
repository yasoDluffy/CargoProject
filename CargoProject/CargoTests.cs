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
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Cargo Transport Manager - Console Interface");
                Console.ResetColor();
                Console.WriteLine("1. Show sample table of 15 items ready for shipment");
                Console.WriteLine("2. Create a custom shipment");
                Console.WriteLine("0. Exit");
                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowSampleShipmentTable();
                        break;
                    case "2":
                        CreateCustomShipment();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        public static void ShowSampleShipmentTable()
        {
            List<IPortable> items = new List<IPortable>
            {
                new CargoItem("Chair", 50, 20),
                new CargoItem("Table", 100, 50),
                new CargoItem("Fridge", 300, 200),
                new CargoItem("Television", 20, 15),
                new CargoItem("Sofa", 500, 300),
                new CargoItem("Microwave", 30, 20),
                new CargoItem("Air Conditioner", 200, 150),
                new CargoItem("Bed", 150, 100),
                new CargoItem("Lamp", 10, 5),
                new CargoItem("Desk", 120, 70),
                new CargoItem("Oven", 180, 120),
                new CargoItem("Washing Machine", 400, 250),
                new CargoItem("Dryer", 350, 220),
                new CargoItem("Dishwasher", 200, 180),
                new CargoItem("Wardrobe", 600, 350)
            };

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Sample Shipment Items (15 Items):");
            Console.ResetColor();
            Console.WriteLine("+-----------------+-------------+-------------+");
            Console.WriteLine("| Item Name       | Weight (kg) | Volume (m³) |");
            Console.WriteLine("+-----------------+-------------+-------------+");

            foreach (var item in items)
            {
                // Access the weight and volume through the methods
                Console.WriteLine($"| {item.Name,-15} | {item.GetWeight(),11} | {item.GetVolume(),11} |");
            }

            Console.WriteLine("+-----------------+-------------+-------------+");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        public static void CreateCustomShipment()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Create a Custom Shipment");
            Console.ResetColor();

            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter item weight (kg): ");
            double itemWeight = double.Parse(Console.ReadLine());

            Console.Write("Enter item volume (m³): ");
            double itemVolume = double.Parse(Console.ReadLine());

            Console.Write("Enter current port: ");
            string currentPortName = Console.ReadLine();
            Port currentPort = new Port(currentPortName);

            Console.Write("Enter destination port: ");
            string destinationPortName = Console.ReadLine();
            Port destinationPort = new Port(destinationPortName);

            Console.WriteLine("Choose a cargo vehicle type:");
            Console.WriteLine("1. Cargo Ship");
            Console.WriteLine("2. Cargo Train");
            Console.WriteLine("3. Cargo Plane");
            string vehicleChoice = Console.ReadLine();

            CargoVehicle vehicle;

            switch (vehicleChoice)
            {
                case "1":
                    vehicle = new CargoShip("Captain", 2000, 1000, currentPort);
                    break;
                case "2":
                    vehicle = new CargoTrain("Engineer", 1000, 500, currentPort);
                    break;
                case "3":
                    vehicle = new CargoPlane("Pilot", 1500, 700, currentPort);
                    break;
                default:
                    Console.WriteLine("Invalid choice, returning to main menu.");
                    return;
            }

            IPortable item = new CargoItem(itemName, itemWeight, itemVolume);
            bool loadSuccess = vehicle.Load(item);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Shipment Details:");
            Console.ResetColor();
            Console.WriteLine("+-----------------------+-----------------------+");
            Console.WriteLine("| Current Port          | Destination Port       |");
            Console.WriteLine("+-----------------------+-----------------------+");
            Console.WriteLine($"| {currentPort.PortName,-21} | {destinationPort.PortName,-21} |");
            Console.WriteLine("+-----------------------+-----------------------+");
            Console.WriteLine("\n");

            Console.ForegroundColor = loadSuccess ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(loadSuccess
                ? $"Successfully loaded {item.Name} to {vehicle.GetType().Name}."
                : $"Failed to load {item.Name} - vehicle overloaded.");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }


}

