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


            // Hämtar vår enum typeOfTrips och lägger det i en array
            string[] travelTypes = Enum.GetNames(typeof(TravelTypes));

            // Vi sätter ComboBoxens innehåll till vår enum tripTypes
            cbTypeofTrip.ItemsSource = travelTypes;

            string travellers = tbTravellers.Text;
            this.userManager = userManager;
            this.travelManager = travelManager;

            /* int numOfTravellers = Convert.ToInt32(travellers); */// Funkar ej? Exception Handling ? System.FormatException ?
        }

        private void CheckInputsForTravel()
        {
            string travelType = cbTypeofTrip.SelectedItem as string;

            string destination = tbDestination.Text;

            int.TryParse(tbTravellers.Text, out int traveler);

            Countries country = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

            AddTravelToList(travelType, destination, traveler, country); // Hur kan jag få denna till att funka?
        }
        
        //Skapade två separata metoder som gör olika saker men hänger ihop. 
        //CheckInputsForTravel skickar över infon till AddTravelToList
        //På CheckInputsForTravel ska det finnas conditions för att Add Travel knappen ska bli klickbar.
        private void AddTravelToList(string TravelType, string destination, int traveler, Countries country) 
        {
            // Vad är selectat? Trip eller Vacation?

            if(TravelType == "Trip")
            { 
                Trip trip = new(TripTypes.Leisure, destination, country, traveler);

                User signedInUser = userManager.SignedInUser as User;

                signedInUser.Travels.Add(trip);
                userManager.SignedInUser = signedInUser;

                travelManager.Travels.Add(trip);
            }

            TravelWindow travelWindow = new(userManager, travelManager);

            travelWindow.Show();

            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            CheckInputsForTravel();
        }
    }
}
