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

namespace slutproj_TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            // Get all the names of the countries enum
            string[] countries = Enum.GetNames(typeof(Countries)); // Hämtar vår enum Countries och lägger det i en array

            // Put the countries array in the combobox
            cbCountries.ItemsSource = countries; // Vi sätter ComboBoxens innehåll till vår array

            // Enable & disable buttons
            // När appen startar ska knapparna vara avstängd
            // Detta gör att våra knappar Show Details och Remove är utgråade.
            // Disable buttons
            btnRegister.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (CheckInputs())
            {
                btnRegister.IsEnabled = true;
            }
        }

        private bool CheckInputs()
        {

            // Tre sätt att kolla om samtliga variabler är ifyllda, den som inte är utkommenterad är snyggast

            string firstName = txtNull1.Text;
            string password = txtNull2.Text;
            string email = txtNull3.Text;
            string phoneNumber = txtNull4.Text;
            string country = cbCountries.SelectedItem as string;

            string[] fields = new[] { firstName, password, email, phoneNumber, country };

            foreach (string field in fields)
            {
                if (string.IsNullOrEmpty(field))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
