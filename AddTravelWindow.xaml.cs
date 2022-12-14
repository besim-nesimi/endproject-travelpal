using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
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
using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Managers;
using slutproj_TravelPal.Models;

namespace slutproj_TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        private Vacation vacation;
        bool isBoxChecked = false;

        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;


            // Adds the sources to the AddTravelWindow constructor body, no need now to call the sources within other functions. 
            AddSources();

        }


        // Adds the arrays of enums countries, traveltypes and triptypes to their respective comboboxes.
        private void AddSources()
        {
            // Hämtar vår enum Countries och lägger det i en array & sätter ComboBoxens innehåll till vår enum countries
            string[] countries = Enum.GetNames(typeof(Countries));
            cbCountries.ItemsSource = countries;


            // Hämtar vår enum travelTypes (vacation / trip) och lägger det i en array & sätter ComboBoxens innehåll till vår enum travelTypes
            string[] travelTypes = Enum.GetNames(typeof(TravelTypes));
            cbTypeofTravel.ItemsSource = travelTypes;


            // Hämtar vår enum tripTypes (leisure / work) och lägger det i en array & sätter ComboBoxens innehåll till vår enum tripTypes
            string[] tripTypes = Enum.GetNames(typeof(TripTypes));
            cbTypeOfTrip.ItemsSource = tripTypes;
        }


        // Method to check and catch exceptions of the users input before sending the formatted and correct input to add travel.
        private bool CheckInputsForTravel()
        {
            int numOfTravellers = 0;
            string travellers = tbTravellers.Text;

            if (cbCountries.SelectedItem == null)
            {
                MessageBox.Show("Please select a country!", "Warning");
                return false;
            }

            if (cbTypeofTravel.SelectedItem == null)
            {
                MessageBox.Show("Please select type of travel!", "Warning!");
                return false;
            }

            try
            {
                numOfTravellers = Convert.ToInt32(travellers);

                if (numOfTravellers <= 0)
                {
                    return false;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please write numbers in the traveller box", "Warning!");
                return false;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Warning!");
                return false;
            }

            if(string.IsNullOrEmpty(tbDestination.Text))
            {
                MessageBox.Show("Please add purpose of visit", "Warning!");

                return false;
            }

            return true;
        }
        

        // Takes the formatted input from CheckInputsForTravel and creates a travel
        private void AddTravelToList(string travelType, string destination, int traveller, Countries country)
        {

            User signedInUser = userManager.SignedInUser as User;

            bool isBoxChecked = false;

            if (travelType == "Trip") // Trip is selected
            {
                if (cbTypeOfTrip.SelectedItem == null) // If no type of trip is chosen, warning will appear.
                {
                    MessageBox.Show("You have not chosen type of trip!", "Warning!");
                    return;
                }
                else // Creates the trip.
                {
                    TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), cbTypeOfTrip.SelectedItem.ToString()); // What kind of trip is chosen? Leisure or Work?
                    Trip trip = new(tripType, destination, country, traveller, userManager.SignedInUser.Username); // Create the trip.
                    signedInUser.Travels.Add(trip); // Add the trip to the signed in user list of travels.
                    travelManager.Travels.Add(trip); // Add the trip to the travelManager list of travels (this is only accessible by the admin).
                }

            }
            else if (travelType == "Vacation") // Vacation is selected
            {
                Vacation vacation = new(destination, country, traveller, userManager.SignedInUser.Username, isBoxChecked); // Creates the vacation.

                if (xbAllInclusive.IsChecked == true) // If the checkbox is clicked, then it will set the boolean to true.
                {
                    isBoxChecked = true;
                }

                if (isBoxChecked == true) // If the boolean is true, it will set the property "All_Inclusive" to true within the Vacation class.
                {
                    vacation.All_Inclusive = true;
                }

                signedInUser.Travels.Add(vacation); // Add the vacation to the signed in user list of travels.

                travelManager.Travels.Add(vacation); // Add the vacation to the travelManager list of travels (this is only accessible by the admin).
            }

            TravelWindow travelWindow = new(userManager, travelManager);

            travelWindow.Show();

            Close();
        }


        // Adds the travel to the listview.
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInputsForTravel())
            {
                string travellers = tbTravellers.Text;

                int numOfTravellers = Convert.ToInt32(travellers);

                string travelType = cbTypeofTravel.SelectedItem as string;

                string destination = tbDestination.Text;

                Countries country = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

                AddTravelToList(travelType, destination, numOfTravellers, country);
            }
        }


        // Checks if its vacation or trip, then hides relevant buttons/labels and displays relevant buttons/labels. NOT WORKING
        private void cbTypeofTravel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            cbTypeofTravel.SelectedItem = Enum.GetNames(typeof(TravelTypes));

            if (cbTypeofTravel.SelectedItem.ToString().Equals("Vacation"))
            {

                lblAllInclusive.Visibility = Visibility.Visible;
                xbAllInclusive.Visibility = Visibility.Visible;
                cbTypeOfTrip.Visibility = Visibility.Hidden;

            }
            else if (cbTypeofTravel.SelectedItem.ToString().Equals("Trip")) // varken selectedItem eller selectedValue funkar.
            {
                cbTypeOfTrip.Visibility = Visibility.Visible;
                cbTypeOfTrip.IsEnabled = true;
                lblAllInclusive.Visibility = Visibility.Hidden;
                xbAllInclusive.Visibility = Visibility.Hidden;
            }
        }


        // If no country has been chosen, travel type will not be enabled to pick.
        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCountries.SelectedItem != null)
            {
                cbTypeofTravel.IsEnabled = true;
            }
        }

        // Returns you to travelwindow.
        private void btnCancelReturn_Click(object sender, RoutedEventArgs e)
        {
          
            TravelWindow travelWindow = new(userManager);

            travelWindow.Show();

            Close();
        }

    }
}
