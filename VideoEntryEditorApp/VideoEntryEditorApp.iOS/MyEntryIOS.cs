using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoEntryEditorApp.MyEntry), typeof(VideoEntryEditorApp.iOS.MyEntryIOS))]
namespace VideoEntryEditorApp.iOS
{
    public class MyEntryIOS: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}