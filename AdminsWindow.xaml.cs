using slutproj_TravelPal.Managers;
using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace slutproj_TravelPal;

/// <summary>
/// Interaction logic for AdminsWindow.xaml
/// </summary>
public partial class AdminsWindow : Window
{

    private List<Client> clients = new();
    private UserManager userManager;

    public AdminsWindow(UserManager userManager, User user)
    {
        InitializeComponent();

        this.userManager = userManager;

        FilterClients();
    }

    private void FilterClients()
    {
        List<User> users = new();

        users = this.userManager.GetAllUsers();

        foreach (User user in users)
        {
            if (user is Client)
            {
                clients.Add(user as Client);
            }
        }
    }
}
