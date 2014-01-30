using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStartupSplashScreenDemo
{
    public interface ICustomSplashScreen
    {
        void AppLoadingPercentCompleted(int currentPercentage);
        void AppLoadingCompleted();
    }
}
