using slutproj_TravelPal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Models;

public class Trip : Travel
{

    public TripTypes Type { get; set; }
    public Trip(TripTypes type, string destination, Countries country, int travellers) : base(destination, country, travellers)
    {
        this.Type = type;
    }

    public override string GetInfo()
    {
        return $"{base.Destination} and {base.Country}";
    }
}
