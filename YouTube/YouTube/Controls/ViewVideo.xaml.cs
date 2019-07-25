using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.PlayTo;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using YouTubeControls.GoogleAPI.YouTube.Video;
using YouTubeControls.GoogleAPI.YouTube.Video.Entries;
using YouTubeDataModel.GoogleAPI.YouTube.Comments;
using YouTubeDataModel.GoogleAPI.YouTube.User;


// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YouTube.Controls
{
    public sealed partial class ViewVideo : UserControl
    {
        public ViewVideo()
        {
            this.InitializeComponent();

            
        }
        public ViewVideo(Entry v)
        {
            this.InitializeComponent();
            SetVideo(v);
        }

        private async void relatedVideos(Entry v)
        {
            YouTubeControls.GoogleAPI.YouTube.Video.Video vid = new YouTubeControls.GoogleAPI.YouTube.Video.Video();
            var videos = await vid.GetRelatedVideos(v.media_group.yt_videoid.t);
            itemListView.ItemsSource = videos.feed.entry;

            var userdata = await new User().GetUserDetails(v.author[0].yt_userId.t);
            SubscribeBtn.Tag = userdata.entry.yt_username.t;
            Subscriptions.Text = string.Format("{0:N0}",userdata.entry.yt_statistics.subscriberCount);
            UserPictureImage.Source = new BitmapImage(new System.Uri(userdata.entry.media_thumbnail.url));
        }
        private async void comments(Entry v, AccessToken token)
        {
            try
            {                
                Comments c = new Comments();
                CommentsEntries comments;

                CommentsRing.IsActive = true;
                if (token == null)
                {
                    comments = await c.GetComments(v.media_group.yt_videoid.t);
                }
                else
                {
                    var frame = (Frame)Window.Current.Content;
                    var page = (MainPage)frame.Content;
                    comments = await c.GetRelevantComments(v.media_group.yt_videoid.t,token);
                }
                foreach(var cm in comments.feed.entry){
                    User u = new User();
                    var userDetails = await u.GetUserDetails(cm.author[0].yt_userId.t);
                    cm.UserProfilePicture = userDetails.entry.media_thumbnail.url;

                    System.Diagnostics.Debug.WriteLine(cm.UserProfilePicture);
                }
                var comentarios = comments.feed.entry;
                CommentsList.ItemsSource = comentarios;
            }
            catch (Exception e) { ShowMessageDialog(e.ToString()); }
            finally { CommentsRing.IsActive = false; }
        }

        public async void ShowMessageDialog(string message)
        {
            MessageDialog md = new MessageDialog(message); 
            await md.ShowAsync();
        }

        private void player_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (player.IsFullWindow == true)
            {
                player.IsFullWindow = false;
                player.IsFullScreen = false;
            }
            else
            {
                player.IsFullWindow = true;
                player.IsFullScreen = true;
            }
        }
        Microsoft.PlayerFramework.MediaPlayer player = new Microsoft.PlayerFramework.MediaPlayer();
        private void setPlayer(PlayerType t,string url,string videoid)
        {
            switch (t)
            {
                case PlayerType.Embeded:
                    
                    player.AreTransportControlsEnabled = true;
                    player.IsInteractive = false;
                    player.InteractiveActivationMode = Microsoft.PlayerFramework.InteractionType.None;
                    player.IsFullScreenVisible = true;
                    player.Background = new SolidColorBrush(Colors.Black);
                    player.Height = 360;
                    player.DoubleTapped += player_DoubleTapped;
                    player.MediaFailed += (o, operation) =>
                    {
                        setPlayer(PlayerType.HTML5, url,videoid);
                    };
                    player.Source = new System.Uri(url);
                    PlayerContent.Content = player;

                              
                   
                    break;
                case PlayerType.HTML5:
                    WebView web = new WebView();
                    web.Height = 360;
                    PlayerContent.Content = web;
                    web.Source = new System.Uri(string.Format("http://www.youtube.com/embed/{0}?html5=1&autoplay=1",videoid));                    
                    break;
            }
        }
        private enum PlayerType
        {
            HTML5,
            Embeded
        }
        public async void SetVideo(Entry v)
        {
            relatedVideos(v);

            this.DataContext = v;            

            MyToolkit.Multimedia.YouTubeUri[] videourl = await MyToolkit.Multimedia.YouTube.GetUrisAsync(v.media_group.yt_videoid.t);


            foreach (MyToolkit.Multimedia.YouTubeUri uri in videourl)
            {
                if (uri.HasVideo && uri.HasAudio)
                {
                    setPlayer(PlayerType.Embeded, uri.Uri.ToString(), v.id.t);

                    break;
                }
            }
            Entry e = (await new Video().GetVideoDetails(v.media_group.yt_videoid.t)).entry;
            this.DataContext = e;

            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;
            comments(v, await page.LoginControl.GetTokenIfLoggedIn());
        }
        private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            RootScrollViewer.ChangeView(0, 0, 1);

            Entry v = ((Entry)e.ClickedItem);

            SetVideo(v); 
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rate(Video.VideoRating.like, sender as Button);
        }
        private void DislikeBtn_Click(object sender, RoutedEventArgs e)
        {
            Rate(Video.VideoRating.dislike, sender as Button);
        }

        private async void Rate(Video.VideoRating rating, Button b)
        {
            Video v = new Video();
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;

            try
            {
                string response = await v.RateVideo((this.DataContext as Entry).media_group.yt_videoid.t,
                    rating, await page.LoginControl.GetToken());

                b.IsEnabled = false;
            }
            catch { }
        }

        private async void SubscribeBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Tag != null)
            {
                try
                {
                    var frame = (Frame)Window.Current.Content;
                    var page = (MainPage)frame.Content;
                    YouTubeControls.GoogleAPI.YouTube.Channel.Channel c = new YouTubeControls.GoogleAPI.YouTube.Channel.Channel();
                    string response = await c.Subscribe((sender as Button).Tag as string, await page.LoginControl.GetToken());

                    (sender as Button).IsEnabled = false;

                }
                catch { }
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Video v = new Video();
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;

            var token = await page.LoginControl.GetToken();
            string result = await v.AddComment((DataContext as Entry).media_group.yt_videoid.t,
                CommentBox.Text, token);

            comments((DataContext as Entry), token);

            CommentBox.Text = string.Empty;

        }
    }
}
