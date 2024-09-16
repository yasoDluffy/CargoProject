using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace CargoProject
{
    public class CargoTransportConsole
    {
        // רשימה שמכילה את הפריטים במשלוח הנוכחי
        private static List<Product> shipment = new List<Product>();

        public static void MainMenu()
        {
            string choice;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Cargo Transportation System\n");
                Console.ResetColor();

                Console.WriteLine("1. Show Sample Shipment Items Table");
                Console.WriteLine("2. Create Custom Shipment");
                Console.WriteLine("3. Calculate Shipping Cost");
                Console.WriteLine("4. Exit");

                Console.Write("\nEnter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowSampleShipmentTable();
                        break;
                    case "2":
                        CreateCustomShipment();
                        break;
                    case "3":
                        if (shipment.Count > 0)
                        {
                            CalculateShippingCost(shipment);
                        }
                        else
                        {
                            Console.WriteLine("No shipment has been created yet.");
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }

            } while (choice != "4");
        }

        public static void ShowSampleShipmentTable()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Sample Shipment Items Table\n");
            Console.ResetColor();
            Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10} |", "Item Name", "Model", "Weight (kg)", "Volume (m3)", "Fragile");
            Console.WriteLine(new string('-', 70));

            // דוגמא לפריטים
            List<Product> sampleProducts = new List<Product>
        {
            new Product("Table", "Ikea", 20, 2, false, 500),
            new Product("Chair", "Ikea", 5, 0.5, false, 200),
            new Product("Sofa", "HomeComfort", 50, 7, false, 3000),
            new Product("Refrigerator", "LG", 70, 10, true, 4500),
            new Product("Lamp", "Philips", 2, 0.2, true, 100)
        };

            // הצגת הפריטים בטבלה
            foreach (var product in sampleProducts)
            {
                Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10} |",
                    product.Name, product.Model, product.Weight, product.Volume, product.IsFragile ? "Yes" : "No");
            }

            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }

        public static void CreateCustomShipment()
        {
            List<Product> availableProducts = new List<Product>
        {
            new Product("Television", "LG SMART", 15, 1.5, true, 2000),
            new Product("Fridge", "Samsung XXL", 50, 4, false, 3000),
            new Product("Washing Machine", "Bosch", 70, 6, false, 2500),
            new Product("Microwave", "Panasonic", 10, 0.8, true, 1000),
            new Product("Oven", "Electrolux", 40, 3.5, false, 1500)
        };

            shipment.Clear(); // מנקה את המשלוח הקודם לפני יצירת חדש
            int maxItems = 20;
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("Available products:");
                for (int i = 0; i < availableProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableProducts[i].Name} - {availableProducts[i].Model} (Weight: {availableProducts[i].Weight}kg, Price: {availableProducts[i].Price})");
                }

                Console.WriteLine("\nSelect a product by number (or type 'done' to finish): ");
                input = Console.ReadLine();

                if (input.ToLower() != "done")
                {
                    if (int.TryParse(input, out int choice) && choice > 0 && choice <= availableProducts.Count)
                    {
                        shipment.Add(availableProducts[choice - 1]);
                        Console.WriteLine($"{availableProducts[choice - 1].Name} added to shipment.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please try again.");
                    }
                }

            } while (input.ToLower() != "done" && shipment.Count < maxItems);

            Console.WriteLine($"\nYou have created a shipment with {shipment.Count} items.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        public static void CalculateShippingCost(List<Product> shipment)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Shipment Cost Calculation\n");
            Console.ResetColor();
            Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10} |", "Item Name", "Model", "Weight (kg)", "Volume (m3)", "Shipping Cost");
            Console.WriteLine(new string('-', 70));

            double totalCost = 0;
            foreach (var product in shipment)
            {
                double shippingCost = product.CalculateShippingCost();
                totalCost += shippingCost;

                Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10:C} |",
                    product.Name, product.Model, product.Weight, product.Volume, shippingCost);
            }

            Console.WriteLine($"\nTotal Shipping Cost: {totalCost:C}");
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }




    }
}
