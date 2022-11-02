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

            // Get our enum and put it in an array
            string[] countries = Enum.GetNames(typeof(Countries));

            // Set the combobox content to countries, our enum with countries.
            cbCountries.ItemsSource = countries;

            this.userManager = userManager;
        }

        // Checks if all user informations are in.
        private bool CheckInputs()
        {

            string username = txtUsername.Text;
            string password = pbPassword.Password;
            string confirmPassword = pbConfirmPassword.Password;
            string country = cbCountries.SelectedItem as string;


            userManager.CheckUserLenght(username);
            userManager.CheckNewPasswordLength(password);
            userManager.ConfirmNewPassword(password, confirmPassword);


            string[] fields = new[] { username, password, confirmPassword, country };


            foreach (string field in fields)

            {
                if (!string.IsNullOrEmpty(field))
                {
                    return true;
                }
                else if (string.IsNullOrEmpty(country))
                {
                    MessageBox.Show("You need to select a country mon.", "Warning!");
                    return false;
                }
            }
            MessageBox.Show("You have not entered all your informations.", "Warning!");
            return false;

        }


        // If inputs are valid, creates a new user.
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            if (CheckInputs())
            {
                if (cbCountries.SelectedItem != null)
                {
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

                    if (userManager.AddUser(txtUsername.Text, pbPassword.Password, selectedCountry))
                    {
                        MainWindow mainWindow = new(userManager);

                        mainWindow.Show();

                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("You need to choose a country mon.", "Warning!");
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            userManager.SignedInUser = null;

            MainWindow mainWindow = new(userManager);

            mainWindow.Show();

            Close();
        }
    }
}
