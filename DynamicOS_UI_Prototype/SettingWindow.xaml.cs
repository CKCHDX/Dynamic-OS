using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Dynamic_Os
{
    public partial class SettingWindow : Window
    {
        private ResizeDirection _resizeDirection = ResizeDirection.None;
        private const int ResizeMargin = 10; // Margin around the edges for resizing
        private bool _isResizing = false; // Flag to check if resizing is active
        private bool _isPreviewMode = false;
        private Button _selectedButton; // Track the selected button
        private string _selectedMode;   // Track the selected mode
        private readonly Window _originalMainWindow;
        // Dragging fields
        private bool _isDragging = false; // Flag to indicate if the window is being dragged
        private Point _startPoint; // Start point of the drag operation

        public SettingWindow(Window originalMainWindow = null)
        {
            InitializeComponent();
            _originalMainWindow = originalMainWindow ?? Application.Current.MainWindow;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.Background = Brushes.Black; // Or transparent if needed
        }

        private void OpenSettings()
        {
            var settingWindow = new SettingWindow(this); // Pass the current MainWindow
            settingWindow.ShowDialog();
        }

        private void RemovePageBorders()
        {
            
        }


        // Ensure MainFrame is initialized
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        // Dragging the window by clicking on the title bar
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.ClickCount == 2)
                {
                    // Toggle maximize and normal states
                    this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                }
                else
                {
                    // Start dragging the window
                    _isDragging = true;
                    _startPoint = e.GetPosition(this); // Record the start point of the drag
                    this.CaptureMouse(); // Capture the mouse for the window
                }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                // Calculate the new window position based on mouse movement
                var mousePos = e.GetPosition(this);
                var diff = mousePos - _startPoint;

                this.Left += diff.X;
                this.Top += diff.Y;
            }
            else if (_isResizing)
            {
                // Perform resize operation
                ResizeWindow(e.GetPosition(this));
            }
            else
            {
                // Update cursor for resizing
                UpdateResizeCursor(e.GetPosition(this));
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                this.ReleaseMouseCapture(); // Release mouse capture
            }

            if (_isResizing)
            {
                _isResizing = false;
                Mouse.Capture(null); // Release mouse capture
                this.Cursor = Cursors.Arrow; // Reset cursor to default
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _resizeDirection != ResizeDirection.None)
            {
                _isResizing = true;
                Mouse.Capture(this); // Capture mouse for resizing
            }
        }

        // Resize logic
        private void ResizeWindow(Point mousePosition)
        {
            double newWidth = this.Width;
            double newHeight = this.Height;

            // Adjust the width and height based on the resize direction
            if (_resizeDirection.HasFlag(ResizeDirection.Right))
            {
                newWidth = mousePosition.X > ResizeMargin ? mousePosition.X : ResizeMargin;
            }
            if (_resizeDirection.HasFlag(ResizeDirection.Bottom))
            {
                newHeight = mousePosition.Y > ResizeMargin ? mousePosition.Y : ResizeMargin;
            }
            if (_resizeDirection.HasFlag(ResizeDirection.Left))
            {
                double deltaX = mousePosition.X;
                if (this.Width - deltaX > ResizeMargin)
                {
                    this.Left += deltaX;
                    newWidth = this.Width - deltaX;
                }
            }
            if (_resizeDirection.HasFlag(ResizeDirection.Top))
            {
                double deltaY = mousePosition.Y;
                if (this.Height - deltaY > ResizeMargin)
                {
                    this.Top += deltaY;
                    newHeight = this.Height - deltaY;
                }
            }

            // Apply the new dimensions
            this.Width = newWidth;
            this.Height = newHeight;
        }

        // Update cursor for resizing
        private void UpdateResizeCursor(Point mousePosition)
        {
            bool top = mousePosition.Y <= ResizeMargin;
            bool bottom = mousePosition.Y >= this.ActualHeight - ResizeMargin;
            bool left = mousePosition.X <= ResizeMargin;
            bool right = mousePosition.X >= this.ActualWidth - ResizeMargin;

            // Set the cursor and resize direction based on position
            if (top && left)
            {
                this.Cursor = Cursors.SizeNWSE;
                _resizeDirection = ResizeDirection.Top | ResizeDirection.Left;
            }
            else if (top && right)
            {
                this.Cursor = Cursors.SizeNESW;
                _resizeDirection = ResizeDirection.Top | ResizeDirection.Right;
            }
            else if (bottom && left)
            {
                this.Cursor = Cursors.SizeNESW;
                _resizeDirection = ResizeDirection.Bottom | ResizeDirection.Left;
            }
            else if (bottom && right)
            {
                this.Cursor = Cursors.SizeNWSE;
                _resizeDirection = ResizeDirection.Bottom | ResizeDirection.Right;
            }
            else if (top)
            {
                this.Cursor = Cursors.SizeNS;
                _resizeDirection = ResizeDirection.Top;
            }
            else if (bottom)
            {
                this.Cursor = Cursors.SizeNS;
                _resizeDirection = ResizeDirection.Bottom;
            }
            else if (left)
            {
                this.Cursor = Cursors.SizeWE;
                _resizeDirection = ResizeDirection.Left;
            }
            else if (right)
            {
                this.Cursor = Cursors.SizeWE;
                _resizeDirection = ResizeDirection.Right;
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                _resizeDirection = ResizeDirection.None;
            }
        }

        // Navigate to a specific page in the MainFrame
        public void NavigateToPage(Page page)
        {
            
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            MessageBox.Show($"Navigated to: {e.Content.GetType().Name}");
        }

        // Back button functionality
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }





        private void SimpleModeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectMode("Simple", SimpleModeButton);
        }

        private void SlimModeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectMode("Normal", SlimModeButton);
        }

        private void AdvancedModeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectMode("Advanced", AdvancedModeButton);
        }

        private void SelectMode(string mode, Button selectedButton)
        {
            if (_selectedButton == selectedButton && _isPreviewMode)
            {
                // Reset if the same button is clicked
                ResetButtons();
                _isPreviewMode = false;
                _selectedButton = null;
                _selectedMode = null;
                return;
            }

            _selectedMode = mode;
            _selectedButton = selectedButton;

            HideOtherButtons(selectedButton);
            AnimateButtonsAndPreview(selectedButton, mode);
            _isPreviewMode = true;
        }

        private void HideOtherButtons(Button selectedButton)
        {
            foreach (var child in ModeButtons.Children)
            {
                if (child is Button button && button != selectedButton)
                {
                    // Animate button fade out
                    var fadeOut = new DoubleAnimation
                    {
                        From = 1,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };
                    button.BeginAnimation(OpacityProperty, fadeOut);
                    button.IsHitTestVisible = false;
                }
            }
        }

        private void AnimateButtonsAndPreview(Button selectedButton, string mode)
        {
            // Animate selected button to the left
            var translateTransform = selectedButton.RenderTransform as TranslateTransform ?? new TranslateTransform();
            selectedButton.RenderTransform = translateTransform;

            var buttonAnimation = new DoubleAnimation
            {
                From = 0,
                To = -250, // Move to the left
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            translateTransform.BeginAnimation(TranslateTransform.XProperty, buttonAnimation);

            // Animate preview area for the selected mode
            ShowPreview(mode);
        }

        private void ShowPreview(string mode)
        {
            // Animate the PreviewArea to expand its width
            var widthAnimation = new DoubleAnimation
            {
                From = PreviewArea.ActualWidth,
                To = 500, // Expand to fit the remaining space
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            PreviewArea.BeginAnimation(WidthProperty, widthAnimation);

            // Fade in the preview area
            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            PreviewArea.BeginAnimation(OpacityProperty, fadeIn);

            // Load the appropriate preview content
            switch (mode)
            {
                case "Simple":
                    PreviewContent.Content = new Previews.SimpleModePreview();
                    break;
                case "Normal":
                    PreviewContent.Content = new Previews.SlimModePreview();
                    break;
                case "Advanced":
                    PreviewContent.Content = new Previews.SimpleModePreview();
                    break;
            }
        }
        private void ResetButtons()
        {
            foreach (var child in ModeButtons.Children)
            {
                if (child is Button button)
                {
                    // Reset opacity
                    var fadeIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };
                    button.BeginAnimation(OpacityProperty, fadeIn);
                    button.IsHitTestVisible = true;

                    // Reset translation
                    var translateTransform = button.RenderTransform as TranslateTransform;
                    if (translateTransform != null)
                    {
                        var resetAnimation = new DoubleAnimation
                        {
                            From = translateTransform.X,
                            To = 0, // Move back to original position
                            Duration = TimeSpan.FromSeconds(0.5),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                        };
                        translateTransform.BeginAnimation(TranslateTransform.XProperty, resetAnimation);
                    }
                }
            }

            // Reset preview area
            var widthReset = new DoubleAnimation
            {
                From = PreviewArea.Width,
                To = 250, // Reset to initial width
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            PreviewArea.BeginAnimation(WidthProperty, widthReset);

            var opacityReset = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            PreviewArea.BeginAnimation(OpacityProperty, opacityReset);
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            // Determine the selected mode dynamically
            string selectedMode = _selectedMode;

            if (string.IsNullOrEmpty(selectedMode))
            {
                MessageBox.Show("Please select a mode before applying.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Save the selected mode to the config
            AppConfig.SaveMode(selectedMode);

            // Close the original main window
            if (_originalMainWindow != null)
            {
                _originalMainWindow.Close();
            }

            // Create and open the new window based on the selected mode
            Window newWindow = selectedMode switch
            {
                "Simple" => new SimpleWindow(),
                "Normal" => new MainWindow(),
                "Advanced" => new AdvancedWindow(),
                _ => null
            };

            if (newWindow != null)
            {
                Application.Current.MainWindow = newWindow; // Set the new window as the application's MainWindow
                newWindow.Show();
            }

            // Close the settings window itself
            this.Close();
        }




        // P/Invoke declarations for window customization
        [System.Flags]
        private enum ResizeDirection
        {
            None = 0,
            Left = 1,
            Right = 2,
            Top = 4,
            Bottom = 8
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);

        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;

        private const int WS_CAPTION = 0xC00000;
        private const int WS_THICKFRAME = 0x00040000;
        private const int WS_MINIMIZEBOX = 0x00020000;
        private const int WS_MAXIMIZEBOX = 0x00010000;
        private const int WS_SYSMENU = 0x00080000;
        private const int WS_EX_LAYERED = 0x00080000;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        private struct Margins
        {
            public int cxLeftWidth, cxRightWidth, cyTopHeight, cyBottomHeight;
        }
    }
}
