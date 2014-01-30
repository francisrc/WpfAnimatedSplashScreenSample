using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ST = System.Timers;
using System.Windows.Threading;

namespace CustomStartupSplashScreenDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Instance of DemoSplashScreen window.
        /// </summary>
        private DemoSplashScreen appSplashScreen = null;

        /// <summary>
        /// Application splash screen loading timer.
        /// </summary>
        private static ST.Timer applicationSplashScreenTimer = null;

        /// <summary>
        /// Application loading percentage counter.
        /// </summary>
        private static int loadingCount = 0;

        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        /// <param name="appSplashScreen">Instance of application splash screen window.</param>
        public App(DemoSplashScreen appSplashScreen)
        {
            this.appSplashScreen = appSplashScreen;
            applicationSplashScreenTimer = new ST.Timer(100);
            applicationSplashScreenTimer.Elapsed += new ST.ElapsedEventHandler(applicationSplashScreenTimer_Elapsed);
            applicationSplashScreenTimer.Start();
        }

        /// <summary>
        /// Event handler for Application splash screen timer time elapsed event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void applicationSplashScreenTimer_Elapsed(object sender, ST.ElapsedEventArgs eventArgs)
        {
            if (loadingCount >= 100)
            {
                applicationSplashScreenTimer.Stop();
                applicationSplashScreenTimer.Dispose();
                applicationSplashScreenTimer = null;

                appSplashScreen.AppLoadingCompleted();
                appSplashScreen = null;

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(StartMainApplication));
            }
            else
            {
                loadingCount += 1;
                appSplashScreen.AppLoadingPercentCompleted(loadingCount);
            }
        }

        /// <summary>
        /// Start demo application main window.
        /// </summary>
        private void StartMainApplication()
        {
            this.MainWindow = new MainWindow();
            this.MainWindow.Show();
        }
    }
}
