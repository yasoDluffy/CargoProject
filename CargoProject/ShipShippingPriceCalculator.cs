using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class ShipShippingPriceCalculator : IShippingPriceCalculator
    {
        private const double PricePerKilometer = 20; // מחיר לקילומטר עבור אוניה

        public double CalculateShippingCost(double weight, double volume, double distance)
        {
            return (weight * 0.4 + volume * 0.2) * distance * 0.9;
        }
        public double CalculatePrice(IPortable item, int travelDistance)
        {
            double units = CalculateUnits(item);
            return units * travelDistance * PricePerKilometer;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            double totalUnits = 0;
            foreach (IPortable item in items)
            {
                totalUnits += CalculateUnits(item);
            }
            return totalUnits * travelDistance * PricePerKilometer;
        }

        private double CalculateUnits(IPortable item)
        {
            // חישוב היחידות עבור נפח ומשקל של פריט
            double units = (item.GetVolume() / 100.0) + item.GetWeight();
            if (item.IsFragileItem())
            {
                units *= 2; // הכפלת היחידות אם מדובר בפריט שביר
            }
            return units;
        }
    }
}
