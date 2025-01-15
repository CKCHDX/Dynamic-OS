using System.Windows;

namespace Dynamic_Os
{
    public partial class ManageAppsWindow : Window
    {
        private CustomWindow _customWindow;

        // Pass CustomWindow reference to the constructor
        public ManageAppsWindow(CustomWindow customWindow)
        {
            InitializeComponent();
            _customWindow = customWindow;

            // Use CustomWindow's navigation method to navigate to ManageAppsPage
            MainFrame.Navigate(new ManageAppsPage(_customWindow));  // Pass CustomWindow reference to page
        }
    }
}
