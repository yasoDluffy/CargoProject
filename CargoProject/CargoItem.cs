using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class CargoItem : IPortable
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public bool IsFragile { get; set; }
        public double Price { get; set; }

        public CargoItem(string name, double weight, double volume, bool isFragile, double price)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            IsFragile = isFragile;
            Price = price;
        }

        // Implementing IPortable interface methods
        public double GetWeight()
        {
            return Weight;
        }

        public double GetVolume()
        {
            return Volume;
        }

        public bool IsFragileItem()
        {
            return IsFragile;
        }
    }

}