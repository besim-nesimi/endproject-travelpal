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
            cbCountries.Text = userManager.SignedInUser.Location.ToString();
        }

        public UserDetailsWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;

            lblLoggedInUser.Content = userManager.SignedInUser.Username;
            lblLoggedInCountry.Content = userManager.SignedInUser.Location;

            string[] countries = Enum.GetNames(typeof(Countries));
            cbCountries.ItemsSource = countries;
            cbCountries.Text = userManager.SignedInUser.Location.ToString(); // Makes sure that the country combobox within UserDetailsWindow is already at users current location.
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
            TravelWindow travelWindow = new(userManager);

            travelWindow.Show();

            Close();
        }

        // Save new user details.
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cbCountries.SelectedItem.ToString()); 

            if (userManager.ValidateUsername(txtUsername.Text) && userManager.ConfirmNewPassword(pbPassword.Password, pbConfirmPassword.Password) && userManager.CheckNewPasswordLength(pbPassword.Password))
            {
                userManager.SignedInUser.Username = txtUsername.Text;
                userManager.SignedInUser.Password = pbPassword.Password;
            }
            else
            {
                return;
            }

            userManager.SignedInUser.Location = selectedCountry;

            TravelWindow travelWindow = new(userManager);

            travelWindow.Show();

            Close();
        }
    }
}
