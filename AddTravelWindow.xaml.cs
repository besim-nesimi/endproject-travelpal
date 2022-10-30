using System;
using System.Collections.Generic;
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

        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            AddSources();

        }

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

        //public void DefaultAddTravel()
        //{
        //    AddTravelToList();
        //}

        //Skapade två separata metoder som gör olika saker men hänger ihop. 
        //CheckInputsForTravel skickar över infon till AddTravelToList
        //På CheckInputsForTravel ska det finnas conditions för att Add Travel knappen ska bli klickbar.


        private void CheckInputsForTravel()
        {
            int numOfTravellers = 0;
            string travellers = tbTravellers.Text;

            try
            {
                numOfTravellers = Convert.ToInt32(travellers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please write numbers in the traveller box", "Warning!");
                return;
            }

            string travelType = cbTypeofTravel.SelectedItem as string;
            string[] tripTypes = Enum.GetNames(typeof(TripTypes));
            cbTypeOfTrip.ItemsSource = tripTypes;

            string destination = tbDestination.Text;

            Countries country = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

            AddTravelToList(travelType, destination, numOfTravellers!, country);
        }
        
        private void AddTravelToList(string travelType, string destination, int traveller, Countries country) // Nödvändigt ?? Kan jag inte bara lägga selectionChanged på listview itemet?
        {
            // Vad är selectat? Trip eller Vacation?

            User signedInUser = userManager.SignedInUser as User;

            if (travelType == "Trip") // Trip är selectat
            {
                TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), cbTypeOfTrip.SelectedItem.ToString()); // Gör så att våra TripTypes "Leisure" och "Work" blir valbara i comboboxen.

                Trip trip = new(tripType, destination, country, traveller); // Lägg till "Trip" med samtliga parametrar ifyllda.
                signedInUser.Travels.Add(trip);
                travelManager.Travels.Add(trip);

            }
            else if (travelType == "Vacation") // Checkbox för allinc ska kunna dyka upp, funkar ännu inte
            {

                Vacation vacation = new(destination, country, traveller); // ska finnas vacation
                signedInUser.Travels.Add(vacation);

                travelManager.Travels.Add(vacation);
            }

            TravelWindow travelWindow = new(userManager, travelManager);

            travelWindow.Show();

            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            CheckInputsForTravel();
                
        }

        private void cbTypeofTravel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            cbTypeofTravel.SelectedItem = Enum.GetNames(typeof(TravelTypes)); // Måste jag dela upp TravelTypes till lokala variabler som kan läsas i en if-sats? Hur?

            if (cbTypeofTravel.SelectedItem.ToString().Equals("Vacation")) /*Enum.Parse(Enum.TravelType, value)*/ // varken selectedItem eller selectedValue funkar.
            {
                lblAllInclusive.Visibility = Visibility.Visible;
                cbxAllInc.Visibility = Visibility.Visible;
                cbTypeOfTrip.Visibility = Visibility.Hidden;
            }
            else if (cbTypeofTravel.SelectedItem.ToString().Equals("Trip")) // varken selectedItem eller selectedValue funkar.
            {
                cbTypeOfTrip.Visibility = Visibility.Visible;
                cbTypeOfTrip.IsEnabled = true;
                lblAllInclusive.Visibility = Visibility.Hidden;
                cbxAllInc.Visibility = Visibility.Hidden;
            }
        }

        // behövs denna till något?

        private void tbTravellers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // behövs denna till något?

        private void tbDestination_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCountries.SelectedItem != null)
            {
                cbTypeofTravel.IsEnabled = true;
            }
        }

        // Behövs denna till något?

        private void cbTypeOfTrip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
