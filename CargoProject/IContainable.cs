using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public interface IContainable
    {
        bool IsOverload();  // פונקציה שבודקת אם הכלי מעל העומס המותר
        bool IsFragile();   // פונקציה שבודקת אם הכלי שביר

    }
}

