using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;

namespace PinsApp.Views
{
    public partial class PinsView : TabbedPage
    {
        public PinsView()
        {
            InitializeComponent();
            /*Position position = new Position(0, 0);
            Pin pin = new Pin
            {
            Type = PinType.Place,
            Position = position,
            Icon = BitmapDescriptorFactory.FromBundle("pin.png"),
            Label = "Custom pin",
            Address = "cust info"
            };

            MapPins.Pins.Add(pin);*/
        }
    }
}
