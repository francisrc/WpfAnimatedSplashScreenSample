using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CustomStartupSplashScreenDemo
{
    /// <summary>
    /// Interaction logic for DemoSplashScreen.xaml
    /// </summary>
    public partial class DemoSplashScreen : Window, ICustomSplashScreen
    {
        /// <summary>
        /// Initializes a new instance of the DemoSplashScreen class.
        /// </summary>
        public DemoSplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Application loading percentage completed process.
        /// </summary>
        /// <param name="currentPercentage">Current application loaded percentage</param>
        public void AppLoadingPercentCompleted(int currentPercentage)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<string>(SetLoadingStatus), currentPercentage.ToString());
        }

        /// <summary>
        /// Application loading completed process.
        /// </summary>
        public void AppLoadingCompleted()
        {
            Dispatcher.InvokeShutdown();
        }

        /// <summary>
        /// UI dispatcher thread execution process to update the controls state.
        /// </summary>
        /// <param name="valueLoading">current value of application loaded.</param>
        private void SetLoadingStatus(string valueLoading)
        {
            this.txtBoxApplicationLoadCompletePercentVal.Text = valueLoading;
        }
    }
}
