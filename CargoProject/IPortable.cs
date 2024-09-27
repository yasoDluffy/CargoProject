using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public interface IPortable
    {

        double GetWeight();   // Returns the weight of the item
        double GetVolume();   // Returns the volume of the item
        bool IsFragileItem(); // Indicates if the item is fragile
    
    }
}
