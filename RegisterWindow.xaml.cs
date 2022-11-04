using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Interfaces;
using slutproj_TravelPal.Managers;
using slutproj_TravelPal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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


            // Setting the combobox to an enum with countries.
            SeedCountriesToBox();

            this.userManager = userManager;

            void SeedCountriesToBox()
            {
                // Get our enum and put it in an array
                string[] countries = Enum.GetNames(typeof(Countries));

                // Set the combobox content to countries, our enum with countries.
                cbCountries.ItemsSource = countries;
            }
        }

        // Checks if all user informations are in.
        private bool CheckInputs()
        {

            string username = txtUsername.Text;
            string password = pbPassword.Password;
            string confirmPass = pbConfirmPassword.Password;
            string country = cbCountries.SelectedItem as string;

            string[] fields = new[] { username, password, confirmPass, country };


            foreach (string field in fields)

            {
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Check your username or password.", "Warning!");
                    return false;
                }
                else if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Check your username or password.", "Warning!");
                    return false;
                }
                else if (string.IsNullOrEmpty(confirmPass))
                {
                    MessageBox.Show("Check your username or password.", "Warning!");
                    return false;
                }
                else if (string.IsNullOrEmpty(country))
                {
                    MessageBox.Show("You need to select a country mon.", "Warning!");
                    return false;
                }
            }
            return true;

        }


        // If inputs are valid, creates a new user.
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            if (CheckInputs() == true && userManager.ConfirmNewPassword(pbPassword.Password, pbConfirmPassword.Password))
            {
                if (cbCountries.SelectedItem == null)
                {
                    MessageBox.Show("You need to choose a country mon.", "Warning!");
                    return;
                }
                else
                {
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

                    if (userManager.AddUser(txtUsername.Text, pbPassword.Password, selectedCountry))
                    {
                        MainWindow mainWindow = new(userManager);

                        mainWindow.Show();

                        Close();
                    }
                }
            }
        }
        
        // Cancel and sends you back to main window. Nice to have if you already a user but wrongly clicked "Register" instead of sign in.
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            userManager.SignedInUser = null;

            MainWindow mainWindow = new(userManager);

            mainWindow.Show();

            Close();
        }
    }
}
