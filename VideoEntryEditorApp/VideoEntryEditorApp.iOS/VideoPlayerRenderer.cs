using System;
using System.ComponentModel;

using AVFoundation;
using AVKit;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoEntryEditorApp.VideoPlayer),typeof(VideoEntryEditorApp.iOS.VideoPlayerRenderer))]
namespace VideoEntryEditorApp.iOS
{
    public class VideoPlayerRenderer: ViewRenderer<VideoPlayer, UIView>
    {
        AVPlayer aVPlayer;
        AVPlayerItem playerItem;
        AVPlayerViewController playerViewController;

        public override UIViewController ViewController => playerViewController;

        void SetSource()
        {
            AVAsset asset = null;

            if (Element.Source is UriVideoSource)
            {
                string uri = (Element.Source as UriVideoSource).Uri;

                if (!String.IsNullOrWhiteSpace(uri))
                {
                    asset = AVAsset.FromUrl(new NSUrl(uri));
                }
            }
            if (asset != null)
            {
                playerItem = new AVPlayerItem(asset);
            }
            else
            {
                playerItem = null;
            }

            aVPlayer.ReplaceCurrentItemWithPlayerItem(playerItem);

            if (playerItem != null && Element.AutoPlay)
            {
                aVPlayer.Play();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            { 
                if (Control == null)
                {
                    playerViewController = new AVPlayerViewController();

                    aVPlayer = new AVPlayer();
                    playerViewController.Player = aVPlayer;

                    SetNativeControl(playerViewController.View);
                }
                SetAreTransportControlsEnabled();
                SetSource();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (aVPlayer != null)
            {
                aVPlayer.ReplaceCurrentItemWithPlayerItem(null);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.AreTransportControlsEnabledProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
        }

        void SetAreTransportControlsEnabled()
        {
            ((AVPlayerViewController)ViewController).ShowsPlaybackControls = Element.AreTransportControlsEnabled;
        }
    }
}