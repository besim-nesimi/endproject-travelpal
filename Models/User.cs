using slutproj_TravelPal.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Models;

public abstract class User : IUser
{    
    public List<Travel> Travels { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
