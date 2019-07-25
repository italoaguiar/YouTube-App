using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeControls.GoogleAPI.YouTube.Channel
{
    public sealed class ChannelEntries
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Feed feed { get; set; }
    }
    public sealed class Id
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Updated
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Category
    {
        public string scheme { get; set; }
        public string term { get; set; }
    }

    public sealed class Title
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Logo
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public sealed class Name
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Uri
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Author
    {
        public Name name { get; set; }
        public Uri uri { get; set; }
    }

    public sealed class Generator
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string version { get; set; }
        public string uri { get; set; }
    }

    public sealed class OpenSearchTotalResults
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }

    public sealed class OpenSearchStartIndex
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }

    public sealed class OpenSearchItemsPerPage
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }

    public sealed class Id2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Updated2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Category2
    {
        public string scheme { get; set; }
        public string term { get; set; }
    }

    public sealed class Title2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Summary
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Link2
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public sealed class Name2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Uri2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class YtUserId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Author2
    {
        public Name2 name { get; set; }
        public Uri2 uri { get; set; }
        [JsonProperty("yt$userId")]
        public YtUserId yt_userId { get; set; }
    }

    public sealed class YtChannelId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class YtChannelStatistics
    {
        public string subscriberCount { get; set; }
        public string viewCount { get; set; }
    }

    public sealed class GdFeedLink
    {
        public string rel { get; set; }
        public string href { get; set; }
        public int countHint { get; set; }
    }

    public sealed class MediaThumbnail
    {
        public string url { get; set; }
    }

    public sealed class Entry
    {
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id2 id { get; set; }
        public Updated2 updated { get; set; }
        public IList<Category2> category { get; set; }
        public Title2 title { get; set; }
        public Summary summary { get; set; }
        public IList<Link2> link { get; set; }
        public IList<Author2> author { get; set; }
        [JsonProperty("yt$channelId")]
        public YtChannelId yt_channelId { get; set; }
        [JsonProperty("yt$channelStatistics")]
        public YtChannelStatistics yt_channelStatistics { get; set; }
        [JsonProperty("gd$feedLink")]
        public IList<GdFeedLink> gd_feedLink { get; set; }
        [JsonProperty("media$thumbnail")]
        public IList<MediaThumbnail> media_thumbnail { get; set; }
    }

    public sealed class Feed
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
        public IList<Category> category { get; set; }
        public Title title { get; set; }
        public Logo logo { get; set; }
        public IList<Link> link { get; set; }
        public IList<Author> author { get; set; }
        public Generator generator { get; set; }
        [JsonProperty("openSearch$totalResults")]
        public OpenSearchTotalResults openSearch_totalResults { get; set; }
        [JsonProperty("openSearch$startIndex")]
        public OpenSearchStartIndex openSearch_startIndex { get; set; }
        [JsonProperty("openSearch$itemsPerPage")]
        public OpenSearchItemsPerPage openSearch_itemsPerPage { get; set; }
        public IList<Entry> entry { get; set; }
    }
}
