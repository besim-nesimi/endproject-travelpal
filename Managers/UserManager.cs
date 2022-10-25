using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Interfaces;
using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Managers;

public class UserManager
{
    
    private List<IUser> allUsers = new(); // Alla våra users i travelapp, clienter och admins
    private IUser signedInUser;

    public void DefaultUsers()
    {
        Admin admin = new("admin", "password");

        User defaultUser = new("gandalf", "password"); // skapade en NY defaultUser gandalf med bara constructor, funkade ej

        defaultUser.Username = "gandalf"; // Settade props username och password, testar nu om min mainwindow förstår / hittar. 2022-10-25
        defaultUser.Password = "password"; // funkar fortfarande inte 2022-10-25, så det har inte med propsen att göra.

        allUsers.Add(admin);
        allUsers.Add(defaultUser);
    }    
    
    public List<IUser> GetAllUsers() // här står det Public List<IUser> GetAllUsers() - Kan det vara här det failar?
                                     
    {
        return allUsers;
    }

    public bool AddUser(string username, string password) // Ej färdig - Metoden avser lägga till users i allUsers.
    {
        User user = new(username, password);
        allUsers.Add(user);
        return true;

    }

    public bool UpdateUsername(IUser thisUser, string username) // Ej färdig - Metoden avser att låta user ändra username.
    {
        return false;
    }

    private bool ValidateUsername() // Ej färdig - Metoden ska validera ändring av username.
    {
        return false;
    }

    public bool SignedInUser(string username, string password) // Ej färdig
    {
        return true;
    }




}

