using System.ComponentModel;
using System.Windows;
using BigReactorSimulator.Views.Main;

namespace BigReactorSimulator.Views
{
    public static class WindowManager
    {
        public static App Application { get; private set; }

        public static MainView MainWindow { get; private set; }

        public static bool IsInitialised { get; set; }

        // this is just how i prefer to start an application...
        // and i like it :)))))))
        // you can change it if you want...

        public static void Initialise(App app, string[] args)
        {
            if (IsInitialised)
            {
                return;
            }

            Application = app;

            MainViewModel model = new MainViewModel();
            MainWindow = new MainView()
            {
                Model = model
            };

            MainWindow.Closing += OnWindowClosing;

            IsInitialised = true;
        }

        public static void ShutdownApplication()
        {
            ShutdownWindows();
            Application.Shutdown();
        }

        #region Showing and closing/hiding windows

        public static void ShowMain() => ShowWindow(MainWindow);
        public static void HideMain() => HideWindow(MainWindow);

        public static void ShowWindow(Window window)
        {
            window.Show();
        }

        public static void HideWindow(Window window)
        {
            window.Hide();
        }

        private static void ShutdownWindows()
        {
            MainWindow.Closing -= OnWindowClosing;

            //MainWindow.Close();
        }

        private static void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (sender is MainView)
            {
                ShutdownApplication();
            }
            else
            {
                e.Cancel = true;
                (sender as Window)?.Hide();
            }
        }

        #endregion
    }
}
