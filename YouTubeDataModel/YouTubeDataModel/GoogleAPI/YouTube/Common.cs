using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDataModel.GoogleAPI.YouTube.Common
{
    public class YtUserId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class YtChannelId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Id
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Updated
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class YtOption
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string name { get; set; }
    }
    public class Category
    {
        public string scheme { get; set; }
        public string term { get; set; }
    }
    public class Name
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Url
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Author
    {
        public Name name { get; set; }
        public Url uri { get; set; }
        [JsonProperty("yt$userId")]
        public YtUserId userId { get; set; }
    }
    public class Published
    {
        [JsonProperty("$t")]
        public DateTime t { get; set; }
    }

    public class Title
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Summary
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }





    public class GdFeedLink
    {
        public string rel { get; set; }
        public string href { get; set; }
        public int countHint { get; set; }
    }

    public class YtGooglePlusUserId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class YtLocation
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class YtStatistics
    {
        public string lastWebAccess { get; set; }
        public int subscriberCount { get; set; }
        public int videoWatchCount { get; set; }
        public int viewCount { get; set; }
        public string totalUploadViews { get; set; }
    }

    public class MediaThumbnail
    {
        public string url { get; set; }
    }

    public class YtUserId2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class YtUsername
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string display { get; set; }
    }
    public class Logo
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Uri
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Generator
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string version { get; set; }
        public string uri { get; set; }
    }

    public class OpenSearchTotalResults
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }

    public class OpenSearchStartIndex
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }

    public class OpenSearchItemsPerPage
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }

    public class Id2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Updated2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Category2
    {
        public string scheme { get; set; }
        public string term { get; set; }
        public string label { get; set; }
    }
    public class AppEdited
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Title2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string src { get; set; }
    }
    public class Content2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Link2
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Name2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Uri2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class Author2
    {
        public Name2 name { get; set; }
        public Uri2 uri { get; set; }
        [JsonProperty("yt$userId")]
        public YtUserId yt_userId { get; set; }
    }

    public class YtAccessControl
    {
        public string action { get; set; }
        public string permission { get; set; }
    }
    public class GdComments
    {
        [JsonProperty("gd$feedLink")]
        public GdFeedLink gd_feedLink { get; set; }
    }

    public class YtHd
    {
    }

    public class MediaCategory
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string label { get; set; }
        public string scheme { get; set; }
    }

    public class MediaContent
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

    public class MediaCredit
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

    public class MediaDescription
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
    }

    public class MediaKeywords
    {
    }

    public class MediaLicense
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class MediaPlayer
    {
        public string url { get; set; }
    }
    public class MediaTitle
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
    }

    public class YtAspectRatio
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class YtDuration
    {
        public string seconds { get; set; }
    }

    public class YtUploaded
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class YtUploaderId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class YtVideoid
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class MediaRestriction
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string type { get; set; }
        public string relationship { get; set; }
    }

    public class MediaRating
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string scheme { get; set; }
    }

    public class MediaGroup
    {
        [JsonProperty("media$category")]
        public List<MediaCategory> media_category { get; set; }
        [JsonProperty("media$content")]
        public List<MediaContent> media_content { get; set; }
        [JsonProperty("media$credit")]
        public List<MediaCredit> media_credit { get; set; }
        [JsonProperty("media$description")]
        public MediaDescription media_description { get; set; }
        [JsonProperty("media$keywords")]
        public MediaKeywords media_keywords { get; set; }
        [JsonProperty("media$license")]
        public MediaLicense media_license { get; set; }
        [JsonProperty("media$player")]
        public MediaPlayer media_player { get; set; }
        [JsonProperty("media$thumbnail")]
        public List<MediaThumbnail> media_thumbnail { get; set; }
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
        public List<MediaRestriction> media_restriction { get; set; }
        [JsonProperty("media$rating")]
        public List<MediaRating> media_rating { get; set; }
    }

    public class YtNoembed
    {
    }
    public class YtReplyCount
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }
    public class YtChannelStatistics
    {
        public int subscriberCount { get; set; }
        public int viewCount { get; set; }
    }
    public class GdRating
    {
        public double average { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public int numRaters { get; set; }
        public string rel { get; set; }
    }
    public class YtRating
    {
        public int numDislikes { get; set; }
        public int numLikes { get; set; }
        public int Total { get { return numDislikes + numLikes; } }
    }

    public class YtState
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string name { get; set; }
        public string reasonCode { get; set; }
    }

    public class AppControl
    {
        [JsonProperty("yt$state")]
        public YtState yt_state { get; set; }
    }

    public class YtEpisode
    {
        public string number { get; set; }
    }

    public class YtFirstReleased
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
}
