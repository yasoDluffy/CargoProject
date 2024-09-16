using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class Ship : CargoVehicle
    {
        public int NumberOfContainers { get; set; } // מספר המכולות

        public Ship(int numberOfContainers, double maxWeight, double maxVolume)
        {
            NumberOfContainers = numberOfContainers;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
        }

        public override bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                LoadedItems.Add(item); // הוספת הפריט לרשימת הפריטים הטעונים
                return true;
            }
            return false;
        }

        public override bool Load(List<IPortable> items)
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

        public override bool Unload()
        {
            LoadedItems.Clear(); // פריקת כל הפריטים
            return true;
        }

        public override bool Unload(IPortable item)
        {
            return LoadedItems.Remove(item); // פריקת פריט מסוים
        }

        public override bool Unload(List<IPortable> items)
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

        public override double GetMaxVolume()
        {
            return MaxVolume;
        }

        public override double GetMaxWeight()
        {
            return MaxWeight;
        }

        public override double GetCurrentVolume()
        {
            double totalVolume = 0;
            foreach (IPortable item in LoadedItems)
            {
                totalVolume += item.GetVolume(); // סיכום הנפח של כל הפריטים הטעונים
            }
            return totalVolume;
        }

        public override double GetCurrentWeight()
        {
            double totalWeight = 0;
            foreach (IPortable item in LoadedItems)
            {
                totalWeight += item.GetWeight(); // סיכום המשקל של כל הפריטים הטעונים
            }
            return totalWeight;
        }
    }
}
