using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(VideoEntryEditorApp.MyEntry), typeof(VideoEntryEditorApp.Droid.MyEntryDroid))]

namespace VideoEntryEditorApp.Droid
{
    [Obsolete]
    public class MyEntryDroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Android.Graphics.Drawables.GradientDrawable gd = new Android.Graphics.Drawables.GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                Control.SetRawInputType(Android.Text.InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(Android.Content.Res.ColorStateList.ValueOf(global::Android.Graphics.Color.Gray));
            }
        }
    }
}