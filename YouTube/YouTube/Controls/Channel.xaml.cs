using MyToolkit.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YouTube.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Channel : Page
    {
        public Channel(string channelID)
        {
            this.InitializeComponent();
            SetPageData(channelID);
        }
        public async void SetPageData(string channelID)
        {
            YouTubeControls.GoogleAPI.YouTube.Channel.Channel c = new YouTubeControls.GoogleAPI.YouTube.Channel.Channel();
            var results = await c.GetPartnerData(channelID);

            foreach (var d in results.entry.yt_option)
            {
                switch (d.name)
                {
                    case "channel.banner.image.url":
                        ChannelPicture.Source = new BitmapImage(new Uri(d.t));
                        break;
                    case "channel.global.color":                        
                        //rootGrid.Background = YouTubeControls.GoogleAPI.YouTube.ColorHelper.GetColorFromHexa(d.t);
                        break;
                    case "channel.featured_channels.title":
                        ParnersLabel.Text = d.t;
                        break;
                    case "channel.global.title.string":
                        ChName.Text = d.t;
                        break;
                    case "channel.featured_channels.channel_url.list":
                        break;
                }
            }
        }
    }
    
}
