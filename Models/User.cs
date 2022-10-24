using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace slutproj_TravelPal.Models;

public class User : IUser
{

    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Location { get; set; }
    public bool isAdmin { get; set; }

    public List<Travel> Travels { get; set; }


    public User(string userName, string password)
    {
        Username = userName;
        Password = password;
    }
}
