using slutproj_TravelPal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace slutproj_TravelPal.Models;

public class Vacation : Travel
{
    public Vacation(string destination, Countries country, int traveller) : base(destination, country, traveller)
    {
        Destination = destination;
        Country = country;
        
    }

    public override string GetInfo()
    {
        return $"Your travel itinerary for your vacation to {Country}";
    }
}
