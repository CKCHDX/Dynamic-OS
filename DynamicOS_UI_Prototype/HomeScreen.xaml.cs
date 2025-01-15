using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Dynamic_Os
{
    public partial class HomeScreen : Page
    {
        public string CurrentDateTime => DateTime.Now.ToString("F"); // Full date and time

        public HomeScreen()
        {
            InitializeComponent();
            // Set up a timer to update time dynamically
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) => { DataContext = this; };
            timer.Start();
        }
    }
}
