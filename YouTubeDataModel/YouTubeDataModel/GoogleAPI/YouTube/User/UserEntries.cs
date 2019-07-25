using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeDataModel.GoogleAPI.YouTube.Common;

namespace YouTubeDataModel.GoogleAPI.YouTube.User
{

    

    public class UEntry
    {
        public string xmlns { get; set; }
        [JsonProperty("xmlns$gd")]
        public string xmlns_gd { get; set; }
        [JsonProperty("xmlns$yt")]
        public string xmlns_yt { get; set; }
        [JsonProperty("xmlns$media")]
        public string xmlns_media { get; set; }
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id id { get; set; }
        public Published published { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public Summary summary { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        [JsonProperty("yt$channelId")]
        public YtChannelId yt_channelId { get; set; }
        [JsonProperty("gd$feedLink")]
        public List<GdFeedLink> gd_feedLink { get; set; }
        [JsonProperty("yt$googlePlusUserId")]
        public YtGooglePlusUserId yt_googlePlusUserId { get; set; }
        [JsonProperty("yt$location")]
        public YtLocation yt_location { get; set; }
        [JsonProperty("yt$statistics")]
        public YtStatistics yt_statistics { get; set; }
        [JsonProperty("media$thumbnail")]
        public MediaThumbnail media_thumbnail { get; set; }
        [JsonProperty("yt$userId")]
        public YtUserId2 yt_userId { get; set; }
        [JsonProperty("yt$username")]
        public YtUsername yt_username { get; set; }
    }

    public class UserEntries
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public UEntry entry { get; set; }
    }
}
