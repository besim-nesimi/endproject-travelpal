using slutproj_TravelPal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Interfaces
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Countries Location { get; set; }

        public bool isAdmin { get; }

    }
}
