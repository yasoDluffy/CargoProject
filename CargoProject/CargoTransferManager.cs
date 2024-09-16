using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class CargoTransferManager
    {
        public bool TransferItems(Port originPort, Port destinationPort, CargoVehicle vehicle)
        {
            // תחילה נוודא שהרכב מוכן לנסיעה ואין עומס יתר
            if (!vehicle.IsReadyToTravel )
            {
                return false;
            }
            if (vehicle.IsOverloaded())
            {
                return false;
            }
            // נפרוק פריטים מהנמל המקורי
            List<IPortable> itemsToTransfer = originPort.StoredItems;
            if (!originPort.Unload(itemsToTransfer))
            {
                return false;
            }

            // נטעין את הפריטים על רכב המשא
            if (!vehicle.Load(itemsToTransfer))
            {
                return false;
            }

            // עדכון הנמל הבא ברכב המשא
            vehicle.NextPort = destinationPort;

            // סימון הרכב כמוכן לנסיעה
            vehicle.SetReadyToTravel(true);

            return true;
        }

        public bool CompleteTransfer(CargoVehicle vehicle)
        {
            // וידוא שהרכב הגיע ליעד
            if (vehicle.NextPort == null)
            {
                return false;
            }

            // פריקת הפריטים ברכב המשא לנמל היעד
            if (!vehicle.NextPort.Load(vehicle.LoadedItems))
            {
                return false;
            }

            // פריקת הרכב
            vehicle.Unload();

            // עדכון הנמל הנוכחי והיעד הבא
            vehicle.CurrentPort = vehicle.NextPort;
            vehicle.NextPort = null;

            // סימון שהרכב לא מוכן לנסיעה עד להעמסה מחדש
            vehicle.SetReadyToTravel(false);

            return true;
        }
    }
}
