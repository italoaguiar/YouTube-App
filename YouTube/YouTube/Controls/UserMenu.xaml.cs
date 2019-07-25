using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using YouTubeDataModel.GoogleAPI.YouTube.User;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YouTube.Controls
{
    public sealed partial class UserMenu : UserControl
    {
        public UserMenu()
        {
            this.InitializeComponent();
        }
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public bool isLoggedIn
        {
            get
            {
                return localSettings.Values["RefAccessToken"] != null;
            }
        }
        public UserInfo UserInfoData { get; set; }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await GetToken();
            }
            catch { }
        }
        private string _refToken;
        public string RefreshToken
        {
            get 
            {
                var t = localSettings.Values["RefAccessToken"];

                return t == null ? _refToken : t.ToString();
                
            }
            set { localSettings.Values["RefAccessToken"] = _refToken = value; }
        }
        public async Task<AccessToken> GetToken()
        {
            User u = new User();
            if (RefreshToken == null)
            {
                var tk = await u.MakeLogin();
                var user = await u.GetUserInfo(tk);
                SetUserInfoLayout(user);
                if (tk.refresh_token != null)
                RefreshToken = tk.refresh_token;
                return tk;
            }
            else
            {
                var tk = await u.MakeLogin(RefreshToken);
                var user = await u.GetUserInfo(tk);
                SetUserInfoLayout(user);
                if (tk.refresh_token != null)
                RefreshToken = tk.refresh_token;
                return tk;
            }            
        }
        public async Task<AccessToken> GetTokenIfLoggedIn()
        {
            User u = new User();
            if (RefreshToken != null)
            {
                var tk = await u.MakeLogin(RefreshToken);
                var user = await u.GetUserInfo(tk);
                SetUserInfoLayout(user);
                if (tk.refresh_token != null)
                RefreshToken = tk.refresh_token;
                return tk;
            }
            else
            {
                return null;
            }
        }
        
        private void SetUserInfoLayout(UserInfo info)
        {
            LoginButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            if(info.name != null)
            Username.Text = info.name;
            if(info.picture != null)
            UserPicture.Source = new BitmapImage(new System.Uri(info.picture));
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {            
            localSettings.Values["RefAccessToken"] = null;
        }        
    }    
}
