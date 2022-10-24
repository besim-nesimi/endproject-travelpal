using slutproj_TravelPal.Interfaces;
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

    private UserManager userManager;
    private IUser user;

    public AdminsWindow(UserManager userManager, IUser user)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.user = user;

        FilterClients();
    }

    private void FilterClients()
    {
        List<IUser> allUsers = new();

        allUsers = userManager.GetAllUsers();

        foreach (IUser user in allUsers)
        {
            if (user is User)
            {
                allUsers.Add(user as User);
            }
        }
    }
}
