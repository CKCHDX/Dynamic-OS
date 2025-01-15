using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Dynamic_Os
{
    public partial class SplashScreen : Window
    {
        private Window _previewWindow; // Holds the preview window
        private string _selectedMode; // Tracks the selected mode
        private Line _connectorLine; // Line connecting button to preview

        public SplashScreen()
        {
            InitializeComponent();
            ApplyButton.IsEnabled = false; // Disable "Apply" button initially

            // Initialize the connector line
            _connectorLine = new Line
            {
                Stroke = Brushes.White,
                StrokeThickness = 2,
                Visibility = Visibility.Collapsed // Initially hidden
            };
            MainGrid.Children.Add(_connectorLine); // Add the line to the grid
        }

        private void SimpleModeButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedMode = "Simple";
            ShowPreviewWindow("Simple", SimpleModeButton);
            ApplyButton.IsEnabled = true; // Enable "Apply" button
        }

        private void SlimModeButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedMode = "Normal";
            ShowPreviewWindow("Normal", SlimModeButton);
            ApplyButton.IsEnabled = true; // Enable "Apply" button
        }

        private void AdvancedModeButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedMode = "Advanced";
            ShowPreviewWindow("Advanced", AdvancedModeButton);
            ApplyButton.IsEnabled = true; // Enable "Apply" button
        }
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedMode)) // Ensure a mode is selected
            {
                AppConfig.SaveMode(_selectedMode); // Save the selected mode

                // Close SplashScreen and open the selected mode
                Window newWindow = _selectedMode switch
                {
                    "Simple" => new SimpleWindow(),
                    "Normal" => new MainWindow(),
                    "Advanced" => new AdvancedWindow(),
                    _ => null
                };

                if (newWindow != null)
                {
                    newWindow.Show();
                    this.Close(); // Close the splash screen
                }
            }
            else
            {
                MessageBox.Show("Please select a mode before applying.", "No Mode Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowPreviewWindow(string mode, Button selectedButton)
        {
            // Close any existing preview window
            _previewWindow?.Close();

            // Create the preview window
            _previewWindow = new Window
            {
                Width = 500,
                Height = 400,
                Background = Brushes.Black,
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                Topmost = true,
                Owner = this,
                AllowsTransparency = true,
                Opacity = 0 // Start invisible for animation
            };

            // Position the preview window to the right of the current SplashScreen
            _previewWindow.Left = this.Left + this.Width;
            _previewWindow.Top = this.Top;

            // Add the relevant preview content
            _previewWindow.Content = mode switch
            {
                "Simple" => new Previews.SimpleModePreview(),
                "Normal" => new Previews.SlimModePreview(),
                "Advanced" => new Previews.SimpleModePreview(),
                _ => null
            };

            // Show the preview window
            _previewWindow.Show();

            // Animate the preview window moving in
            var animation = new DoubleAnimation
            {
                From = this.Left + this.Width + 50, // Start slightly to the right
                To = this.Left + this.Width,        // Move to its intended position
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            _previewWindow.BeginAnimation(LeftProperty, animation);

            // Fade in the preview window
            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            _previewWindow.BeginAnimation(OpacityProperty, fadeIn);

            // Update the connector line
            UpdateConnectorLine(selectedButton);
        }

        private void UpdateConnectorLine(Button selectedButton)
        {
            // Get the button's position
            var buttonPosition = selectedButton.TransformToAncestor(MainGrid).Transform(new Point(0, selectedButton.Height / 2));

            // Get the preview window's position
            var previewPosition = new Point(this.Width + 20, _previewWindow.Top + (_previewWindow.Height / 2));

            // Update the connector line
            _connectorLine.X1 = buttonPosition.X + selectedButton.Width; // End of button
            _connectorLine.Y1 = buttonPosition.Y;

            _connectorLine.X2 = MainGrid.ActualWidth + 20; // Start of preview window
            _connectorLine.Y2 = buttonPosition.Y; // Adjust for alignment

            // Show the connector line
            _connectorLine.Visibility = Visibility.Visible;

            // Animate the line
            var lineAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            _connectorLine.BeginAnimation(OpacityProperty, lineAnimation);
        }
    }
}
