using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CargoProject;


namespace CargoProject
{
    public abstract class CargoVehicle : IContainable
    {

        public string Driver { get; set; }
        public double MaxWeight { get; set; }
        public double MaxVolume { get; set; }
        public Port CurrentPort { get; set; }
        public Port NextPort { get; set; }
        public List<IPortable> LoadedItems { get; private set; } = new List<IPortable>();
        public bool IsReadyToTravel { get; set; }

        public abstract double GetMaxVolume();
        public abstract double GetMaxWeight();
        public abstract double GetCurrentVolume();
        public abstract double GetCurrentWeight();

        public bool IsOverload() => GetCurrentWeight() > GetMaxWeight() || GetCurrentVolume() > GetMaxVolume();

        public bool IsOverloaded() => GetCurrentWeight() > GetMaxWeight() || GetCurrentVolume() > GetMaxVolume();

        public bool IsFragile()
        {
            return LoadedItems.Any(item => item.IsFragileItem());
        }

        public override string ToString()
        {
            var loadedItemsInfo = string.Join(", ", LoadedItems.Select(item => item.ToString()));
            return $"Driver: {Driver}, Items Loaded: [{loadedItemsInfo}], Ready to travel: {IsReadyToTravel}, Overloaded: {IsOverloaded()}";
        }

        public void SetReadyToTravel(bool ready) => IsReadyToTravel = ready;

        public abstract bool Load(IPortable item);
        public abstract bool Load(List<IPortable> items);
        public abstract bool Unload(IPortable item);
        public abstract bool Unload(List<IPortable> items);
        public abstract bool Unload();

        public bool IsHaveRoom()
        {
            return GetCurrentWeight() <= MaxWeight && GetCurrentVolume() <= MaxVolume;
        }
    }
}
