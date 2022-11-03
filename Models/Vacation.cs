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

    public Vacation(string destination, Countries country, int traveller, string userID, bool isBoxChecked) : base(destination, country, traveller, userID)
    {
        Destination = destination;
        Country = country;
        All_Inclusive = isBoxChecked;
        
    }

    // Returns and overrides base method GetInfo to view in listview (TravelWindow) for Vacation type.
    public override string GetInfo()
    {
        return $"Vacation destination: {Country}";
    }

    // Method never used, and is superflous. Yet lets just leave it here, in case the app becomes bigger and better and whatnot. Might want to return a string or something.
    public string AllInclusive()
    {
        if (All_Inclusive == true)
        {
            return $"Vacation is all inclusive";
        }
        else
        {
            return $"Vacation is not all inclusive";
        }
    }
}
