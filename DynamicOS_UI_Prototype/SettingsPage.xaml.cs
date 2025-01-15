using System.Windows;
using System.Windows.Controls;

namespace Dynamic_Os
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // Event handler for the Mode Selection Button
        private void ModeSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            var settingWindow = new SettingWindow(); // No need to pass MainWindow explicitly
            settingWindow.ShowDialog(); // Open as a modal dialog
        }


    }
}
