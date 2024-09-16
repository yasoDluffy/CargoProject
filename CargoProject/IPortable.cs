using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public interface IPortable
    {

        string Name { get; }
        double GetWeight();
        double GetVolume();
        bool IsFragileItem();

    }
}
