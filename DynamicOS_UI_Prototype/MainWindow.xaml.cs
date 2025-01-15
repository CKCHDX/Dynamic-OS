using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Threading;
using PInvoke;
using Dynamic_Os;
using PInvoke;

namespace Dynamic_Os
{
    public partial class MainWindow : Window
    {
        private const string AppsFile = "apps.json"; // File to save and load apps
        private List<AppEntry> apps = new List<AppEntry>();
        private CustomWindow _customWindow; // Declare the field for CustomWindow only once
        private Stack<string> navigationStack = new Stack<string>(); // For back navigation
        private bool isSwitchingMode = false;
        private List<ProgramEntry> runningPrograms = new List<ProgramEntry>();
        private DispatcherTimer taskbarRefreshTimer;
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private List<string> recentApps = new List<string>(); // Example app list
        public MainWindow()
        {
            InitializeComponent();
            InitializeTaskbarRefresh();
            string mode = AppConfig.LoadMode(); // Load the saved mode
                                                // Initialize performance counters
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            LoadRecentApps();
            // Start updating system information
            var dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            dispatcherTimer.Tick += UpdateSystemInfo;
            dispatcherTimer.Start();


            if (mode == "Simple")
            {
                // Launch SimpleWindow and terminate MainWindow
                SwitchToSimpleMode();
            }
            else
            {
                // Initialize Normal Mode
                InitializeNormalModeUI();
            }
        }
        private void UpdateSystemInfo(object sender, EventArgs e)
        {
            CpuUsageText.Text = $"{cpuCounter.NextValue():0.0}%";
            RamUsageText.Text = $"{ramCounter.NextValue():0} MB";
        }
        private void LoadRecentApps()
        {
            // Add example apps (replace with real data)
            recentApps.Add("Notepad");
            recentApps.Add("Calculator");
            recentApps.Add("Visual Studio");

            RecentAppsList.Items.Clear();
            foreach (var app in recentApps)
            {
                Button appButton = new Button
                {
                    Content = app,
                    Style = (Style)FindResource("ModernButtonStyle"),
                    Margin = new Thickness(5),
                    Width = 200
                };
                appButton.Click += (s, e) =>
                {
                    MessageBox.Show($"Launching {app}"); // Replace with real launch logic
                };

                RecentAppsList.Items.Add(appButton);
            }
        }



















        private void InitializeTaskbarRefresh()
        {
            taskbarRefreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5) // Refresh every 5 seconds
            };

            taskbarRefreshTimer.Tick += (s, e) => UpdateTaskbarWithRunningApps();
            taskbarRefreshTimer.Start();
        }

        private void InitializeNormalModeUI()
        {
            this.Topmost = false;

            // Handle window closing logic
            /*this.Closing += (s, e) =>
            {
                if (!isSwitchingMode)
                {
                    e.Cancel = true; // Prevent accidental closure unless switching modes
                    MessageBox.Show("You cannot close this window directly in Normal Mode.");
                }
            };*/

            this.Loaded += (s, e) =>
            {
                DisableTaskManager();
            };

            LoadApps();
            DisplayApps();
            LoadDrives(); // Load drives for the File Manager
        }

        // Method to switch to Simple Mode
        private void SwitchToSimpleMode()
        {
            isSwitchingMode = true; // Allow MainWindow to close
            var simpleWindow = new SimpleWindow();
            simpleWindow.Show();

            // Ensure all resources are cleared
            Application.Current.Shutdown();
        }


        // Method to switch to Advanced Mode
        /*private void SwitchToAdvancedMode()
        {
            isSwitchingMode = true; // Allow window to close
            var advancedWindow = new AdvancedWindow(); // Assume AdvancedWindow is implemented similarly
            advancedWindow.Show();
            this.Close(); // Close MainWindow
        }*/

        // Add a public method for other windows to trigger mode switching
        public void SwitchMode(string targetMode)
        {
            if (targetMode == "Simple")
            {
                SwitchToSimpleMode();
            }
            else if (targetMode == "Advanced")
            {
                //SwitchToAdvancedMode();
            }
            else
            {
                MessageBox.Show($"Unknown mode: {targetMode}");
            }
        }
        private void DisableTaskManager()
        {
            // Disable Task Manager by setting a keyboard hook (optional)
            // Note: This requires additional implementation for global hooks
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Set the window as a shell window
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            int style = NativeMethods.GetWindowLong(hwnd, NativeMethods.GWL_STYLE);
            style &= ~NativeMethods.WS_CAPTION; // Remove title bar
            NativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_STYLE, style);
        }
        internal static class NativeMethods
        {
            public const int GWL_STYLE = -16;
            public const int WS_CAPTION = 0xC00000;

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }
        public void NavigateToPage(Page page)
        {
            if (_customWindow != null && _customWindow.MainFrame != null) // Ensure CustomWindow and MainFrame are not null
            {
                _customWindow.MainFrame.Navigate(page); // Navigate to the provided page
            }
            else
            {
                MessageBox.Show("Navigation failed. MainFrame not found.");
            }
        }

        public void AddApp(AppEntry appEntry)
        {
            apps.Add(appEntry); // Add app to the list
            SaveApps();         // Save the updated list to JSON file
            DisplayApps();      // Refresh the Apps screen
        }

        private void ManageAppsButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the CustomWindow is already open
            if (_customWindow == null || !_customWindow.IsLoaded)
            {
                _customWindow = new CustomWindow(); // Create a new instance
                _customWindow.Show();               // Show the window
            }

            // Navigate to ManageAppsPage
            _customWindow.NavigateToPage(new ManageAppsPage(_customWindow));
        }
        private void ChangeModeButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the SettingWindow and pass the current SimpleWindow
            var settingWindow = new SettingWindow(this);
            settingWindow.Show(); // Show SettingWindow, but keep SimpleWindow open
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var targetScreenName = button?.Tag?.ToString();

            foreach (FrameworkElement screen in MainContent.Children)
            {
                // Hide all screens
                screen.Visibility = Visibility.Collapsed;

                // Reset animations
                screen.RenderTransform = new TranslateTransform();
            }
           

            var targetScreen = MainContent.FindName(targetScreenName) as FrameworkElement;
            if (targetScreen != null)
            {
                // Apply the slide-in animation
                var slideInAnimation = (Storyboard)FindResource("SlideInAnimation");

                // Create a new instance of the storyboard
                Storyboard freshAnimation = slideInAnimation.Clone();
                freshAnimation.Begin(targetScreen);

                targetScreen.Visibility = Visibility.Visible;
            }
        }




        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBar.Text.ToLower();
            SearchPlaceholder.Visibility = string.IsNullOrEmpty(SearchBar.Text) ? Visibility.Visible : Visibility.Collapsed;
            DisplayApps(searchText);
        }

        private void SearchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void SearchBar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBar.Text))
            {
                SearchPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void DisplayApps(string filter = "")
        {
            AppsList.Children.Clear();

            var filteredApps = string.IsNullOrWhiteSpace(filter)
                ? apps
                : apps.Where(a => a.Name.ToLower().Contains(filter)).ToList();

            foreach (var app in filteredApps)
            {
                Grid appGrid = new Grid { Margin = new Thickness(5) };
                appGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                appGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                Button appButton = new Button
                {
                    Content = app.Name,
                    Style = (Style)FindResource("ModernButtonStyle"),
                    Tag = app.Path,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                appButton.Click += AppButton_Click;

                Button removeButton = new Button
                {
                    Content = "❌",
                    Background = Brushes.Red,
                    Foreground = Brushes.White,
                    Width = 30,
                    Height = 30,
                    Tag = app.Name,
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                removeButton.Click += RemoveButton_Click;

                Grid.SetColumn(appButton, 0);
                Grid.SetColumn(removeButton, 1);

                appGrid.Children.Add(appButton);
                appGrid.Children.Add(removeButton);

                AppsList.Children.Add(appGrid);
            }
        }

        private void AppButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string appPath = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(appPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = appPath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open app: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string appName = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(appName))
            {
                var appToRemove = apps.FirstOrDefault(a => a.Name == appName);
                if (appToRemove != null)
                {
                    apps.Remove(appToRemove);
                    SaveApps();
                    DisplayApps();
                }
            }
        }

        private void LoadApps()
        {
            if (File.Exists(AppsFile))
            {
                string json = File.ReadAllText(AppsFile);
                apps = JsonSerializer.Deserialize<List<AppEntry>>(json) ?? new List<AppEntry>();
            }
        }

        private void SaveApps()
        {
            string json = JsonSerializer.Serialize(apps);
            File.WriteAllText(AppsFile, json);
        }

        private void LoadDrives()
        {
            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                DriveSelector.Items.Add(drive.Name);
            }
            DriveSelector.SelectedIndex = 0; // Default to the first drive
        }

        private void DriveSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DriveSelector.SelectedItem != null)
            {
                LoadDirectory(DriveSelector.SelectedItem.ToString());
            }
        }

        private void LoadDirectory(string path)
        {
            try
            {
                if (navigationStack.Count == 0 || navigationStack.Peek() != path)
                {
                    navigationStack.Push(path); // Save the current path for back navigation
                }

                PathBox.Text = path;
                FileList.Children.Clear();
                DirectoryTree.Items.Clear();

                // Load directories and files into the left panel
                foreach (var directory in Directory.GetDirectories(path))
                {
                    Button folderButton = new Button
                    {
                        Content = $"📁 {Path.GetFileName(directory)}",
                        Tag = directory,
                        Style = (Style)FindResource("ModernButtonStyle"),
                        Margin = new Thickness(5)
                    };
                    folderButton.Click += FolderButton_Click;
                    FileList.Children.Add(folderButton);
                }

                foreach (var file in Directory.GetFiles(path))
                {
                    Button fileButton = new Button
                    {
                        Content = $"📄 {Path.GetFileName(file)}",
                        Tag = file,
                        Style = (Style)FindResource("ModernButtonStyle"),
                        Margin = new Thickness(5)
                    };
                    fileButton.Click += FileButton_Click;
                    FileList.Children.Add(fileButton);
                }

                // Load the directory tree view
                LoadTreeView(path, DirectoryTree);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading directory: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (navigationStack.Count > 1)
            {
                navigationStack.Pop(); // Remove the current path
                string previousPath = navigationStack.Peek(); // Peek at the previous path
                LoadDirectory(previousPath);
            }
        }

        private void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is string path)
            {
                LoadDirectory(path);
            }
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is string filePath)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}");
                }
            }
        }

        private void PathBox_Go_Click(object sender, RoutedEventArgs e)
        {
            LoadDirectory(PathBox.Text);
        }

        private void PathBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                LoadDirectory(PathBox.Text);
            }
        }

        private void DirectoryTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DirectoryTree.SelectedItem is TreeViewItem selectedItem && selectedItem.Tag is string path)
            {
                LoadDirectory(path);
            }
        }

        private void LoadTreeView(string path, ItemsControl parent)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    var item = new TreeViewItem
                    {
                        Header = Path.GetFileName(directory),
                        Tag = directory
                    };
                    item.Items.Add(null); // Add a dummy item to make it expandable
                    item.Expanded += TreeViewItem_Expanded;
                    parent.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tree view: {ex.Message}");
            }
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem item && item.Tag is string path)
            {
                if (item.Items.Count == 1 && item.Items[0] == null) // Check for dummy item
                {
                    item.Items.Clear(); // Remove dummy item
                    LoadTreeView(path, item);
                }
            }
        }
        // Method to add a new program to the taskbar
        public void AddProgram(string name, Process process)
        {
            var programEntry = new ProgramEntry { Name = name, Process = process };
            runningPrograms.Add(programEntry);
        }

        // Method to remove a program from the taskbar
        public void RemoveProgram(Process process)
        {
            runningPrograms.RemoveAll(p => p.Process == process);
        }

        // Method to update the taskbar
        private void UpdateTaskbarWithRunningApps()
        {
            Taskbar.Children.Clear();

            // Get only user applications with visible main windows
            var userProcesses = Process.GetProcesses()
                .Where(p =>
                    p.MainWindowHandle != IntPtr.Zero && // Valid window handle
                    !string.IsNullOrWhiteSpace(p.MainWindowTitle) && // Has a visible title
                    p.Responding) // Process is responding
                .OrderBy(p => p.MainWindowTitle); // Optional: Sort alphabetically

            foreach (var process in userProcesses)
            {
                // Create a Grid to host the scrolling TextBlock
                Grid container = new Grid
                {
                    ClipToBounds = true, // Ensures the text doesn't overflow
                    Height = 30 // Set height to match button appearance
                };

                // TextBlock for the process title
                var textBlock = new TextBlock
                {
                    Text = process.ProcessName, // Use process name instead of window title
                    VerticalAlignment = VerticalAlignment.Center,
                    TextWrapping = TextWrapping.NoWrap,
                    Margin = new Thickness(0, 0, 0, 0),
                    ToolTip = process.MainWindowTitle // Show full window title on hover
                };

                // Add the TextBlock to the container
                container.Children.Add(textBlock);

                // Button for the process
                Button appButton = new Button
                {
                    Content = container, // Set the container as the button content
                    Tag = process, // Store the process for interaction
                    Style = (Style)FindResource("ModernButtonStyle"), // Use existing button style
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(5),
                    Padding = new Thickness(10, 5, 10, 5)
                };

               

                // Handle left-click (open)
                appButton.Click += (s, e) =>
                {
                    try
                    {
                        process.Refresh();
                        if (process.MainWindowHandle != IntPtr.Zero)
                        {
                            User32.ShowWindow(process.MainWindowHandle, User32.WindowShowStyle.SW_RESTORE);
                            User32.SetForegroundWindow(process.MainWindowHandle);
                        }
                        else
                        {
                            MessageBox.Show($"Cannot bring '{process.MainWindowTitle}' to focus.", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening the application: {ex.Message}", "Error");
                    }
                };

                // Handle right-click (close)
                appButton.MouseRightButtonDown += (s, e) =>
                {
                    try
                    {
                        var result = MessageBox.Show($"Are you sure you want to close {process.MainWindowTitle}?", "Confirm Close", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            process.Kill(); // Terminate the process
                            UpdateTaskbarWithRunningApps(); // Refresh the list
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error closing the application: {ex.Message}", "Error");
                    }
                };

                // Add the button to the taskbar
                Taskbar.Children.Add(appButton);
            }
        }



        private bool IsTaskbarWindow(Process process)
        {
            if (process.MainWindowHandle == IntPtr.Zero) return false; // Valid handle
            if (string.IsNullOrWhiteSpace(process.MainWindowTitle)) return false; // Has title
            var excludedProcesses = new[] { "ApplicationFrameHost", "XboxPcApp", "NvidiaOverlay", "ShellExperienceHost" };
            if (excludedProcesses.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase)) return false;
            return true;
        }


        // Handle taskbar button click
        private void TaskbarButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Process process)
            {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to bring the program to the foreground: {ex.Message}", "Error");
                }
            }
        }
    }
        // Helper class for running programs
    public class ProgramEntry
    {
        public string Name { get; set; }
        public Process Process { get; set; }
    }
    public class AppEntry
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
