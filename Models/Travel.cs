using slutproj_TravelPal.Enums;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;

namespace slutproj_TravelPal.Models
{
    public class Travel
        {

        public string userID;

        public string Destination { get; set; }

        public Countries Country { get; set; }

        public int Travellers { get; set; }

        public Travel(string destination, Countries country, int travellers, string userID)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
            this.userID = userID;
        }


        // Overriding this method with GetInfo from subclasses. Printing into listview field.
        public virtual string GetInfo()
        {
            return "";
        }
    }
}