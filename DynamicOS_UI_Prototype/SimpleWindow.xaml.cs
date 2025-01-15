using System.Windows;

namespace Dynamic_Os
{
    public partial class SimpleWindow : Window
    {
        public SimpleWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Visibility = Visibility.Visible;
            SettingsGrid.Visibility = Visibility.Collapsed;
            ContentText.Text = "Welcome to Dynamic-OS(Simple Mode)";
        }

        private void ProgramsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Visibility = Visibility.Visible;
            SettingsGrid.Visibility = Visibility.Collapsed;
            ContentText.Text = "Programs functionality coming soon!";
        }

        private void PhotosButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Visibility = Visibility.Visible;
            SettingsGrid.Visibility = Visibility.Collapsed;
            ContentText.Text = "View and manage your photos and videos!";
        }

        private void InternetButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Visibility = Visibility.Visible;
            SettingsGrid.Visibility = Visibility.Collapsed;
            ContentText.Text = "Browse the internet with ease!";
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Visibility = Visibility.Visible;
            SettingsGrid.Visibility = Visibility.Collapsed;
            ContentText.Text = "Help and guidance will be available here.";
        }

        private void PowerOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Visibility = Visibility.Visible;
            SettingsGrid.Visibility = Visibility.Collapsed;
            ContentText.Text = "Select an option below:";
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Show Settings content
            ContentText.Visibility = Visibility.Collapsed;
            SettingsGrid.Visibility = Visibility.Visible;
        }

        private void ChangeModeButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the SettingWindow and pass the current SimpleWindow
            var settingWindow = new SettingWindow(this);
            settingWindow.ShowDialog(); // Open as a modal dialog
        }

    }
}
