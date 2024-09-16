using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class Plane : CargoVehicle
    {
        public int NumberOfCompartments { get; set; } // מספר התאים
        public Plane(int numberOfCompartments, double maxWeight, double maxVolume)
        {
            NumberOfCompartments = numberOfCompartments;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
        }

        // מימוש המתודות של הממשק ושל המחלקה האבסטרקטית
        public override bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                LoadedItems.Add(item);
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
            LoadedItems.Clear();
            return true;
        }
        public override bool Unload(IPortable item)
        {
            return LoadedItems.Remove(item);
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
                totalVolume += item.GetVolume();
            }
            return totalVolume;
        }
        public override double GetCurrentWeight()
        {
            double totalWeight = 0;
            foreach (IPortable item in LoadedItems)
            {
                totalWeight += item.GetWeight();
            }
            return totalWeight;
        }

    }
}
