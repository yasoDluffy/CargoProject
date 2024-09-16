using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class CargoItem : IPortable
    {

        // Properties
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public double Volume { get; private set; }
        public bool IsFragile { get; private set; }

        // Constructor
        public CargoItem(string name, double weight, double volume, bool isFragile = false)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            IsFragile = isFragile;
        }

        public double GetWeight() => Weight;
        public double GetVolume() => Volume;
        public bool IsFragileItem() => IsFragile;

        public override string ToString()
        {
            return $"{Name} (Weight: {Weight} kg, Volume: {Volume} m³, Fragile: {IsFragile})";
        }


    }
}

