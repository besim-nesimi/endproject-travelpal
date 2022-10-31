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

            this.userManager = userManager;
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
                    MessageBox.Show("You have not entered all your informations.", "Warning!");
                    return false;
                }
                else if (password != confirmPassword)
                {
                    MessageBox.Show("Your passwords are not matching!", "Warning!");
                    return false;
                }
                else if (cbCountries.SelectedItem == null)
                {
                    MessageBox.Show("You have not chosen a country of origin!", "Warning!");
                    return false;
                }
            }

            // Funkar ej
            //if (password.Length > 5)
            //{
            //    MessageBox.Show("Your password is too short", "Warning!");
            //    return false;
            //}
            //return true;
            return true;

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs())
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
        }
    }
}
