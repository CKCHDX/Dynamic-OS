using System.Windows;
using System.Windows.Controls;
using Dynamic_Os; // Add this if not already present

namespace Dynamic_Os
{
    public partial class ManageAppsPage : Page
    {
        private CustomWindow _customWindow; // Reference to CustomWindow
        public ManageAppsPage(CustomWindow customWindow)
        {
            InitializeComponent();
            _customWindow = customWindow; // Store reference to CustomWindow
        }

        private void AddApp_Click(object sender, RoutedEventArgs e)
        {
            // Pass both CustomWindow and MainWindow to FileExplorerPage
            _customWindow.NavigateToPage(new FileExplorerPage(_customWindow, Application.Current.MainWindow as MainWindow));
        }



        private void DeleteApp_Click(object sender, RoutedEventArgs e)
        {
            _customWindow.NavigateToPage(new DeleteAppPage());
        }

        private void ManageApp_Click(object sender, RoutedEventArgs e)
        {
            _customWindow.NavigateToPage(new ManageAppPage());
        }
    }
}
