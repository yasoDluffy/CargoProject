using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class Product
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public bool IsFragile { get; set; }
        public double Price { get; set; }
        public bool IsReadyForShipment { get; set; }  // Added this property for readiness

        public Product(string name, string model, double weight, double volume, bool isFragile, double price, bool isReady)
        {
            Name = name;
            Model = model;
            Weight = weight;
            Volume = volume;
            IsFragile = isFragile;
            Price = price;
            IsReadyForShipment = isReady;  // Initialize readiness
        }

        public double CalculateShippingCost()
        {
            return Weight * Volume * 10;  // Simplified shipping cost calculation
        }
    }
}
