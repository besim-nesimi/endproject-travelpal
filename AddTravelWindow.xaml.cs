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

            // Hämtar vår enum Countries och lägger det i en array
            string[] countries = Enum.GetNames(typeof(Countries));

            // Vi sätter ComboBoxens innehåll till vår enum countries
            cbCountries.ItemsSource = countries;


            // Hämtar vår enum travelTypes (vacation / trip) och lägger det i en array
            string[] travelTypes = Enum.GetNames(typeof(TravelTypes));

            // Vi sätter ComboBoxens innehåll till vår enum travelTypes
            cbTypeofTravel.ItemsSource = travelTypes;

            string travellers = tbTravellers.Text;
            this.userManager = userManager;
            this.travelManager = travelManager;

            /* int numOfTravellers = Convert.ToInt32(travellers); */// Funkar ej? Exception Handling ? System.FormatException ?
        }

        private void CheckInputsForTravel()
        {
            string travelType = cbTypeofTravel.SelectedItem as string;

            if (travelType == "Trip") // Funkar ej, flyttat den från AddTravelToList hit, funkar fortfarande inte
            {
                cbTypeOfTrip.IsEnabled = true;
                string[] tripTypes = Enum.GetNames(typeof(TripTypes));
                cbTypeOfTrip.ItemsSource = tripTypes;

            }
            else if (travelType == "Vacation") // Funkar ej, flyttat den från AddTravelToList
            {
                cbxAllInc.Visibility = Visibility.Visible;
                lblAllInclusive.Visibility = Visibility.Visible;
            }
            string destination = tbDestination.Text;
            int.TryParse(tbTravellers.Text, out int traveller);
            Countries country = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

            AddTravelToList(travelType, destination, traveller, country);
        }
        
        //Skapade två separata metoder som gör olika saker men hänger ihop. 
        //CheckInputsForTravel skickar över infon till AddTravelToList
        //På CheckInputsForTravel ska det finnas conditions för att Add Travel knappen ska bli klickbar.
        private void AddTravelToList(string travelType, string destination, int traveller, Countries country) 
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

        //private void GandalfTrips()
        //{
            
        //}
    }
}
