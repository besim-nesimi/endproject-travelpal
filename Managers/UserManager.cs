using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Interfaces;
using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        Admin admin = new("admin", "password", Countries.Sweden);

        User defaultUser = new("Gandalf", "password", Countries.New_Zealand);

        List<Travel> Travels = new();

        Trip trip = new(TripTypes.Work, "Mt Doom", Countries.New_Zealand, 9, "Gandalf");
        defaultUser.Travels.Add(trip);

        Vacation vacation = new("Imladris", Countries.New_Zealand, 1, "Gandalf");
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

    // Method that checks if the chosen username is not in use already.
    public bool ValidateUsername(string username)
    {
        foreach (IUser user in allUsers)
        {
            if (user.Username == username)
            {
                MessageBox.Show("That username is already in use!", "Warning!");
                return false;
            }
        }
        return true;
    }


    // Password has to be same as confirm password. This method is for already signed up users.
    public bool ValidatePassword(string password)
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

    // Username lenght check.
    public bool CheckUserLenght(string newName)
    {

        if (newName.Length < 5 || newName.Length > 10)
        {
            MessageBox.Show("The username must be between 5 and 10 characters long!", "Warning");
            return false;
        }
        return true;
    }

    // Password length check.
    public bool CheckNewPasswordLength(string pass)
    {

        if (pass.Length < 5 || pass.Length > 16)
        {
            MessageBox.Show("Password needs to be between 5 and 16 characters.", "Warning!");
            return false;
        }
        return true;
    }

    // Confirms password. This method is intended for new users.
    public bool ConfirmNewPassword(string pass, string confirm)
    {
        if (pass == confirm)
        {
            return true;
        }
        MessageBox.Show("Your password does not match.", "Warning!");
        return false;
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

    // Method that returns user by its username.
    public User GetUser(string username)
    {
        foreach (IUser user in allUsers)
        {
            if (user.Username == username && !user.isAdmin)
            {
                return user as User;
            }
        }
        return null;
    }




}

