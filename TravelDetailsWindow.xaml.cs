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

namespace slutproj_TravelPal;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private UserManager userManager;
    private TravelManager travelManager;
    private Travel travel;
    public TravelDetailsWindow()
    {
        InitializeComponent();
    }

    public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel selectedTravel) // Hela klassen Travel och specifikt selectedTravel skickas med
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;
        this.travel = travel;


        
        // Denna kod visar såklart själva string[]array, såklart inte vilket utav dem selectedTravel är.
        /*lblTripTypeShow.Content = Enum.GetNames(typeof(TripTypes));*/ 

        //lblAllincl.Visibili
        
        // Hur gör jag en if-sats där om selectedTravel.TripTypes == Leisure så ska Content vara Leisure, och om det är work, så blir det work istället?
    }



    // Return to TravelWindow.
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TravelWindow travelWindow = new(userManager);

        travelWindow.Show();

        Close();
    }
}
