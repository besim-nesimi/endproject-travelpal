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

namespace slutproj_TravelPal;

/// <summary>
/// Interaction logic for TravelWindow.xaml
/// </summary>
public partial class TravelWindow : Window
{
    private TravelManager travelManager;
    private UserManager userManager;
    private Travel travel;

    public TravelWindow(UserManager userManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = new();


        // Shows all the travels of that specific signed in user in the listview.

        SendTravelInfo();


        // Displays the username of the user somewhere in the TravelWindow.

        lblUsernameDisplay.Content = userManager.SignedInUser.Username;
        


        // If the signed in user is admin, the buttons "Show User Details" - "Add Travel" - "Info" will be hidden.

        if (userManager.SignedInUser.isAdmin)
        {
            btnUserDetails.Visibility = Visibility.Hidden;
            btnAddTravel.Visibility = Visibility.Hidden;
            btnInfo.Visibility = Visibility.Hidden;
            ___imgPil_.Visibility = Visibility.Hidden;
            return;
        }

        
    }

    public TravelWindow(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;


        // Shows all the travels of that specific signed in user in the listview.

        SendTravelInfo();

        // Displays the username of the user somewhere in the TravelWindow.

        lblUsernameDisplay.Content = userManager.SignedInUser.Username;


        // If the signed in user is admin, the buttons "Show User Details" - "Add Travel" - "Info" will be hidden.
        // Admins do not need to change name or travel or read informations of any kind. 

        if (userManager.SignedInUser.isAdmin)
        {
            btnUserDetails.Visibility = Visibility.Hidden;
            btnAddTravel.Visibility = Visibility.Hidden;
            return;
        }

    }

    // Adds the travel into the travelwindow 
    private void SendTravelInfo()
    {
        if (userManager.SignedInUser is User)
        {
            User signedInUser = userManager.SignedInUser as User;

            foreach (Travel travel in signedInUser.Travels)
            {
                ListViewItem item = new();
                item.Tag = travel;
                item.Content = travel.GetInfo();
                lvTravels.Items.Add(item);
            }
        }
        else if (userManager.SignedInUser is Admin)
        {
            var nonAdminUsers = userManager.GetAllUsers().Where(x => x.isAdmin != true); 

            foreach (User user in nonAdminUsers)
            {
                foreach (Travel travel in user.Travels)
                {
                    ListViewItem item = new();
                    item.Tag = travel;
                    item.Content = travel.GetInfo();
                    lvTravels.Items.Add(item);
                }

            }
        }
    }

    // Opens user details window.

    private void btnUserDetails_Click(object sender, RoutedEventArgs e)
    {

        UserDetailsWindow userDetailsWindow = new(userManager);

        userDetailsWindow.Show();

        Close();
    }

    // Opens up the add travel window.
    private void btnAddTravel_Click(object sender, RoutedEventArgs e)
    {
        AddTravelWindow addTravelWindow = new(userManager, travelManager);

        addTravelWindow.Show();

        Close();
    }

    // Signs off user / admin.
    private void btnSignOut_Click(object sender, RoutedEventArgs e)
    {
        userManager.SignedInUser = null;

        MainWindow mainWindow = new(userManager);

        mainWindow.Show();

        Close();
    }


    // Shows the travel in detail.
    private void btnShowDetails_Click(object sender, RoutedEventArgs e)
    {

        ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

        if(selectedItem == null)
        {
            SelectForInfo();
        }
        else if (selectedItem.Tag != null)
        {
            Travel travel = selectedItem.Tag as Travel;

            TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager, travel);

            travelDetailsWindow.Show();

            Close();
        }
    }


    // If a user is signed in, they can remove the travel by clicking on it and then RemoveTravel button.
    private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
    {

        ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

        if (selectedItem == null)
        {
            SelectForDelete();
        }
        else if(userManager.SignedInUser is User)
        {
            User user = userManager.SignedInUser as User;

            Travel selectedTravel = selectedItem.Tag as Travel;

            user.Travels.Remove(selectedTravel);

            lvTravels.Items.Clear();

            SendTravelInfo();
        }
        else if (userManager.SignedInUser is Admin) // If an admin is logged in, the admin can view and remove any selected travel.
        {

            Travel selectedTravel = selectedItem.Tag as Travel;

            User user = userManager.GetUser(selectedTravel.userID);

            user.Travels.Remove(selectedTravel);

            lvTravels.Items.Clear();

            SendTravelInfo();
        }

    }

    // Default method that screams if you have not clicked on a travel item.
    private void SelectForInfo()
    {
        MessageBox.Show("You need to select a travel to see any details!", "Warning!");
    }

    // Clicking on "Remove travel" button without selecting a travel will make this message pop up.
    private void SelectForDelete()
    {
        MessageBox.Show("You need to select a travel you want to remove!", "Warning!");
    }


    // In case of doubt, follow your nose. Informations message box when clicking on the info button.
    private void btnInfo_Click(object sender, RoutedEventArgs e)
    {
        string welcomeAboutMessage = "Welcome to TravelPal!" +
            "\nThe button 'Show User Details' lets you change your user information such as username, password and country of origin.\n" +
            "\nThe button 'Add Travel' will send you to a new window where you can add travel information and then view it in the travel window.\n" +
            "\nThe button 'Remove Travel' lets you remove a travel from your view.\n" +
            "\nThe button 'Show Travel Details' will send you to a new window where you can see all information of the specific trip you chose from the list view.\n" + 
            "\nThank you for using TravelPal for your future travels!\n";

        MessageBox.Show(welcomeAboutMessage, "Welcome to TravelPal!");
        return;
    }
}
