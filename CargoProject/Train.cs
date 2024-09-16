using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class Train : CargoVehicle
    {
        public int NumberOfCars { get; set; } // מספר הקרונות
        private IShippingPriceCalculator priceCalculator; // מחשבון מחירי נסיעה

        public Train(int numberOfCars, double maxWeight, double maxVolume, IShippingPriceCalculator calculator)
        {
            NumberOfCars = numberOfCars;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            priceCalculator = calculator;
        }

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

        // חישוב המחיר הצפוי לנסיעה
        public double GetExpectedPrice(int travelDistance)
        {
            return priceCalculator.CalculatePrice(LoadedItems, travelDistance);
        }
    }
}
