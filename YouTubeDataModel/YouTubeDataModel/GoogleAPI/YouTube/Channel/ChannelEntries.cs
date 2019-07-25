using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeDataModel.GoogleAPI.YouTube.Common;

namespace YouTubeControls.GoogleAPI.YouTube.Channel
{
    public  class ChannelEntries
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
        public Updated2 updated { get; set; }
        public List<Category2> category { get; set; }
        public Title2 title { get; set; }
        public Summary summary { get; set; }
        public List<Link2> link { get; set; }
        public List<Author2> author { get; set; }
        [JsonProperty("yt$channelId")]
        public YtChannelId yt_channelId { get; set; }
        [JsonProperty("yt$channelStatistics")]
        public YtChannelStatistics yt_channelStatistics { get; set; }
        [JsonProperty("gd$feedLink")]
        public List<GdFeedLink> gd_feedLink { get; set; }
        [JsonProperty("media$thumbnail")]
        public List<MediaThumbnail> media_thumbnail { get; set; }
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



    public class PartnerEntry
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
        [JsonProperty("xmlns$app")]
        public string xmlns_app { get; set; }
        public Id id { get; set; }
        public Published published { get; set; }
        public Updated updated { get; set; }
        [JsonProperty("app$edited")]
        public AppEdited app_edited { get; set; }
        public List<Category> category { get; set; }
        public List<Link> link { get; set; }
        [JsonProperty("yt$option")]
        public List<YtOption> yt_option { get; set; }
    }

    public class Partner
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public PartnerEntry entry { get; set; }
    }
}
