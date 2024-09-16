using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProject
{
    public class PortTests
    {
        public void TestVehicleTravel()
        {
            Port haifaPort = new Port("Haifa Port");
            Port ashdodPort = new Port("Ashdod Port");

            CargoTrain train = new CargoTrain("John Doe", 5000, 10000, haifaPort);
            haifaPort.DockVehicle(train); // עגינת רכבת בנמל חיפה
            haifaPort.ShowDockedVehicles();

            // קביעת היעד לנמל אשדוד
            train.NextPort = ashdodPort;
            train.SetReadyToTravel(true); // קביעת מצב מוכנות לנסיעה
            train.TravelToNextPort(); // נסיעה לנמל אשדוד

            // הצגת הרכבים העוגנים בנמלים לאחר הנסיעה
            haifaPort.ShowDockedVehicles();
            ashdodPort.ShowDockedVehicles();
        }
    }
}
