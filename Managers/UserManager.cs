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
    public IUser SignedInUser { get; set; }

    public void DefaultUsers()
    {
        Admin admin = new("admin", "password");

        User defaultUser = new("gandalf", "password", Countries.New_Zealand); // skapade en NY defaultUser gandalf med bara constructor, funkade ej

        //defaultUser.Username = "gandalf"; // Settade props username och password, testar nu om min mainwindow förstår / hittar. 2022-10-25
        //defaultUser.Password = "password"; // funkar fortfarande inte 2022-10-25, så det har inte med propsen att göra.

        allUsers.Add(admin);
        allUsers.Add(defaultUser);
    }    
    
    public List<IUser> GetAllUsers() // Vår lista, som är tom ifall vi inte populerar den.
                                     
    {
        return allUsers;
    }
    
    // Metoden avser lägga till / populera users i allUsers.
    public bool AddUser(string username, string password, Countries country) 
    {
        if(ValidateUsername(username))
        {
            User user = new(username, password, country);
            allUsers.Add(user);

            return true;
        }

        return false;
    }

    public bool UpdateUsername(IUser thisUser, string username) // Ej färdig - Metoden avser att låta user ändra username.
    {
        return false;
    }

    private bool ValidateUsername(string username) // Ej färdig - Metoden ska validera ändring av username.
    {
        return true;
    }

    public bool SignInUser(string username, string password) // Färdig! ish.
    {
        foreach (IUser user in allUsers)
        {
            if(user.Username == username && user.Password == password)
            {
                SignedInUser = user;

                return true;
            }
        }
        return false;
      
    }




}

