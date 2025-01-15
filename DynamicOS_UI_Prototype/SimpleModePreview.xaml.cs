using System.Windows;
using System.Windows.Controls;

namespace Dynamic_Os.Previews
{
    public partial class SimpleModePreview : UserControl
    {
        public SimpleModePreview()
        {
            InitializeComponent();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "Welcome to Dynamic-OS(Simple Mode)";
        }
        private void ProgramsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "Programs functionality coming soon!";
        }

        private void PhotosButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "View and manage your photos and videos!";
        }

        private void InternetButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "Browse the internet with ease!";
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "Help and guidance will be available here.";
        }

        private void PowerOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "Select an option below:";
            ShutDownButton.Visibility = Visibility.Visible;
            RestartButton.Visibility = Visibility.Visible;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = "Settings functionality coming soon!";
            ShutDownButton.Visibility = Visibility.Collapsed;
            RestartButton.Visibility = Visibility.Collapsed;
        }

        private void ShutDownButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("System will shut down soon.", "Shut Down", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("System will restart soon.", "Restart", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
