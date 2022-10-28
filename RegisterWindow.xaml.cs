using slutproj_TravelPal.Enums;
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
            
            // Hämtar vår enum Countries och lägger det i en array
            string[] countries = Enum.GetNames(typeof(Countries)); 
            
            // Vi sätter ComboBoxens innehåll till vår enum countries
            cbCountries.ItemsSource = countries; 

            // Enable & disable buttons
            // När appen startar ska knapparna vara avstängd
            btnRegister.IsEnabled = false;

            this.userManager = userManager;
        }


        // Gör så att knappen Register blir klickbar om allt är ifyllt.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CheckInputs())
            {
                btnRegister.IsEnabled = true;
            }
        }

        private bool CheckInputs()
        {

            // Kollar så att allt är ifyllt
            string username = txtUsername.Text;
            string password = pbPassword.Password;
            string confirmPassword = pbConfirmPassword.Password;
            string country = cbCountries.SelectedItem as string;

            string[] fields = new[] { username, password, confirmPassword, country };

            foreach (string field in fields)
            {
                if (string.IsNullOrEmpty(field))
                {
                    return false;
                }
            }

            return true;
        }

        // Kollar så att ett land är valt innan knappen blir klickbar.
        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckInputs())
            {
                    btnRegister.IsEnabled = true;
            }
        }

        // Register knappens logik
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInputs())
            {
                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

                if (userManager.AddUser(txtUsername.Text, pbPassword.Password, selectedCountry))
                {
                    // Lyckats skapa en user

                    MainWindow mainWindow = new(userManager);

                    mainWindow.Show();

                    Close();
                }

                else
                {
                    MessageBox.Show("Username already exists!", "Error!");
                }
            }    
            else
            {
                MessageBox.Show("Check your inputs!", "Error!");
            }

        }
    }
    
}
