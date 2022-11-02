using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace slutproj_TravelPal.Models;

public class Vacation : Travel
{
    public bool All_Inclusive { get; set; }

    public Vacation(string destination, Countries country, int traveller, string userID) : base(destination, country, traveller, userID)
    {
        Destination = destination;
        Country = country;
        
    }

    // Returns and overrides base method GetInfo to view in listview (TravelWindow) for Vacation type.
    public override string GetInfo()
    {
        return $"Vacation destination: {Country}";
    }

    // 
    public bool AllInc()
    {
        return All_Inclusive = true;
    }
}
