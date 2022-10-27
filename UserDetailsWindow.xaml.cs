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
        }

        public UserDetailsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            lblLoggedInUser.Content = userManager.SignedInUser.Username;
        }
    }
}
