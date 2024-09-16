using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class Warehouse : StorageStructure, IContainable
    {
        public new double MaxWeight { get; set; }
        public new double MaxVolume { get; set; }

        public Warehouse(string country, string city, double maxWeight, double maxVolume)
            : base(country, city, maxWeight, maxVolume)
        {
        }
        //אחסון הפריטים במחסן
        public List<IPortable> StoredItems = new List<IPortable>();


        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                StoredItems.Add(item);
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            foreach (IPortable item in items)
            {
                if (!Load(item))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Unload()
        {
            StoredItems.Clear();
            return true;
        }

        public bool Unload(IPortable item)
        {
            return StoredItems.Remove(item);
        }

        public bool Unload(List<IPortable> items)
        {
            foreach (IPortable item in items)
            {
                if (!Unload(item))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsHaveRoom()
        {
            return GetCurrentVolume() < MaxVolume && GetCurrentWeight() < MaxWeight;
        }

        public bool IsOverload()
        {
            return GetCurrentVolume() > MaxVolume || GetCurrentWeight() > MaxWeight;
        }

        public double GetMaxVolume()
        {
            return MaxVolume;
        }

        public double GetMaxWeight()
        {
            return MaxWeight;
        }

        public double GetCurrentVolume()
        {
            double totalVolume = 0;
            foreach (IPortable item in StoredItems)
            {
                totalVolume += item.GetVolume();
            }
            return totalVolume;
        }

        public double GetCurrentWeight()
        {
            double totalWeight = 0;
            foreach (IPortable item in StoredItems)
            {
                totalWeight += item.GetWeight();
            }
            return totalWeight;
        }
        // Implement IsFragile method
        public bool IsFragile()
        {
            // לוגיקה לבדיקת שבירות
            return false; // דוגמה
        }
    }

}






