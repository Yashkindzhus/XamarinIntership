using System;
using Xamarin.Forms;

namespace VideoEntryEditorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnEditorButton_Click(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new EditorPage());
        }

        public async void OnVideoButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPage());
        }

        public async void OnEntryButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}
