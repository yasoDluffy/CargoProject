using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class Product
    {
        public string Name { get; }
        public string Model { get; }
        public double Weight { get; }
        public double Volume { get; }
        public bool IsFragile { get; }
        public double Price { get; }

        public Product(string name, string model, double weight, double volume, bool isFragile, double price)
        {
            Name = name;
            Model = model;
            Weight = weight;
            Volume = volume;
            IsFragile = isFragile;
            Price = price;
        }

        public double CalculateShippingCost()
        {
            double baseCost = Weight * 10 + Volume * 5;
            if (IsFragile)
            {
                baseCost *= 1.5; // עלות נוספת לפריטים שבירים
            }
            return baseCost;
        }
    }
}
