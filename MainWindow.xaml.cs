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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slutproj_TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager = new(); // UserManager håller alla våra users, den har listan med clients och admins. 
        public MainWindow()
        {
            InitializeComponent();

            //userManager.DefaultUsers();
        }

        public MainWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager); // Vi skickar userManager till RegisterWindow

            registerWindow.Show();

            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Kolla om användaren finns
            List<IUser> allUsers = userManager.GetAllUsers();

            string username = tbUsername.Text;
            string password = pbPassword.Password;
            bool hasFoundUser = userManager.SignInUser(username, password);

            if(hasFoundUser)
            {
                TravelWindow travelWindow = new(userManager);
                travelWindow.Show();
                Close();
            }

            else if (!hasFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }
        }
    }
}
