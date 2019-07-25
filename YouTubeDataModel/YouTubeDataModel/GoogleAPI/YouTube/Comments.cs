using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using YouTubeControls.GoogleAPI.YouTube;
using YouTubeDataModel.GoogleAPI.YouTube.Common;
using YouTubeDataModel.GoogleAPI.YouTube.User;

namespace YouTubeDataModel.GoogleAPI.YouTube.Comments
{
    public class Comments
    {
        public async Task<CommentsEntries> GetComments(string videoId)
        {
            return JsonConvert.DeserializeObject<CommentsEntries>(
                await Util.MakeWebRequestAsync(
                    string.Format("https://gdata.youtube.com/feeds/api/videos/{0}/comments?alt=json&v=2.1", videoId)
                )
            );
        }
        public async Task<CommentsEntries> GetRelevantComments(string videoId, AccessToken token)
        {
            List<KeyValuePair<string, string>> k = new List<KeyValuePair<string, string>>();
            k.Add(new KeyValuePair<string, string>("Host", "gdata.youtube.com"));
            k.Add(new KeyValuePair<string, string>("X-GData-Key", "key=AIzaSyCH5E5roCLWZgTmZK938wTMFgT3BYXhsvI"));
            k.Add(new KeyValuePair<string, string>("GData-Version", "2.1"));
            k.Add(new KeyValuePair<string, string>("Authorization", token.token_type + " " + token.access_token));

            string result = await Util.MakeWebRequestAsync(
                string.Format("https://gdata.youtube.com/feeds/api/videos/{0}/comments?alt=json&v=2&relevant-to-me=true", videoId),k
            );
            return JsonConvert.DeserializeObject<CommentsEntries>(result);
        }
    }
    public class CommentEntry
    {
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id2 id { get; set; }
        public Published published { get; set; }
        public Updated2 updated { get; set; }
        public List<Category2> category { get; set; }
        public Title title { get; set; }
        public Content2 content { get; set; }
        public List<Link2> link { get; set; }
        public List<Author2> author { get; set; }
        [JsonProperty("yt$channelId")]
        public YtChannelId yt_channelId { get; set; }
        [JsonProperty("yt$replyCount")]
        public YtReplyCount yt_replyCount { get; set; }
        [JsonProperty("yt$videoid")]
        public YtVideoid yt_videoid { get; set; }
        public string UserProfilePicture { get; set; }
    }
    public class Feed
    {
        public string xmlns { get; set; }
        [JsonProperty("xmlns$gd")]
        public string xmlns_gd { get; set; }
        [JsonProperty("xmlns$openSearch")]
        public string xmlns_openSearch { get; set; }
        [JsonProperty("xmlns_yt")]
        public string xmlns_yt { get; set; }
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Logo logo { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        public Generator generator { get; set; }
        [JsonProperty("openSearch$totalResults")]
        public OpenSearchTotalResults openSearch_totalResults { get; set; }
        [JsonProperty("openSearch$itemsPerPage")]
        public OpenSearchItemsPerPage openSearch_itemsPerPage { get; set; }
        public List<CommentEntry> entry { get; set; }
    }

    public class CommentsEntries
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Feed feed { get; set; }
    }

}
