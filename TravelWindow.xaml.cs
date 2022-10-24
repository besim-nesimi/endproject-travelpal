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

namespace slutproj_TravelPal;

/// <summary>
/// Interaction logic for TravelWindow.xaml
/// </summary>
public partial class TravelWindow : Window
{
    private UserManager userManager;
    private User user;

    public TravelWindow(UserManager userManager, User user)
    {
        InitializeComponent();
        
        this.userManager = userManager;
        this.user = user;

        // Vid knapptryck User details ska vi öppna upp UserDetailsWindow.
    }
}
