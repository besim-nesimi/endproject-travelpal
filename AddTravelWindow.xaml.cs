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
        private readonly UserManager userManager;
        private readonly TravelManager travelManager;

        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;
           

            /* int numOfTravellers = Convert.ToInt32(travellers); */// Funkar ej? Exception Handling ? System.FormatException ? 

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

        //Skapade två separata metoder som gör olika saker men hänger ihop. 
        //CheckInputsForTravel skickar över infon till AddTravelToList
        //På CheckInputsForTravel ska det finnas conditions för att Add Travel knappen ska bli klickbar.

        private void CheckInputsForTravel()
        {
            string travelType = cbTypeofTravel.SelectedItem as string;
            string[] tripTypes = Enum.GetNames(typeof(TripTypes));
            string travellers = tbTravellers.Text;

            int numOfTravellers = Convert.ToInt32(travellers);

            cbTypeOfTrip.ItemsSource = tripTypes;
            string destination = tbDestination.Text;
            int.TryParse(tbTravellers.Text, out int traveller);
            Countries country = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

            AddTravelToList(travelType, destination, traveller, country); // nödvändigt ens?
        }
        
        private void AddTravelToList(string travelType, string destination, int traveller, Countries country) // Nödvändigt ?? Kan jag inte bara lägga selectionChanged på listview itemet?
        {
            // Vad är selectat? Trip eller Vacation?
            

            if (travelType == "Trip") // Trip är selectat
            {

                // ändra så att det blir det som selectas på triptypes

                Trip trip = new(TripTypes.Leisure, destination, country, traveller); // Är det work eller leisure?

                User signedInUser = userManager.SignedInUser as User;

                signedInUser.Travels.Add(trip);
                userManager.SignedInUser = signedInUser;

                travelManager.Travels.Add(trip);
            }
            else if (travelType == "Vacation") // Checkbox för allinc ska kunna dyka upp, funkar ännu inte
            {

                Vacation vacation = new(TravelTypes.Vacation, destination, country, traveller); // ska finnas vacation
                
                User signedInUser = userManager.SignedInUser as User;

                signedInUser.Travels.Add(vacation);
                userManager.SignedInUser = signedInUser;

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

        private void tbTravellers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

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

        private void cbTypeOfTrip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void GandalfTrips()
        //{

        //}
    }
}
