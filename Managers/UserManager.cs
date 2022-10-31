using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Interfaces;
using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Managers;

public class UserManager
{

    
    private List<IUser> allUsers = new(); // Alla våra users i travelapp, users och admins
    public IUser SignedInUser { get; set; }

    public UserManager()
    {
        DefaultUsers();
    }

    // Two default users, one is an admin and one is named Gandalf. Gandalf has two default trips added to his travelwindow.

    public void DefaultUsers()
    {
        Admin admin = new("admin", "password");

        User defaultUser = new("Gandalf", "password", Countries.New_Zealand);

        List<Travel> Travels = new();

        Trip trip = new(TripTypes.Work, "Mt Doom", Countries.New_Zealand, 9);
        defaultUser.Travels.Add(trip);

        Vacation vacation = new("Imladris", Countries.New_Zealand, 1);
        defaultUser.Travels.Add(vacation);

        allUsers.Add(admin);
        allUsers.Add(defaultUser);

    }


    // This is our method of returning the user list.
public List<IUser> GetAllUsers()
                                     
    {
        return allUsers;
    }
    
    // This methods function is to add a new user to our list. Also validates/checks that the chosen username is not in use already.
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


    // Method that enables users to change their password. Password has to be same as confirm password.
    public bool ValidatePassword(string password) // Ej färdig - Metoden avser att låta user ändra info.
    {
        foreach (IUser user in allUsers)
        {
            if (user.Password == password)
            {
                return true;
            }
        }
        return true;

    }

    // Method that checks if the chosen username is not in use already.
    public bool ValidateUsername(string username)
    {
        foreach (IUser user in allUsers)
        {
            if (user.Username == username)
            {
                return false;
            }
        }
        return true;
    }


    // Method for signing in.
    public bool SignInUser(string username, string password)
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

