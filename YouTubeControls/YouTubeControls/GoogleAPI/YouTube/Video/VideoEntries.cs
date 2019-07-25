using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeControls.GoogleAPI.YouTube.Video
{
    public sealed class VideoEntries
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

    public sealed class Published
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
        public string label { get; set; }
    }

    public sealed class Title2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Content
    {
        public string type { get; set; }
        public string src { get; set; }
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

    public sealed class YtAccessControl
    {
        public string action { get; set; }
        public string permission { get; set; }
    }

    public sealed class GdFeedLink
    {
        public string rel { get; set; }
        public string href { get; set; }
        public int countHint { get; set; }
    }

    public sealed class GdComments
    {
        [JsonProperty("gd$feedLink")]
        public GdFeedLink gd_feedLink { get; set; }
    }

    public sealed class YtHd
    {
    }

    public sealed class MediaCategory
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string label { get; set; }
        public string scheme { get; set; }
    }

    public sealed class MediaContent
    {
        public string url { get; set; }
        public string type { get; set; }
        public string medium { get; set; }
        public string isDefault { get; set; }
        public string expression { get; set; }
        public int duration { get; set; }
        [JsonProperty("yt$format")]
        public int yt_format { get; set; }
    }

    public sealed class MediaCredit
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string role { get; set; }
        public string scheme { get; set; }
        [JsonProperty("yt$display")]
        public string yt_display { get; set; }
        [JsonProperty("yt$type")]
        public string yt_type { get; set; }
    }

    public sealed class MediaDescription
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
    }

    public sealed class MediaKeywords
    {
    }

    public sealed class MediaLicense
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public sealed class MediaPlayer
    {
        public string url { get; set; }
    }

    public sealed class MediaThumbnail
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string time { get; set; }
        [JsonProperty("yt$name")]
        public string yt_name { get; set; }
    }

    public sealed class MediaTitle
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
    }

    public sealed class YtAspectRatio
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class YtDuration
    {
        public string seconds { get; set; }
    }

    public sealed class YtUploaded
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class YtUploaderId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class YtVideoid
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class MediaRestriction
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
        public string relationship { get; set; }
    }

    public sealed class MediaRating
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string scheme { get; set; }
    }

    public sealed class MediaGroup
    {
        [JsonProperty("media$category")]
        public IList<MediaCategory> media_category { get; set; }
        [JsonProperty("media$content")]
        public IList<MediaContent> media_content { get; set; }
        [JsonProperty("media$credit")]
        public IList<MediaCredit> media_credit { get; set; }
        [JsonProperty("media$description")]
        public MediaDescription media_description { get; set; }
        [JsonProperty("media$keywords")]
        public MediaKeywords media_keywords { get; set; }
        [JsonProperty("media$license")]
        public MediaLicense media_license { get; set; }
        [JsonProperty("media$player")]
        public MediaPlayer media_player { get; set; }
        [JsonProperty("media$thumbnail")]
        public IList<MediaThumbnail> media_thumbnail { get; set; }
        [JsonProperty("media$title")]
        public MediaTitle media_title { get; set; }
        [JsonProperty("yt$aspectRatio")]
        public YtAspectRatio yt_aspectRatio { get; set; }
        [JsonProperty("yt$duration")]
        public YtDuration yt_duration { get; set; }
        [JsonProperty("yt$uploaded")]
        public YtUploaded yt_uploaded { get; set; }
        [JsonProperty("yt$uploaderId")]
        public YtUploaderId yt_uploaderId { get; set; }
        [JsonProperty("yt$videoid")]
        public YtVideoid yt_videoid { get; set; }
        [JsonProperty("media$restriction")]
        public IList<MediaRestriction> media_restriction { get; set; }
        [JsonProperty("media$rating")]
        public IList<MediaRating> media_rating { get; set; }
    }

    public sealed class YtNoembed
    {
    }

    public sealed class GdRating
    {
        public double average { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public int numRaters { get; set; }
        public string rel { get; set; }
    }

    public sealed class YtStatistics
    {
        public string favoriteCount { get; set; }
        public string viewCount { get; set; }
    }

    public sealed class YtRating
    {
        public string numDislikes { get; set; }
        public string numLikes { get; set; }
    }

    public sealed class YtState
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string name { get; set; }
        public string reasonCode { get; set; }
    }

    public sealed class AppControl
    {
        [JsonProperty("yt$state")]
        public YtState yt_state { get; set; }
    }

    public sealed class YtEpisode
    {
        public string number { get; set; }
    }

    public sealed class YtFirstReleased
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public sealed class Entry
    {
        [JsonProperty("gd$etag")]
        public string gd_etag { get; set; }
        public Id2 id { get; set; }
        public Published published { get; set; }
        public Updated2 updated { get; set; }
        public IList<Category2> category { get; set; }
        public Title2 title { get; set; }
        public Content content { get; set; }
        public IList<Link2> link { get; set; }
        public IList<Author2> author { get; set; }
        [JsonProperty("yt$accessControl")]
        public IList<YtAccessControl> yt_accessControl { get; set; }
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
        [JsonProperty("xmlns$app")]
        public string xmlns_app { get; set; }
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
