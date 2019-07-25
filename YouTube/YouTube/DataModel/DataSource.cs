using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using YouTube.DataModel.GData;

namespace YouTube.DataModel
{
    class DataSource
    {
        private static string connectionError = "An error occurred while trying to connect to webservice.";
        private static string GlobalError = "An internal error occurred. You may not be able to download or watch this video.";
        public DataSource()
        {
            try
            {
                //var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                //GlobalError = loader.GetString("GlobalError");
                //connectionError = loader.GetString("InternetError");
            }
            catch { showMessageDialog("Language Error. Restart Application."); }
        }
        public async static void showMessageDialog(string text)
        {
            try
            {
                MessageDialog md = new MessageDialog(text);
                await md.ShowAsync();
            }
            catch { }
            
        }
        public static async Task<string> MakeWebRequestPostAsync(string url, List<KeyValuePair<string, string>> values)
        {
            try
            {
                var content = new FormUrlEncodedContent(values);
                HttpClient http = new System.Net.Http.HttpClient();
                return await http.PostAsync(url, content).Result.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static async Task<string> MakeWebRequestAsync(string url)
        {
            try
            {
                HttpClient http = new System.Net.Http.HttpClient();
                HttpResponseMessage response = await http.GetAsync(url);
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception)
            {
                showMessageDialog(connectionError);
                return "";
            }
        }
        
        public static async Task<YouTubeDataFeed> getYouTubeData(string url)
        {
                string content = await MakeWebRequestAsync(url);

                YouTubeDataFeed list = JsonConvert.DeserializeObject<YouTubeDataFeed>(content);
                return list;
        }
        public static async Task<List<Video>> getList(string url)
        {
            try
            {
                string content = await MakeWebRequestAsync(url);
                JsonSerializerSettings setting = new JsonSerializerSettings();

                var d = JObject.Parse(content)["feed"];
                var data = JObject.Parse(d.ToString())["entry"];

                List<Entry> list = JsonConvert.DeserializeObject<List<Entry>>(data.ToString());
                List<Video> v = new List<Video>();
                foreach (Entry e in list)
                {
                    Video video = new Video();
                    video.title = e.title.t;
                    video.videoId = e.mediagroup.ytvideoid.t;
                    video.description = CortarString(e.mediagroup.mediadescription.t,150).Replace("\n","");
                    video.fullDescription = e.content.t;                    
                    video.autor = e.author[0].name.t;
                    video.visualizations = e.ytstatistics == null? "":string.Format("{0:N0}",int.Parse(e.ytstatistics.viewCount));
                    video.Username = e.author[0].ytuserId.t;
                    video.PlayerUrl = e.content.src;


                    if (e.mediagroup.mediacontent != null)
                    {
                        foreach (MediaContent c in e.mediagroup.mediacontent)
                        {
                            TimeSpan t = TimeSpan.FromSeconds(c.duration);
                            video.duration = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                            video.mediaUrl = c.url;
                            break;
                        }
                    }
                    
                    
                    video.image = new BitmapImage(new System.Uri(e.mediagroup.mediathumbnail[1].url));
                    video.FullContent = video;
                    v.Add(video);
                }

                
                return v;
            }
            catch (Exception e)
            {
                return new List<Video>();
            }      
        }
        public static async Task<List<Video>> getVideos(string q)
        {
            try
            {
                List<Video> list = await getList(string.Format("http://gdata.youtube.com/feeds/api/videos?q={0}&v=2{1}&alt=json", q, safeSearch()));
                return list;
            }
            catch { showMessageDialog(GlobalError); return new List<Video>(); }
        }
        public static async Task<UserProfileFeed> getUserDetails(string username)
        {
                string content = await MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/users/{0}?v=2&alt=json", username));
                UserProfileFeed list = JsonConvert.DeserializeObject<UserProfileFeed>(content);
                return list;
        }
        public static async Task<List<Comments>> getComments(string videoId)
        {
            string content = await MakeWebRequestAsync(string.Format("https://gdata.youtube.com/feeds/api/videos/{0}/comments?alt=json&v=2",videoId));
            CommentsFeed feed = JsonConvert.DeserializeObject<CommentsFeed>(content);
            List<Comments> comments = new List<Comments>();
            foreach (CommentsEntry e in feed.feed.entry)
            {
                Comments c = new Comments();
                c.author = e.author[0].name.t;
                var x = await getUserDetails(e.author[0].ytuserId.t);
                c.UserPicture = new BitmapImage(new System.Uri(x.entry.mediathumbnail.url));
                c.content = e.content.t;
                comments.Add(c);
            }
            return comments;
        }
        public static async Task<List<Video>> getRelatedVideos(string videoID)
        {
            List<Video> v = new List<Video>();
            /*try
            {*/
                YouTubeDataFeed listV = await getYouTubeData(string.Format("http://gdata.youtube.com/feeds/api/videos/{0}/related?v=2{1}&alt=json", videoID,safeSearch()));
                foreach (Entry e in listV.feed.entry)
                {
                    Video video = new Video();
                    video.title = e.title.t;
                    video.videoId = e.mediagroup.ytvideoid.t;
                    video.description = CortarString(e.mediagroup.mediadescription.t, 150).Replace("\n", "");
                    video.fullDescription = e.content.t;
                    video.autor = e.author[0].name.t;
                    video.Username = e.author[0].ytuserId.t;
                    video.visualizations = e.ytstatistics == null ? "" : string.Format("{0:N0}", int.Parse(e.ytstatistics.viewCount));
                    video.PlayerUrl = e.content.src;


                    if (e.mediagroup.mediacontent != null)
                    {
                        foreach (MediaContent c in e.mediagroup.mediacontent)
                        {
                            TimeSpan t = TimeSpan.FromSeconds(c.duration);
                            video.duration = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                            video.mediaUrl = c.url;
                            break;
                        }
                    }


                    video.image = new BitmapImage(new System.Uri(e.mediagroup.mediathumbnail[1].url));
                    video.FullContent = video;
                    v.Add(video);
                }

                return v;
            /*}
            catch { /*showMessageDialog(GlobalError); return new List<Video>(); }*/
        }
        public static async Task<IList<Video>> getVideosByApiUrl(string url)
        {
            try
            {
                List<Video> list = await getList(url);
                return list;
            }
            catch { showMessageDialog(GlobalError); return new List<Video>(); }
        }
        public static string safeSearch()
        {
            try
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string s = (string)localSettings.Values["safe"];
                string safe = "&safeSearch=strict";
                if (s == null)
                {
                    s = "1";
                    localSettings.Values["safe"] = s;
                    return safe;

                }
                else
                {
                    return "";
                }
            }
            catch { return ""; }
        }
        public static string GetVideoIDFromUrl(string url)
        {
            url = url.Substring(url.IndexOf("?") + 1);
            string[] props = url.Split('&');

            string videoid = "";
            foreach (string prop in props)
            {
                if (prop.StartsWith("v="))
                    videoid = prop.Substring(prop.IndexOf("v=") + 2);
            }

            return videoid;
        }
        public static bool isValidUrl(string url)
        {
            string pattern = @"^(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }
        public static string CortarStringPorPalavra(string text, int length)
        {
            string[] c = text.Split(new char[] { ' ' });
            if (c.Length < length)
            {
                return text;
            }
            else
            {
                string finaltext = c[0];
                for (int i = 1; i < length; i++)
                {
                    finaltext = string.Format("{0} {1}", finaltext, c[i]);
                }
                return string.Format("{0}...", finaltext);
            }
        }
        public static string CortarString(string value, int caracteres)
        {
            if (value.Length <= caracteres)
            {
                return value;
            }
            else
            {
                return string.Format("{0}...", value.Substring(0, caracteres));
            }
        }
    }
    public class Video
    {
        public string title { get; set; }
        public string description { get; set; }
        public ImageSource image { get; set; }
        public string duration { get; set; }
        public string autor { get; set; }
        public string Username { get; set; }
        public string mediaUrl { get; set; }
        public string videoId { get; set; }
        public string visualizations { get; set; }
        public string PlayerUrl { get; set; }
        public string fullDescription { get; set; }

        public Video FullContent { get; set; }

        private bool iss = false;
        public bool IsSpecialSize
        {
            get { return iss; }
            set { iss = value; }
        }
    }
    public class Comments
    {
        public string commentsCount { get; set; }
        public string author { get; set; }
        public ImageSource UserPicture { get; set; }
        public string content { get; set; }
    }
    public class VideoGroups
    {
        public string Title { get; set; }
        public List<Video> Videos { get; set; }
    }
}
