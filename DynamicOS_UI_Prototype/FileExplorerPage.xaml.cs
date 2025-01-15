using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Shell;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace Dynamic_Os
{
    public partial class FileExplorerPage : Page
    {
        private CustomWindow _customWindow;
        private MainWindow _mainWindow;

        // Constructor to accept both CustomWindow and MainWindow
        public FileExplorerPage(CustomWindow customWindow, MainWindow mainWindow)
        {
            InitializeComponent();
            _customWindow = customWindow; // Store the reference of CustomWindow
            _mainWindow = mainWindow;     // Store the reference of MainWindow

            // Use CustomWindow's navigation method to navigate to ManageAppsPage
            _customWindow.NavigateToPage(new ManageAppsPage(_customWindow)); // Pass CustomWindow reference to page

            LoadFileTree();
            LoadInstalledPrograms();
        }

        private void LoadFileTree()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                TreeViewItem driveItem = new TreeViewItem
                {
                    Header = drive.Name,
                    Tag = drive.Name,
                    Foreground = System.Windows.Media.Brushes.White // Set text color to white
                };

                driveItem.Expanded += Folder_Expanded;
                FileTreeView.Items.Add(driveItem);
                driveItem.Items.Add(null); // Placeholder for lazy loading
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = sender as TreeViewItem;
            if (item.Items.Count == 1 && item.Items[0] == null)
            {
                item.Items.Clear(); // Clear placeholder

                string folderPath = item.Tag.ToString();
                try
                {
                    // Add subdirectories
                    foreach (var directory in Directory.GetDirectories(folderPath))
                    {
                        TreeViewItem subItem = new TreeViewItem
                        {
                            Header = Path.GetFileName(directory),
                            Tag = directory,
                            Foreground = System.Windows.Media.Brushes.White // Set text color to white
                        };

                        subItem.Expanded += Folder_Expanded;
                        item.Items.Add(subItem);
                        subItem.Items.Add(null); // Placeholder for lazy loading
                    }

                    // Add .exe files
                    foreach (var file in Directory.GetFiles(folderPath, "*.exe"))
                    {
                        TreeViewItem fileItem = new TreeViewItem
                        {
                            Header = Path.GetFileName(file),
                            Tag = file,
                            Foreground = System.Windows.Media.Brushes.LightGreen // Highlight .exe files
                        };

                        fileItem.MouseDoubleClick += FileItem_MouseDoubleClick;
                        item.Items.Add(fileItem);
                    }

                    // Add shortcut files pointing to .exe
                    foreach (var shortcut in Directory.GetFiles(folderPath, "*.lnk"))
                    {
                        string targetPath = ResolveShortcut(shortcut);
                        if (!string.IsNullOrEmpty(targetPath) && targetPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                        {
                            TreeViewItem shortcutItem = new TreeViewItem
                            {
                                Header = Path.GetFileName(targetPath),
                                Tag = targetPath,
                                Foreground = System.Windows.Media.Brushes.Cyan // Highlight shortcuts
                            };

                            shortcutItem.MouseDoubleClick += FileItem_MouseDoubleClick;
                            item.Items.Add(shortcutItem);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Handle unauthorized access
                    MessageBox.Show($"Access denied to folder: {folderPath}", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private string ResolveShortcut(string shortcutPath)
        {
            using (var shellObject = ShellObject.FromParsingName(shortcutPath))
            {
                return shellObject.Properties.System.Link.TargetParsingPath.Value;
            }
        }

        private void FileItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = sender as TreeViewItem;
            string appPath = item?.Tag?.ToString();

            if (!string.IsNullOrEmpty(appPath))
            {
                string appName = Path.GetFileNameWithoutExtension(appPath);

                // Add app to MainWindow's apps list
                _mainWindow.AddApp(new AppEntry { Name = appName, Path = appPath });

                MessageBox.Show($"{appName} added to Apps!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LoadInstalledPrograms()
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

                                if (!string.IsNullOrEmpty(appName))
                                {
                                    string appPath = null;

                                    // If InstallLocation is valid, look for executables
                                    if (!string.IsNullOrEmpty(installPath) && Directory.Exists(installPath))
                                    {
                                        var exeFiles = Directory.GetFiles(installPath, "*.exe", SearchOption.TopDirectoryOnly);
                                        if (exeFiles.Length > 0)
                                        {
                                            appPath = exeFiles[0];
                                        }
                                    }

                                    // Fallback to registry "QuietUninstallString" or other executable paths
                                    if (appPath == null)
                                    {
                                        appPath = subKey.GetValue("QuietUninstallString") as string;
                                    }

                                    // Add app if we found an executable path
                                    if (!string.IsNullOrEmpty(appPath) && appPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Button appButton = new Button
                                        {
                                            Content = appName,
                                            Style = (Style)FindResource("ModernButtonStyle"),
                                            Margin = new Thickness(5),
                                            Tag = appPath
                                        };

                                        appButton.Click += AppButton_Click;
                                        AppsList.Children.Add(appButton);
                                    }
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
            string appPath = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(appPath))
            {
                string appName = button.Content.ToString();

                if (_mainWindow != null)
                {
                    // Add app to MainWindow's apps list
                    _mainWindow.AddApp(new AppEntry { Name = appName, Path = appPath });

                    MessageBox.Show($"{appName} added to Apps!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("MainWindow reference is null. Cannot add app.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to ManageAppsPage using CustomWindow reference
            _customWindow.NavigateToPage(new ManageAppsPage(_customWindow));
        }
    }
}
