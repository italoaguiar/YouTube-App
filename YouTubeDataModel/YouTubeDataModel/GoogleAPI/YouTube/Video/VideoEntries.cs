using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeDataModel.GoogleAPI.YouTube.Common;

namespace YouTubeControls.GoogleAPI.YouTube.Video.Entries
{
    public  class VideoEntries
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Feed feed { get; set; }
    }
    public  class Entry
    {
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id2 id { get; set; }
        public Published published { get; set; }
        public Updated2 updated { get; set; }
        public List<Category2> category { get; set; }
        public Title2 title { get; set; }
        public Content content { get; set; }
        public List<Link2> link { get; set; }
        public List<Author2> author { get; set; }
        [JsonProperty("yt$accessControl")]
        public List<YtAccessControl> yt_accessControl { get; set; }
        [JsonProperty("gd$comments")]
        public GdComments gd_comments { get; set; }
        [JsonProperty("yt$hd")]
        public YtHd yt_hd { get; set; }
        [JsonProperty("media$group")]
        public MediaGroup media_group { get; set; }
        [JsonProperty("yt$noembed")]
        public YtNoembed yt_noembed { get; set; }
        [JsonProperty("gd$rating")]
        public GdRating gd_rating { get; set; }
        [JsonProperty("yt$statistics")]
        public YtStatistics yt_statistics { get; set; }
        [JsonProperty("yt$rating")]
        public YtRating yt_rating { get; set; }
        [JsonProperty("app$control")]
        public AppControl app_control { get; set; }
        [JsonProperty("yt$episode")]
        public YtEpisode yt_episode { get; set; }
        [JsonProperty("yt$firstReleased")]
        public YtFirstReleased yt_firstReleased { get; set; }
    }
    public class SingleFeed
    {
        public Entry entry { get; set; }
    }
    public  class Feed
    {
        public string xmlns { get; set; }
        [JsonProperty("xmlns$gd")]
        public string xmlns_gd { get; set; }
        [JsonProperty("xmlns$openSearch")]
        public string xmlns_openSearch { get; set; }
        [JsonProperty("xmlns$yt")]
        public string xmlns_yt { get; set; }
        [JsonProperty("xmlns$media")]
        public string xmlns_media { get; set; }
        [JsonProperty("xmlns$app")]
        public string xmlns_app { get; set; }
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public Logo logo { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        public Generator generator { get; set; }
        [JsonProperty("openSearch$totalResults")]
        public OpenSearchTotalResults openSearch_totalResults { get; set; }
        [JsonProperty("openSearch$startIndex")]
        public OpenSearchStartIndex openSearch_startIndex { get; set; }
        [JsonProperty("openSearch$itemsPerPage")]
        public OpenSearchItemsPerPage openSearch_itemsPerPage { get; set; }
        public List<Entry> entry { get; set; }
    }
}
