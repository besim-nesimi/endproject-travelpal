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

        private List<IUser> allUsers = new(); // Här har vi hela listan med users, och vi hämtar den från User klassen
        private UserManager userManager = new(); // UserManager håller alla våra users, den har listan med clients och admins. 
        public MainWindow()
        {
            InitializeComponent();

            userManager.DefaultUsers();
        }

        public MainWindow(UserManager userManager)
        {
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
            allUsers = userManager.GetAllUsers(); // funkar denna ens?

            string username = tbUsername.Text;
            string password = tbPassword.Text;

            bool isFoundUser = false;

            foreach (IUser thisUser in allUsers)
            {

                if (thisUser.Username == username && thisUser.Password == password)
                {
                    // logga in
                    isFoundUser = true;


                    if (thisUser is User)
                    {
                        TravelWindow travelWindow = new(userManager, thisUser, allUsers); // vi skickar userManager till travelwindow

                        travelWindow.Show();

                    }
                    else if (thisUser is Admin)
                    {
                        TravelWindow travelWindow = new(userManager, thisUser, allUsers);

                        travelWindow.Show();
                    }
                }

            }
            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is Incorrect", "Warning");
            }
        }
    }
}
