using slutproj_TravelPal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Models
{
    internal class Admin : User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
