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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;

        public UserDetailsWindow()
        {
            InitializeComponent();

            string[] countries = Enum.GetNames(typeof(Countries));

            cbCountries.ItemsSource = countries;
        }

        public UserDetailsWindow(UserManager userManager)
        {

            InitializeComponent();

            this.userManager = userManager;

            lblLoggedInUser.Content = userManager.SignedInUser.Username;
            lblLoggedInCountry.Content = userManager.SignedInUser.Location;

            string[] countries = Enum.GetNames(typeof(Countries));

            cbCountries.ItemsSource = countries;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
            TravelWindow travelWindow = new(userManager);

            travelWindow.Show();

            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString());

            if (userManager.ValidateUsername(txtUsername.Text))
            {
                if (CheckUserLenght(txtUsername.Text))
                {
                    userManager.SignedInUser.Username = txtUsername.Text;
                }
            }
            else
            {
                MessageBox.Show("That username is already in use.", "Warning");
                return;
            }

            if(ConfirmNewPassword(pbPassword.Password, pbConfirmPassword.Password) && CheckNewPasswordLength(pbPassword.Password))
            {
                userManager.SignedInUser.Password = pbPassword.Password;
            }

            selectedCountry = userManager.SignedInUser.Location;

            if(selectedCountry == null)
            {
                MessageBox.Show("You need to pick a country of origin.");
                return;
            }



            TravelWindow travelWindow = new(userManager);

            travelWindow.Show();

            Close();
        }


        // Method makes sure the username length is between 3 and 10 characters.
        private bool CheckUserLenght(string newName)
        {
            string newUsername = txtUsername.Text;

            if(newUsername.Length < 3 || newUsername.Length > 10)
            {
                MessageBox.Show("The username must be between 3 and 10 characters long!", "Warning");
                return false;
            }
            return true;
        }

        private bool ConfirmNewPassword(string pass, string confirm)
        {
            string newPassword = pbPassword.Password;
            string confirmPassword = pbConfirmPassword.Password;

            if(newPassword == confirmPassword)
            {
                return true;
            }
            MessageBox.Show("Your password does not match.", "Warning!");
            return false;
        }


        // Are the new passwords the same & longer than 5 characters/digits?
        private bool CheckNewPasswordLength(string pass)
        {

            string newPassword = pbPassword.Password;

            if (newPassword.Length < 5 || newPassword.Length > 16)
            {
                MessageBox.Show("Password needs to be between 5 and 16 characters.", "Warning!");
                return false;
            }
            return true;
        }
    }
}
