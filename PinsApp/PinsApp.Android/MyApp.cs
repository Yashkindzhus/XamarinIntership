using System;
using Android.App;
using Android.Runtime;

namespace PinsApp.Droid
{
    [Application]
    [MetaData("com.google.android.maps.v2.API_KEY",
             Value = "AIzaSyBy9lLjLfNfe4HHLpFayq - 0HPQMk2Sk16U")]
    public class MyApp : Application
    {
        public MyApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}
