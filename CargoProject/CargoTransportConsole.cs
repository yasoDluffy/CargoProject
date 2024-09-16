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

        List<CargoItem> selectedItems = new List<CargoItem>();
        foreach (var index in selectedProductIndexes)
        {
            if (int.TryParse(index.Trim(), out int idx) && idx >= 0 && idx < items.Count)
            {
                selectedItems.Add(items[idx]);
            }
        }

        Console.WriteLine("\nChoose origin port: ");
        string origin = Console.ReadLine();
        Console.WriteLine("Choose destination port: ");
        string destination = Console.ReadLine();

        Console.WriteLine("\nChoose transportation plan: (1) Plane, (2) Train, (3) Ship");
        string transportChoice = Console.ReadLine();
        string transportType = transportChoice switch
        {
            "1" => "Plane",
            "2" => "Train",
            "3" => "Ship",
            _ => "Unknown"
        };

        Console.WriteLine("\nYou have selected the following products for transport:");
        Console.WriteLine("----------------------------------------------------");
        foreach (var item in selectedItems)
        {
            Console.WriteLine($"Product: {item.Name}, Weight: {item.Weight}kg, Volume: {item.Volume}m3, Fragile: {item.IsFragile}");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nTransportation Method: {transportType}");
        Console.WriteLine($"From: {origin} To: {destination}");
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
}

public class CargoItem
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public bool IsFragile { get; set; }
    public double Price { get; set; }

    public CargoItem(string name, double weight, double volume, bool isFragile, double price)
    {
        Name = name;
        Weight = weight;
        Volume = volume;
        IsFragile = isFragile;
        Price = price;
    }
}

}