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

namespace slutproj_TravelPal;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private UserManager userManager;
    private TravelManager travelManager;
    public TravelDetailsWindow()
    {
        InitializeComponent();

        // vi ska kunna se information om resan.
    }

    public TravelDetailsWindow(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TravelWindow travelWindow = new(userManager);

        travelWindow.Show();

        Close();
    }
}
