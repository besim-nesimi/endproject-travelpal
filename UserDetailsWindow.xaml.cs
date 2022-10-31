using slutproj_TravelPal.Enums;
using slutproj_TravelPal.Managers;
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

            if (userManager.ValidateUsername(txtUsername.Text) && CheckNewPassword())
            {
                userManager.SignedInUser.Username = txtUsername.Text;
                userManager.SignedInUser.Password = pbPassword.Password;
                userManager.SignedInUser.Location = selectedCountry;

                TravelWindow travelWindow = new(userManager);

                travelWindow.Show();

                Close();
            }
            else
            {
                MessageBox.Show("Username already exists or passwords don't match!", "Error!");
            }
        }

        private bool CheckNewPassword()
        {

            string newPassword = pbPassword.Password;
            string confirmPassword = pbConfirmPassword.Password;

            if (newPassword == confirmPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
