using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using YouTubeControls.GoogleAPI.YouTube.Video.Entries;
using YouTubeDataModel.GoogleAPI.YouTube.User;

namespace YouTubeControls.GoogleAPI.YouTube.Video
{
    public class SearchParameters
    {
        public string alt { get; set; }
        public string author { get; set; }
        public string max_results{get;set;}
        public string start_index { get; set; }
        public string q { get; set; }
        public string category { get; set; }
        public string format { get; set; }
        public string location { get; set; }
        public string location_radius { get; set; }
        public string lr { get; set; }
        public string orderby { get; set; }
        public string restriction { get; set; }
        public string time { get; set; }
        public string uploader { get; set; }
        public string safeSearch { get; set; }


        public enum Time
        {
             today, 
            this_week, 
            this_month,
            all_time
        }
        
        public override string ToString()
        {
            string query = "";
            foreach (PropertyInfo p in this.GetType().GetRuntimeProperties())
            {
                if (p.GetValue(this,null) != null)
                    query += string.Format("&{0}={1}",p.Name.Replace("_","-"),p.GetValue(this,null));
            }
            return query;
        }
    }
    public class Video
    {

        public enum StandardFeedType
        {
            top_rated,
            top_favorites,
            most_viewed,
            most_popular,
            most_recent,
            most_discussed,
            most_responded,
            recently_featured,
            watch_on_mobile
        }


        

        public async Task<VideoEntries> Search(string query)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos?q={0}&v=2&alt=json",query))
            );
        }
        public async Task<VideoEntries> Search(SearchParameters p)
        {
            try
            {
                return JsonConvert.DeserializeObject<VideoEntries>(
                    await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos?v=2&alt=json{0}", p.ToString()))
                );
            }
            catch { throw; }
        }
        public async Task<VideoEntries> GetUserUploads(string query)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/users/{0}/uploads?alt=json", query))
            );
        }
        public async Task<VideoEntries> GetUserUploads(string query, string args)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/users/{0}/uploads?alt=json&{1}", query, args))
            );
        }
        public async Task<VideoEntries> GetStandardFeed(StandardFeedType type)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/standardfeeds/{0}?v=2&alt=json", type.ToString()))
            );
        }
        public async Task<VideoEntries> GetStandardFeed(StandardFeedType type, string args)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/standardfeeds/{0}?{1}", type.ToString(),args))
            );
        }
        public async Task<VideoEntries> GetRelatedVideos(string videoId)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos/{0}/related?v=2&alt=json", videoId))
            );
        }
        public async Task<VideoEntries> GetUserFavorites(string username)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/users/{0}/favorites?v=2&alt=json", username))
            );
        }
        public async Task<SingleFeed> GetVideoDetails(string videoId)
        {
            return JsonConvert.DeserializeObject<SingleFeed>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos/{0}?v=2&alt=json", videoId))
            );
        }
        public async Task<string> AddComment(string videoId, string comment, AccessToken token)
        {
            string like = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><entry xmlns=\"http://www.w3.org/2005/Atom\"" +
                " xmlns:yt=\"http://gdata.youtube.com/schemas/2007\"><content>" + comment + "</content></entry>";


            List<KeyValuePair<string, string>> k = new List<KeyValuePair<string, string>>();
            k.Add(new KeyValuePair<string, string>("Host", "gdata.youtube.com"));
            k.Add(new KeyValuePair<string, string>("X-GData-Key", "key=AIzaSyCH5E5roCLWZgTmZK938wTMFgT3BYXhsvI"));
            k.Add(new KeyValuePair<string, string>("GData-Version", "2.1"));
            k.Add(new KeyValuePair<string, string>("Authorization", token.token_type + " " + token.access_token));

            return await Util.MakeWebPostRequestAsync(
                string.Format("https://gdata.youtube.com/feeds/api/videos/{0}/comments", videoId),
                k, like, new System.Net.Http.Headers.MediaTypeHeaderValue("application/atom+xml")
            );
        }
        public async Task<string> DeleteComment(string videoId, AccessToken token)
        {
            List<KeyValuePair<string, string>> k = new List<KeyValuePair<string, string>>();
            k.Add(new KeyValuePair<string, string>("Host", "gdata.youtube.com"));
            k.Add(new KeyValuePair<string, string>("X-GData-Key", "key=AIzaSyCH5E5roCLWZgTmZK938wTMFgT3BYXhsvI"));
            k.Add(new KeyValuePair<string, string>("GData-Version", "2.1"));
            k.Add(new KeyValuePair<string, string>("Authorization", token.token_type + " " + token.access_token));

            return await Util.MakeWebDeleteRequestAsync(
                string.Format("https://gdata.youtube.com/feeds/api/videos/{0}/comments", videoId),
                k, "", new System.Net.Http.Headers.MediaTypeHeaderValue("application/atom+xml")
            );
        }
        public async Task<string> RateVideo(string videoId, VideoRating rating, AccessToken token)
        {
            string like = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><entry xmlns=\"http://www.w3.org/2005/Atom\"" +
                " xmlns:yt=\"http://gdata.youtube.com/schemas/2007\"><yt:rating value=\"" + rating.ToString() + "\"/></entry>";


            List<KeyValuePair<string, string>> k = new List<KeyValuePair<string, string>>();
            k.Add(new KeyValuePair<string, string>("Host", "gdata.youtube.com"));
            k.Add(new KeyValuePair<string, string>("X-GData-Key", "key=AIzaSyCH5E5roCLWZgTmZK938wTMFgT3BYXhsvI"));
            k.Add(new KeyValuePair<string, string>("GData-Version", "2.1"));
            k.Add(new KeyValuePair<string, string>("Authorization", token.token_type + " " + token.access_token));

            return await Util.MakeWebPostRequestAsync(
                string.Format("https://gdata.youtube.com/feeds/api/videos/{0}/ratings", videoId),
                k, like, new System.Net.Http.Headers.MediaTypeHeaderValue("application/atom+xml")
            );
        }
        public enum VideoRating
        {
            like,
            dislike
        }

    }
}
