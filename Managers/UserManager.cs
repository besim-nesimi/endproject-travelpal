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

        User defaultUser = new("gandalf", "password");

        allUsers.Add(admin);
        allUsers.Add(defaultUser);
    }    
    
    public List<IUser> GetAllUsers()
    {
        return allUsers;
    }

    public void AddUser(string username, string password)
    {
        User user = new(username, password);

        allUsers.Add(user);


    }


}

