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

    
    private List<IUser> allUsers = new(); // Alla våra users i travelapp, users och admins
    public IUser SignedInUser { get; set; }

    public UserManager()
    {
        //Admin admin = new("admin", "password");

        //User defaultUser = new("Gandalf", "password", Countries.New_Zealand);

        //allUsers.Add(admin);
        //allUsers.Add(defaultUser);

        //Trip trip1 = new(TripTypes.Work, "Mt Doom", Countries.New_Zealand, 9);
        //defaultUser.Travels.Add(trip1);
        //Trip trip2 = new(TripTypes.Leisure, "Imladris", Countries.New_Zealand, 1);
        //defaultUser.Travels.Add(trip2);

        DefaultUsers();
    }

    public void DefaultUsers()
    {
        Admin admin = new("admin", "password");

        User defaultUser = new("Gandalf", "password", Countries.New_Zealand);

        allUsers.Add(admin);
        allUsers.Add(defaultUser);

        Trip trip1 = new(TripTypes.Work, "Mt Doom", Countries.New_Zealand, 9);
        defaultUser.Travels.Add(trip1);
        Trip trip2 = new(TripTypes.Leisure, "Imladris", Countries.New_Zealand, 1);
        defaultUser.Travels.Add(trip2);
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
        return true;
    }

    private bool ValidateUsername(string username) // Metoden kikar om användarnamnet redan är i bruk eller ej.
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

    public bool SignInUser(string username, string password) // Färdig!
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

