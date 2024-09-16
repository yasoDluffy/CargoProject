using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class LogisticManager
    {
        // פעולה שמעבירה פריטים ממחסן לנמל, כולל בדיקת מקום פנוי
        public static bool TransferFromWarehouseToPort(Warehouse warehouse, Port port, List<IPortable> items)
        {
            double totalVolume = items.Sum(item => item.GetVolume());
            double totalWeight = items.Sum(item => item.GetWeight());

            if (port.GetCurrentVolume() + totalVolume > port.GetMaxVolume() ||
                port.GetCurrentWeight() + totalWeight > port.GetMaxWeight())
            {
                Console.WriteLine("Error: Not enough space in the port to transfer the items.");
                return false;
            }

            if (!warehouse.Unload(items))
            {
                Console.WriteLine("Error: Couldn't unload items from warehouse.");
                return false;
            }

            if (!warehouse.Load(items))
            {
                Console.WriteLine("Error: Couldn't load items to port.");
                return false;
            }

            Console.WriteLine("Items successfully transferred from warehouse to port.");
            return true;
        }

        // פעולה שמעבירה פריטים מנמל למחסן, כולל בדיקת מקום פנוי
        public static bool TransferFromPortToWarehouse(Port port, Warehouse warehouse, List<IPortable> items)
        {
            double totalVolume = items.Sum(item => item.GetVolume());
            double totalWeight = items.Sum(item => item.GetWeight());

            if (warehouse.GetCurrentVolume() + totalVolume > warehouse.GetMaxVolume() ||
                warehouse.GetCurrentWeight() + totalWeight > warehouse.GetMaxWeight())
            {
                Console.WriteLine("Error: Not enough space in the warehouse to transfer the items.");
                return false;
            }

            if (!warehouse.Unload(items))
            {
                Console.WriteLine("Error: Couldn't unload items from port.");
                return false;
            }

            if (!warehouse.Load(items))
            {
                Console.WriteLine("Error: Couldn't load items to warehouse.");
                return false;
            }

            Console.WriteLine("Items successfully transferred from port to warehouse.");
            return true;
        }

        // פעולה להעברת פריטים מרכב לנמל
        public static bool TransferFromVehicleToPort(CargoVehicle vehicle, Port port, List<IPortable> items)
        {
            double totalVolume = items.Sum(item => item.GetVolume());
            double totalWeight = items.Sum(item => item.GetWeight());

            if (port.GetCurrentVolume() + totalVolume > port.GetMaxVolume() ||
                port.GetCurrentWeight() + totalWeight > port.GetMaxWeight())
            {
                Console.WriteLine("Error: Not enough space in the port to transfer the items.");
                return false;
            }

            if (!vehicle.Unload(items))
            {
                Console.WriteLine("Error: Couldn't unload items from vehicle.");
                return false;
            }

            if (!vehicle.Load(items))
            {
                Console.WriteLine("Error: Couldn't load items to port.");
                return false;
            }

            Console.WriteLine("Items successfully transferred from vehicle to port.");
            return true;
        }

        // פעולה להעברת פריטים מנמל לרכב
        public static bool TransferFromPortToVehicle(Port port, CargoVehicle vehicle, List<IPortable> items)
        {
            double totalVolume = items.Sum(item => item.GetVolume());
            double totalWeight = items.Sum(item => item.GetWeight());

            if (vehicle.GetCurrentVolume() + totalVolume > vehicle.GetMaxVolume() ||
                vehicle.GetCurrentWeight() + totalWeight > vehicle.GetMaxWeight())
            {
                Console.WriteLine("Error: Not enough space in the vehicle to transfer the items.");
                return false;
            }

            if (!vehicle.Unload(items))
            {
                Console.WriteLine("Error: Couldn't unload items from port.");
                return false;
            }

            if (!vehicle.Load(items))
            {
                Console.WriteLine("Error: Couldn't load items to vehicle.");
                return false;
            }

            Console.WriteLine("Items successfully transferred from port to vehicle.");
            return true;
        }

        // פעולה להעברת פריטים מרכב לרכב
        public static bool TransferFromVehicleToVehicle(CargoVehicle fromVehicle, CargoVehicle toVehicle, List<IPortable> items)
        {
            double totalVolume = items.Sum(item => item.GetVolume());
            double totalWeight = items.Sum(item => item.GetWeight());

            if (toVehicle.GetCurrentVolume() + totalVolume > toVehicle.GetMaxVolume() ||
                toVehicle.GetCurrentWeight() + totalWeight > toVehicle.GetMaxWeight())
            {
                Console.WriteLine("Error: Not enough space in the receiving vehicle.");
                return false;
            }

            if (!fromVehicle.Unload(items))
            {
                Console.WriteLine("Error: Couldn't unload items from the source vehicle.");
                return false;
            }

            if (!toVehicle.Load(items))
            {
                Console.WriteLine("Error: Couldn't load items to the target vehicle.");
                return false;
            }

            Console.WriteLine("Items successfully transferred from vehicle to vehicle.");
            return true;
        }
    }
}
