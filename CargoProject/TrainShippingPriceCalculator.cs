using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class TrainShippingPriceCalculator : IShippingPriceCalculator
    {

        public double CalculatePrice(List<IPortable> items, int distance)
        {
            double totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += 10; // לוגיקה דומה
            }
            return totalPrice * distance; // לדוגמה, תמחור לפי מרחק
        }
        public double CalculateShippingCost(double weight, double volume, double distance)
        {
            return (weight * 0.3 + volume * 0.1) * distance * 0.7;
        }

    }
}
