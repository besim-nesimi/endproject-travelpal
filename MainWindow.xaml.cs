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

            userManager.DefaultUsers();
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
            string password = tbPassword.Text;

           
            bool isFoundUser = userManager.SignInUser(username, password);

            //foreach (IUser thisUser in allUsers)
            //{

            //if (thisUser.Username == username && thisUser.Password == password)
            //{
            //    // logga in

                    isFoundUser = true;


                    if (isFoundUser)
                    {
                        TravelWindow travelWindow = new(userManager); // vi skickar userManager till travelwindow

                        travelWindow.Show();

                        Close();

                    }

            
            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is Incorrect", "Warning");
            }
        }
    }
}
