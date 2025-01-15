using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Dynamic_Os
{
    public partial class CustomWindow : Window
    {
        private ResizeDirection _resizeDirection = ResizeDirection.None;
        private const int ResizeMargin = 10; // Margin around the edges for resizing
        private bool _isResizing = false; // Flag to check if resizing is active

        // Dragging fields
        private bool _isDragging = false; // Flag to indicate if the window is being dragged
        private Point _startPoint; // Start point of the drag operation

        public CustomWindow()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.Background = System.Windows.Media.Brushes.Black; // Or transparent if needed

            // Hide navigation UI
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // Handle navigations to clean up pages
            MainFrame.Navigated += (s, e) => RemovePageBorders();
        }

        private void RemovePageBorders()
        {
            var currentPage = MainFrame.Content as Page;
            if (currentPage != null)
            {
                currentPage.Margin = new Thickness(0);
                currentPage.Background = System.Windows.Media.Brushes.Transparent;
            }
        }





        // Ensure MainFrame is initialized
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainFrame == null)
            {
                MessageBox.Show("MainFrame is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            if (MainFrame != null)
            {
                MainFrame.Navigate(page);
            }
            else
            {
                MessageBox.Show("MainFrame not found for navigation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            MessageBox.Show($"Navigated to: {e.Content.GetType().Name}");
        }

        // Back button functionality
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
            else
            {
                MessageBox.Show("No previous page to navigate back to.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        [System.Flags]
        private enum ResizeDirection
        {
            None = 0,
            Left = 1,
            Right = 2,
            Top = 4,
            Bottom = 8
        }
        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(out bool pfEnabled);

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;

            // Get initial styles
            int style = GetWindowLong(hwnd, GWL_STYLE);
            int exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
           

            // Modify styles to remove unwanted elements
            style &= ~(WS_CAPTION | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU);
            SetWindowLong(hwnd, GWL_STYLE, style);

            exStyle |= WS_EX_LAYERED | WS_EX_TOOLWINDOW;
            SetWindowLong(hwnd, GWL_EXSTYLE, exStyle);

            // Log modified styles
            int newStyle = GetWindowLong(hwnd, GWL_STYLE);
            int newExStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
          

            // Extend frame into client area if DWM is enabled
            bool isDwmEnabled;
            if (DwmIsCompositionEnabled(out isDwmEnabled) == 0 && isDwmEnabled)
            {
                Margins margins = new Margins { cxLeftWidth = -1, cxRightWidth = -1, cyTopHeight = -1, cyBottomHeight = -1 };
                DwmExtendFrameIntoClientArea(hwnd, ref margins);
             
            }
            else
            {
                
            }
        }

        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;

        private const int WS_CAPTION = 0xC00000;        // Title bar
        private const int WS_THICKFRAME = 0x00040000;   // Resizable border
        private const int WS_MINIMIZEBOX = 0x00020000;  // Minimize button
        private const int WS_MAXIMIZEBOX = 0x00010000;  // Maximize button
        private const int WS_SYSMENU = 0x00080000;      // System menu

        private const int WS_EX_LAYERED = 0x00080000;   // Layered window
        private const int WS_EX_TOOLWINDOW = 0x00000080; // Hide from Alt+Tab


        // P/Invoke declarations
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);

        private struct Margins
        {
            public int cxLeftWidth, cxRightWidth, cyTopHeight, cyBottomHeight;
        }
    }
}
