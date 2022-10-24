using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slutproj_TravelPal.Managers;

public class UserManager : User
{
    public List<User> users = new(); // Alla våra users i travelapp, clienter och admins

    public UserManager()
    {
        Admin admin = new();

        admin.Username = "admin";
        admin.Password = "password";

        users.Add(admin);
    }    
    
    public List<User> GetAllUsers()
    {
        return users;
    }

    public void AddUser(string username, string password)
    {
        Client client = new(username, password);

        client.Username = username;
        client.Password = password;

        users.Add(client);
    }


}

