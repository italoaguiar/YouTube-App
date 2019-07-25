using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeControls.GoogleAPI.YouTube.Video
{
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
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos?q={0}&alt=json",query))
            );
        }
        public async Task<VideoEntries> Search(string query, string args)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos?q={0}&alt=json&{1}", query,args))
            );
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
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/standardfeeds/{0}", type.ToString()))
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
        public async Task<Entry> GetVideoDetails(string videoId)
        {
            return JsonConvert.DeserializeObject<Entry>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/videos/{0}?v=2&alt=json", videoId))
            );
        }



    }
}
