using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace PinsApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public App _loadedApplication;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            InitPackages();
            LaunchXamarinApp();



            return base.FinishedLaunching(app, options);
        }

        private void InitPackages()
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyBy9lLjLfNfe4HHLpFayq-0HPQMk2Sk16U");
        }

        private void LaunchXamarinApp()
        {
            var initializer = new iOSInitializer();

            _loadedApplication = new App(initializer);

            this.LoadApplication(_loadedApplication);
        }
    }
}
