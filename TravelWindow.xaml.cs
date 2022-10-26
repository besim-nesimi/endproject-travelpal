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
/// Interaction logic for TravelWindow.xaml
/// </summary>
public partial class TravelWindow : Window
{
    TravelManager travelManager;

    private UserManager userManager;

    public TravelWindow(UserManager userManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = new();

        lblUsernameDisplay.Content = userManager.SignedInUser.Username;

        // Vid knapptryck User details ska vi öppna upp UserDetailsWindow.
    }

    public TravelWindow(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;

        if(userManager.SignedInUser is User)
        {
            User signedInUser = userManager.SignedInUser as User;

            foreach(Travel travel in signedInUser.Travels)
            {
                lvTravels.Items.Add(travel.Destination);
            }
        }

        lblUsernameDisplay.Content = userManager.SignedInUser.Username;

        // Vid knapptryck User details ska vi öppna upp UserDetailsWindow.
    }

    private void btnUserDetails_Click(object sender, RoutedEventArgs e)
    {
        UserDetailsWindow userDetailsWindow = new(userManager);

        userDetailsWindow.Show();
    }

    private void btnAddTravel_Click(object sender, RoutedEventArgs e)
    {
        AddTravelWindow addTravelWindow = new(userManager, travelManager);

        addTravelWindow.Show();
    }

    private void btnSignOut_Click(object sender, RoutedEventArgs e)
    {

    }
}
