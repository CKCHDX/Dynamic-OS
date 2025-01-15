using System.Windows;

namespace Dynamic_Os
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppConfig.Initialize();

            string mode = AppConfig.LoadMode();

            // If no mode is set, show the splash screen
            if (string.IsNullOrEmpty(mode) || mode == "Splash")
            {
                var splashScreen = new SplashScreen();
                splashScreen.Show();
            }
            else
            {
                // Load the corresponding window based on the saved mode
                Window startingWindow = mode switch
                {
                    "Simple" => new SimpleWindow(),
                    "Normal" => new MainWindow(),
                    "Advanced" => new AdvancedWindow(),
                    _ => new SplashScreen() // Default to splash screen if mode is invalid
                };

                startingWindow.Show();
            }
        }
    }
}
