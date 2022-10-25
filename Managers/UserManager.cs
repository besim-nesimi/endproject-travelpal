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

        admin.Username = "admin";
        admin.Password = "password";
        admin.isAdmin = true;

        User defaultUser = new("gandalf", "password"); // skapade en NY defaultUser gandalf med bara constructor, funkade ej

        defaultUser.Username = "gandalf"; // Settade props username och password, testar nu om min mainwindow förstår / hittar. 2022-10-25
        defaultUser.Password = "password"; // funkar fortfarande inte 2022-10-25, så det har inte med propsen att göra.

        allUsers.Add(admin);
        allUsers.Add(defaultUser);
    }    
    
    public List<IUser> GetAllUsers() // här står det Public List<IUser> GetAllUsers() - Kan det vara här det failar?
                                     // Möjligen att själva metoden är fel. Vi testar med att ta 
    {
        return allUsers;
    }

    public void AddUser(string username, string password)
    {
        User user = new(username, password);

        allUsers.Add(user);

    }


}

