using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace CustomStartupSplashScreenDemo
{
    public sealed class ApplicationStartup
    {
        #region Variable Declaration

        /// <summary>
        /// Thread that runs the application splash screen on application startup.
        /// </summary>
        private static Thread applicationSplashScreenThread = null;

        /// <summary>
        /// Instance of application splash screen window.
        /// </summary>
        private static DemoSplashScreen applicationSplashScreen = null;

        /// <summary>
        /// Manual reset event instance to hold the application splash screen thread till splash screen completes its loading.
        /// </summary>
        private static ManualResetEvent manualResetEventSplashScreen = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Main entry point method for Demo application.
        /// </summary>
        [STAThreadAttribute()]
        public static void Main()
        {
                manualResetEventSplashScreen = new ManualResetEvent(false);
                applicationSplashScreenThread = new Thread(DisplayApplicationSplashScreen);

                applicationSplashScreenThread.SetApartmentState(ApartmentState.STA);
                applicationSplashScreenThread.IsBackground = true;
                applicationSplashScreenThread.Name = "Demo Splash Screen Thread";

                applicationSplashScreenThread.Start();
                manualResetEventSplashScreen.WaitOne();

                var application = new App(applicationSplashScreen);
                application.Run();
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Display application splash screen.
        /// </summary>
        private static void DisplayApplicationSplashScreen()
        {
            applicationSplashScreen = new DemoSplashScreen();
            applicationSplashScreen.Show();
            manualResetEventSplashScreen.Set();
            Dispatcher.Run();
        }

        #endregion
    }
}
