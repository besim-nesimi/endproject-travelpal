using slutproj_TravelPal.Enums;
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
        private UserManager userManager;


        // Jag klickade på Show Details knappen inuti TravelWindow, skapade ett klickevent 
        public void ShowDetails(Travel? selectedTravel) // visa detaljer för resan som klickats på listview ?
        {
        }
    }
}
