using slutproj_TravelPal.Enums;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;

namespace slutproj_TravelPal.Models
{
    public class Travel
        { 
        public string Destination { get; set; }

        public Countries Country { get; set; }

        public int Travellers { get; set; }

        public Travel(string destination, Countries country, int travellers)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
        }

        public virtual string GetInfo()
        {
            return "";
        }
    }
}