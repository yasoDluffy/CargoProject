using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoProject;


namespace CargoProject
{
    public class CargoPlane : CargoVehicle
    {
        public CargoPlane(string pilot, double maxWeight, double maxVolume, Port currentPort)
        : base()
        {
            Driver = pilot;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            CurrentPort = currentPort;
        }

        public override double GetMaxVolume() => MaxVolume;
        public override double GetMaxWeight() => MaxWeight;
        public override double GetCurrentVolume() => LoadedItems.Sum(item => item.GetVolume());
        public override double GetCurrentWeight() => LoadedItems.Sum(item => item.GetWeight());

        public override bool Load(IPortable item)
        {
            if (IsHaveRoom())
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
                if (!Load(item)) return false;
            }
            return true;
        }

        public override bool Unload() { LoadedItems.Clear(); return true; }
        public override bool Unload(IPortable item) => LoadedItems.Remove(item);
        public override bool Unload(List<IPortable> items)
        {
            foreach (IPortable item in items)
            {
                if (!Unload(item)) return false;
            }
            return true;
        }
    }
}
