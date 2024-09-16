using CargoProject;
using System.Collections.Generic;
using System;
using System.Linq;

public class Port
{
    public string PortName { get; set; }
    public List<CargoVehicle> DockedVehicles { get; set; } = new List<CargoVehicle>();
    public List<IPortable> StoredItems { get; set; } = new List<IPortable>();
    public List<IPortable> AvailableItems { get; set; } = new List<IPortable>();
    public double MaxWeight { get; private set; } = 10000;  // הגדרת משקל מקסימלי לנמל

    public Port(string portName)
    {
        PortName = portName;
    }

    public double GetCurrentWeight()
    {
        return StoredItems.Sum(item => item.GetWeight());  // שימוש ב-IPortable GetWeight
    }

    public double GetMaxWeight() => MaxWeight;  // משקל מקסימלי

    public double GetCurrentVolume()
    {
        return StoredItems.Sum(item => item.GetVolume());  // סך כל הנפח של הפריטים המאוחסנים
    }

    public double GetMaxVolume() => 1000;  // נפח מקסימלי לדוגמה

    public bool Load(List<IPortable> items)
    {
        // לוגיקה לטעינת פריטים לנמל, לפי מקום פנוי
        double totalWeight = items.Sum(i => i.GetWeight());
        double totalVolume = items.Sum(i => i.GetVolume());
        if (GetCurrentWeight() + totalWeight > GetMaxWeight() || GetCurrentVolume() + totalVolume > GetMaxVolume())
        {
            return false;  // אין מספיק מקום
        }
        StoredItems.AddRange(items);
        return true;
    }

    public bool Unload(List<IPortable> items)
    {
        // פריקת פריטים מהנמל
        foreach (var item in items)
        {
            if (!StoredItems.Remove(item)) return false;
        }
        return true;
    }

    public void DockVehicle(CargoVehicle vehicle) => DockedVehicles.Add(vehicle);

    public void UnloadVehicle(CargoVehicle vehicle) => DockedVehicles.Remove(vehicle);

    public void AddItemToPort(IPortable item) => AvailableItems.Add(item);

    public void RemoveItemFromPort(IPortable item) => AvailableItems.Remove(item);
    public void ShowDockedVehicles()
    {
        Console.WriteLine($"Vehicles docked at {PortName}:");
        foreach (var vehicle in DockedVehicles)
        {
            Console.WriteLine($"- {vehicle.Driver}'s vehicle");
        }
    }
}
