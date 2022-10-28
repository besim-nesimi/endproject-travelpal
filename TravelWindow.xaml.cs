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
    private TravelManager travelManager;
    private UserManager userManager;

    public TravelWindow(UserManager userManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = new();

        SendTravelInfo();

        lblUsernameDisplay.Content = userManager.SignedInUser.Username;

        // Vid knapptryck User details ska vi öppna upp UserDetailsWindow.
    }

    public TravelWindow(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;

        SendTravelInfo();

        lblUsernameDisplay.Content = userManager.SignedInUser.Username;

        // Vid knapptryck User details ska vi öppna upp UserDetailsWindow.
    }


    // Lägger till resan som man lagt till på add travel window till travelwindows lista.
    private void SendTravelInfo()
    {
        if (userManager.SignedInUser is User)
        {
            User signedInUser = userManager.SignedInUser as User;

            foreach (Travel travel in signedInUser.Travels)
            {
                ListViewItem item = new();
                item.Tag = travel;
                item.Content = travel.GetInfo();
                lvTravels.Items.Add(item);
            }
        }
    }

    // Öppnar user details window, funkar som den ska.

    private void btnUserDetails_Click(object sender, RoutedEventArgs e)
    {
        UserDetailsWindow userDetailsWindow = new(userManager);

        userDetailsWindow.Show();

        Close();
    }

    // Öppnar add travel window, funkar som den ska.
    private void btnAddTravel_Click(object sender, RoutedEventArgs e)
    {
        AddTravelWindow addTravelWindow = new(userManager, travelManager);

        addTravelWindow.Show();

        Close();
    }

    // Loggar ut usern / admin. Färdig.
    private void btnSignOut_Click(object sender, RoutedEventArgs e)
    {
        userManager.SignedInUser = null;

        MainWindow mainWindow = new(userManager);

        mainWindow.Show();

        Close();
    }


    //Ska visa resan i detalj - knappen/klicket gör vad den ska - TravelDetailsWindow behöver göras klart.
    private void btnShowDetails_Click(object sender, RoutedEventArgs e)
    {
        ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

        Travel selectedTravel = selectedItem.Tag as Travel;

        travelManager.ShowDetails(selectedTravel);

        TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager);

        travelDetailsWindow.Show();

        Close();
    }
}
