using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public interface IShippingPriceCalculator
    {
        double CalculatePrice(List<IPortable> loadedItems, int travelDistance);
        double CalculateShippingCost(double weight, double volume, double distance);
        
    
    }

   

}
