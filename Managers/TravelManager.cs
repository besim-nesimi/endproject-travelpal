using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace slutproj_TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> Travels { get; set; } = new();

        public void ShowDetails(Travel? selectedTravel) // visa detaljer för resan som klickats på listview ?
        {
            
        }

        public void RemoveTravel()
        {

        }

        public void AdminDisplayTravels()
        {
            Travels.AddRange(Travels); // Ska visa alla travels på listan på admins listview
        }
    }
}
