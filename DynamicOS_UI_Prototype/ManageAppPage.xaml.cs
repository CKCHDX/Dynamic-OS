using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Dynamic_Os
{
    public partial class ManageAppPage : Page
    {
        private string _selectedAppPath;

        public ManageAppPage()
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
                                string installPath = subKey.GetValue("InstallLocation") as string;
                                string version = subKey.GetValue("DisplayVersion") as string;

                                if (!string.IsNullOrEmpty(appName) && !string.IsNullOrEmpty(installPath))
                                {
                                    Button appButton = new Button
                                    {
                                        Content = appName,
                                        Style = (Style)FindResource("ModernButtonStyle"),
                                        Margin = new Thickness(5),
                                        Tag = new { Path = installPath, Version = version }
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
            dynamic tagData = button.Tag;

            string appPath = tagData.Path;
            string appVersion = tagData.Version;

            _selectedAppPath = appPath;

            // Update details
            AppNameText.Text = button.Content.ToString();
            AppPathText.Text = $"Path: {appPath}";
            AppVersionText.Text = $"Version: {appVersion}";
            AppSizeText.Text = $"Size: {GetDirectorySize(appPath)} MB";
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedAppPath) && Directory.Exists(_selectedAppPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _selectedAppPath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Folder not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RunApp_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedAppPath))
            {
                // Find the first .exe file in the folder
                string exeFile = Directory.GetFiles(_selectedAppPath, "*.exe", SearchOption.TopDirectoryOnly)
                                           .FirstOrDefault();

                if (!string.IsNullOrEmpty(exeFile))
                {
                    try
                    {
                        // Run the .exe file
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = exeFile,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to run the app: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No executable file found in the folder!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("No application selected or invalid path!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private double GetDirectorySize(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    long size = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories)
                        .Sum(file => new FileInfo(file).Length);
                    return Math.Round(size / (1024.0 * 1024.0), 2); // Convert bytes to MB
                }
            }
            catch
            {
                // Handle errors (e.g., inaccessible directories)
            }

            return 0;
        }
    }
}
