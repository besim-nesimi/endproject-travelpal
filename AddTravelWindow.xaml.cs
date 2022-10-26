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
            string[] typeOfTrips = Enum.GetNames(typeof(TripTypes));

            // Vi sätter ComboBoxens innehåll till vår enum tripTypes
            cbTypeofTrip.ItemsSource = typeOfTrips;

            string travellers = tbTravellers.Text;
            this.userManager = userManager;
            this.travelManager = travelManager;



            /* int numOfTravellers = Convert.ToInt32(travellers); */// Funkar ej wtF? Exception Handling ? System.FormatException ?
        }



        private void AddTravel()
        {
            //ListViewItem travels = new();

            //travels.Content = .GetInfo();

            string tripType = cbTypeofTrip.SelectedItem as string;

            bool v = int.TryParse(tbTravellers.Text, out int result);
            int traveller = v;

            try
            {
                //int travellers = Convert.ToInt32(tbTravellers.Text)
                if (int.TryParse(tbTravellers.Text, out int travellers1))
                {
                    throw new ArgumentException("error");
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

           

            Countries country = ;
            

            Travel travel = new(tripType, country, traveller);

            User signedInUser = userManager.SignedInUser as User;

            signedInUser.Travels.Add(travel);
            userManager.SignedInUser = signedInUser;

            travelManager.Travels.Add(travel);

            TravelWindow travelWindow = new(userManager, travelManager);

            travelWindow.Show();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravel();
        }
    }
}
