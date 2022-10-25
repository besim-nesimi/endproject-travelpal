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
using slutproj_TravelPal.Enums;

namespace slutproj_TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
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

           /* int numOfTravellers = Convert.ToInt32(travellers); */// Funkar ej wtF? Exception Handling ? System.FormatException ?
        }
    }
}
