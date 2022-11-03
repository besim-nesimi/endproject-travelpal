using slutproj_TravelPal.Enums;
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
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private UserManager userManager;
    private TravelManager travelManager;
    private Travel travel;
    public TravelDetailsWindow()
    {
        InitializeComponent();
    }

    public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel travel)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;
        this.travel = travel;

        if(travel is Trip) // If the selectedTravel from TravelWindow is a Trip, does this segment of the if statement.
        {
            Trip trip = travel as Trip;
            lblTravelType.Content = "Trip";

            string tripType = trip.Type.ToString();


            lblTripType.Visibility = Visibility.Visible;
            lblHeaderTypeOfTrip.Visibility = Visibility.Visible;
            lblTripType.Content = tripType;
            lblDestination.Content = trip.Destination.ToString();
            lblTravellers.Content = trip.Travellers.ToString();
            lblCountry.Content = trip.Country.ToString();
        }
        else if (travel is Vacation) // If the selectedTravel from TravelWindow is a Vacation, does this segment of the if statement.
        {
            Vacation vacation = travel as Vacation;

            lblTravelType.Content = "Vacation";

            xbAllInclusive.Visibility = Visibility.Visible;
            lblHeaderAllInclusive.Visibility = Visibility.Visible;
            xbAllInclusive.IsChecked = vacation.All_Inclusive;
            xbAllInclusive.IsEnabled = false;
            lblDestination.Content = vacation.Destination.ToString();
            lblTravellers.Content = vacation.Travellers.ToString();
            lblCountry.Content = vacation.Country.ToString();
        }


    }



    // Return to TravelWindow.
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TravelWindow travelWindow = new(userManager);

        travelWindow.Show();

        Close();
    }
}
