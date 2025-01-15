using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Dynamic_Os
{
    public partial class DeleteAppPage : Page
    {
        public DeleteAppPage()
        {
            InitializeComponent();
            LoadInstalledApps();
        }

        private void LoadInstalledApps()
        {
            string[] registryKeys = {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
            };

            foreach (var registryKey in registryKeys)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
                {
                    if (key != null)
                    {
                        foreach (var subKeyName in key.GetSubKeyNames())
                        {
                            using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                            {
                                string appName = subKey.GetValue("DisplayName") as string;
                                string uninstallString = subKey.GetValue("UninstallString") as string;

                                if (!string.IsNullOrEmpty(appName) && !string.IsNullOrEmpty(uninstallString))
                                {
                                    // Create a button for the app
                                    Button appButton = new Button
                                    {
                                        Content = appName,
                                        Style = (Style)FindResource("ModernButtonStyle"),
                                        Margin = new Thickness(5),
                                        Tag = uninstallString
                                    };

                                    appButton.Click += AppButton_Click;
                                    InstalledAppsList.Children.Add(appButton);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AppButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string uninstallString = button.Tag?.ToString();

            if (!string.IsNullOrEmpty(uninstallString))
            {
                try
                {
                    // Run the uninstall command
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/C \"{uninstallString}\"",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to uninstall app: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
