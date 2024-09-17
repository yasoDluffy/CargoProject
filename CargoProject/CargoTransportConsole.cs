using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CargoProject
{

public class CargoTransportConsole
{
        public static List<CargoItem> items = new List<CargoItem>();

        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Cargo Transport System");
            Console.ResetColor();

            DisplayItems();

            Console.WriteLine("\nChoose your products to order (enter product numbers separated by commas): ");
            string[] selectedProductIndexes = Console.ReadLine().Split(',');

            List<CargoItem> selectedProducts = new List<CargoItem>();
            foreach (var index in selectedProductIndexes)
            {
                if (int.TryParse(index.Trim(), out int idx) && idx >= 0 && idx < items.Count)
                {
                    selectedProducts.Add(items[idx]);
                }
            }

            Console.WriteLine("\nChoose origin port: ");
            string originPort = Console.ReadLine();
            Console.WriteLine("Choose destination port: ");
            string destinationPort = Console.ReadLine();

            Console.WriteLine("\nChoose transportation plan: (1) Plane, (2) Train, (3) Ship");
            string transportChoice = Console.ReadLine();
            string transportationMethod = "";

            switch (transportChoice)
            {
                case "1":
                    transportationMethod = "Plane";
                    break;
                case "2":
                    transportationMethod = "Train";
                    break;
                case "3":
                    transportationMethod = "Ship";
                    break;
                default:
                    Console.WriteLine("Invalid transportation method selected.");
                    return;
            }

            // Sample rate constants for each transportation method
            double shipRatePerKg = 1.5;
            double shipRatePerM3 = 50;
            double planeRatePerKg = 5.0;
            double planeRatePerM3 = 200;
            double trainRatePerKg = 2.0;
            double trainRatePerM3 = 80;

            // Variables to store total weight, volume, and cost
            double totalWeight = 0;
            double totalVolume = 0;
            double totalCost = 0;

            // Loop to sum up the weight and volume of selected items
            foreach (var item in selectedProducts)
            {
                totalWeight += item.Weight;
                totalVolume += item.Volume;
            }

            // Calculate cost based on the chosen transportation method
            switch (transportationMethod)
            {
                case "Ship":
                    totalCost = (totalWeight * shipRatePerKg) + (totalVolume * shipRatePerM3);
                    break;
                case "Plane":
                    totalCost = (totalWeight * planeRatePerKg) + (totalVolume * planeRatePerM3);
                    break;
                case "Train":
                    totalCost = (totalWeight * trainRatePerKg) + (totalVolume * trainRatePerM3);
                    break;
            }

            // Displaying the order summary and estimated cost
            Console.WriteLine("\nYou have selected the following products for transport:");
            Console.WriteLine("----------------------------------------------------");
            foreach (var item in selectedProducts)
            {
                Console.WriteLine($"Product: {item.Name}, Weight: {item.Weight}kg, Volume: {item.Volume}m3, Fragile: {item.IsFragile}");
            }
            Console.WriteLine($"\nTransportation Method: {transportationMethod}");
            Console.WriteLine($"From: {originPort} To: {destinationPort}");
            Console.WriteLine($"Total Weight: {totalWeight}kg");
            Console.WriteLine($"Total Volume: {totalVolume}m3");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Cost of Delivery: ${totalCost:F2}");
            Console.ResetColor();
        }

        public static void DisplayItems()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAvailable Products:");
            Console.WriteLine("----------------------------------------------------");
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                Console.WriteLine($"{i}. {item.Name}, Weight: {item.Weight}kg, Volume: {item.Volume}m3, Fragile: {item.IsFragile}");
            }
            Console.ResetColor();
        }

        public static void InitializeItems()
        {
            items.Add(new CargoItem("Laptop", 2.5, 0.003, true, 1200));
            items.Add(new CargoItem("Table", 25, 1.5, false, 200));
            items.Add(new CargoItem("Chair", 7, 0.5, false, 50));
            items.Add(new CargoItem("Cloth", 0.2, 0.003, false, 30));
            items.Add(new CargoItem("Phone", 0.5, 0.002, true, 800));
            items.Add(new CargoItem("Galaxy Phone", 0.6, 0.002, true, 900));
            items.Add(new CargoItem("Flashlight", 0.3, 0.001, false, 20));
            items.Add(new CargoItem("Computer", 7, 0.5, true, 1000));
            items.Add(new CargoItem("Glasses", 0.1, 0.0005, true, 150));
            items.Add(new CargoItem("Pencil", 0.02, 0.0001, false, 2));
            items.Add(new CargoItem("Shoes", 1, 0.004, false, 60));
            items.Add(new CargoItem("Jeans", 0.5, 0.003, false, 40));
            items.Add(new CargoItem("Belt", 0.2, 0.001, false, 15));
            items.Add(new CargoItem("Plate", 1, 0.002, true, 25));
            items.Add(new CargoItem("Hat", 0.1, 0.0008, false, 20));
        }
    }

   

}



