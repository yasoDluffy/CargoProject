using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class StorageStructure
    {
        private string name;
        private string country;
        private string city;

        public double MaxWeight { get; }
        public double CurrentWeight { get; }
        public double MaxVolume { get; }

        public StorageStructure(string name, double maxWeight, double currentWeight, double maxVolume)
        {
            // אתחול של כל הפרמטרים
            this.name = name;
            this.MaxWeight = maxWeight;
            this.CurrentWeight = currentWeight;
            this.MaxVolume = maxVolume;
        }

        public StorageStructure(string country, string city, double maxWeight, double maxVolume)
        {
            this.country = country;
            this.city = city;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
        }
    }
}
