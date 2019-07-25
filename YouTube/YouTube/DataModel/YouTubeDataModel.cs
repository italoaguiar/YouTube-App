using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace YouTube.DataModel.GData
{
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
    public class Category
    {
        public string scheme { get; set; }
        public string term { get; set; }
    }
    public class Title
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Logo
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

    public class Name
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Uri
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Author
    {
        public Name name { get; set; }
        public Uri uri { get; set; }
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

    public class Summary
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Published
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

    public class Title2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string src { get; set; }
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

    public class YtUserId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class YtUserId2
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class YtChannelId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Author2
    {
        public Name2 name { get; set; }
        public Uri2 uri { get; set; }
        [JsonProperty("yt$userId")]
        public YtUserId  ytuserId { get; set; }
    }

    public class YtAccessControl
    {
        public string action { get; set; }
        public string permission { get; set; }
    }

    public class GdFeedLink
    {
        public string rel { get; set; }
        public string href { get; set; }
        public int countHint { get; set; }
    }

    public class GdComments
    {
        [JsonProperty("gd$feedLink")]
        public GdFeedLink gdfeedLink { get; set; }
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
        public int  ytformat { get; set; }
    }

    public class MediaCredit
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string role { get; set; }
        public string scheme { get; set; }
        [JsonProperty("yt$display")]
        public string  ytdisplay { get; set; }
        [JsonProperty("yt$type")]
        public string  yttype { get; set; }
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

    public class MediaThumbnail
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string time { get; set; }
        [JsonProperty("yt$name")]
        public string  ytname { get; set; }
    }
    public class MediaThumbnail2
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

    public class MediaGroup
    {
        [JsonProperty("media$category")]
        public List<MediaCategory>  mediacategory { get; set; }
        [JsonProperty("media$content")]
        public List<MediaContent>  mediacontent { get; set; }
        [JsonProperty("media$credit")]
        public List<MediaCredit>  mediacredit { get; set; }
        [JsonProperty("media$description")]
        public MediaDescription  mediadescription { get; set; }
        [JsonProperty("media$keywords")]
        public MediaKeywords  mediakeywords { get; set; }
        [JsonProperty("media$licence")]
        public MediaLicense  medialicense { get; set; }
        [JsonProperty("media$player")]
        public MediaPlayer  mediaplayer { get; set; }
        [JsonProperty("media$thumbnail")]
        public List<MediaThumbnail>  mediathumbnail { get; set; }
        [JsonProperty("media$title")]
        public MediaTitle  mediatitle { get; set; }
        [JsonProperty("yt$aspectRatio")]
        public YtAspectRatio  ytaspectRatio { get; set; }
        [JsonProperty("yt$duration")]
        public YtDuration  ytduration { get; set; }
        [JsonProperty("yt$uploaded")]
        public YtUploaded  ytuploaded { get; set; }
        [JsonProperty("yt$uploaderId")]
        public YtUploaderId  ytuploaderId { get; set; }
        [JsonProperty("yt$videoid")]
        public YtVideoid  ytvideoid { get; set; }
    }

    public class GdRating
    {
        public double average { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public int numRaters { get; set; }
        public string rel { get; set; }
    }

    public class YtStatistics
    {
        public string favoriteCount { get; set; }
        public string viewCount { get; set; }
    }

    public class YtRating
    {
        public string numDislikes { get; set; }
        public string numLikes { get; set; }
    }

    public class YtState
    {
        [JsonProperty("$t")]
        public string t { get; set; }
        public string name { get; set; }
        public string reasonCode { get; set; }
    }
    public class YtLocation
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class YtGooglePlusUserId
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }
    public class YtUsername
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class AppControl
    {
        [JsonProperty("yt$state")]
        public YtState  ytstate { get; set; }
    }

    public class GmlPos
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class GmlPoint
    {
        [JsonProperty("gml$pos")]
        public GmlPos  gmlpos { get; set; }
    }

    public class GeorssWhere
    {
        [JsonProperty("gml$Point")]
        public GmlPoint  gmlPoint { get; set; }
    }

    public class YtRecorded
    {
        [JsonProperty("$t")]
        public string t { get; set; }
    }

    public class Entry
    {
        [JsonProperty("gd$etag")]
        public string  gdetag { get; set; }
        public Id2 id { get; set; }
        public Published published { get; set; }
        public Updated2 updated { get; set; }
        public List<Category2> category { get; set; }
        public Title2 title { get; set; }
        public Content content { get; set; }
        public List<Link2> link { get; set; }
        public List<Author2> author { get; set; }
        [JsonProperty("yt$accessControl")]
        public List<YtAccessControl>  ytaccessControl { get; set; }
        [JsonProperty("gd$comments")]
        public GdComments  gdcomments { get; set; }
        [JsonProperty("yt$hd")]
        public YtHd  ythd { get; set; }
        [JsonProperty("media$group")]
        public MediaGroup  mediagroup { get; set; }
        [JsonProperty("gd$rating")]
        public GdRating  gdrating { get; set; }
        [JsonProperty("yt$statistics")]
        public YtStatistics  ytstatistics { get; set; }
        [JsonProperty("yt$rating")]
        public YtRating  ytrating { get; set; }
        [JsonProperty("app$control")]
        public AppControl  appcontrol { get; set; }
        [JsonProperty("georss$where")]
        public GeorssWhere  georsswhere { get; set; }
        [JsonProperty("yt$recorded")]
        public YtRecorded  ytrecorded { get; set; }
    }

    public class Feed
    {
        [JsonProperty("xmlns$app")]
        public string  xmlnsapp { get; set; }
        public string xmlns { get; set; }
        [JsonProperty("xmlns$media")]
        public string  xmlnsmedia { get; set; }
        [JsonProperty("xmlns$openSearch")]
        public string  xmlnsopenSearch { get; set; }
        [JsonProperty("xmlns$gd")]
        public string  xmlnsgd { get; set; }
        [JsonProperty("xmlns$gml")]
        public string  xmlnsgml { get; set; }
        [JsonProperty("xmlns$yt")]
        public string  xmlnsyt { get; set; }
        [JsonProperty("xmlns$georss")]
        public string  xmlnsgeorss { get; set; }
        [JsonProperty("gd$etag")]
        public string  gdetag { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public Logo logo { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        public Generator generator { get; set; }
        [JsonProperty("openSearch$totalResults")]
        public OpenSearchTotalResults  openSearchtotalResults { get; set; }
        [JsonProperty("openSearch$startIndex")]
        public OpenSearchStartIndex  openSearchstartIndex { get; set; }
        [JsonProperty("openSearch$itemsPerPage")]
        public OpenSearchItemsPerPage  openSearchitemsPerPage { get; set; }
        public List<Entry> entry { get; set; }


        [JsonProperty("media$thumbnail")]
        public MediaThumbnail2 mediathumbnail { get; set; }
        
    }

    //
    // Profile data
    //

    public class UserProfile
    {
        public string xmlns { get; set; }
        [JsonProperty("xmlns$gd")]
        public string  xmlnsgd { get; set; }
        [JsonProperty("xmlns$gml")]
        public string  xmlnsgml { get; set; }
        [JsonProperty("xmlns$yt")]
        public string  xmlnsyt { get; set; }
        [JsonProperty("gd$etag")]
        public string  gdetag { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public Published published { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public Summary summary { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        [JsonProperty("yt$channelId")]
        public YtChannelId ytchannelId { get; set; }
        [JsonProperty("gd$feedLink")]
        public List<GdFeedLink> gdfeedLink { get; set; }
        [JsonProperty("yt$googlePlusUserId")]
        public YtGooglePlusUserId ytgooglePlusUserId { get; set; }
        [JsonProperty("yt$location")]
        public YtLocation ytlocation { get; set; }
        [JsonProperty("yt$statistics")]
        public YtStatistics ytstatistics { get; set; }
        [JsonProperty("media$thumbnail")]
        public MediaThumbnail2 mediathumbnail { get; set; }
        [JsonProperty("yt$userId")]
        public YtUserId2 ytuserId { get; set; }
        [JsonProperty("yt$username")]
        public YtUsername ytusername { get; set; }
    }

    public class YouTubeDataFeed
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Feed feed { get; set; }
    }
    public class UserProfileFeed
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public UserProfile entry { get; set; }
    }


    //
    // Comments
    //
    public class YtReplyCount
    {
        [JsonProperty("$t")]
        public int t { get; set; }
    }
    public class CommentsEntry
    {
        [JsonProperty("gd$etag")]
        public string gdetag { get; set; }
        public Id2 id { get; set; }
        public Published published { get; set; }
        public Updated2 updated { get; set; }
        public List<Category2> category { get; set; }
        public Title title { get; set; }
        public Content content { get; set; }
        public List<Link2> link { get; set; }
        public List<Author2> author { get; set; }
        [JsonProperty("yt$channelId")]
        public YtChannelId ytchannelId { get; set; }
        [JsonProperty("yt$googlePlusUserId")]
        public YtGooglePlusUserId ytgooglePlusUserId { get; set; }
        [JsonProperty("yt$replyCount")]
        public YtReplyCount ytreplyCount { get; set; }
        [JsonProperty("yt$videoid")]
        public YtVideoid ytvideoid { get; set; }
    }

    public class Comments
    {
        public string xmlns { get; set; }
        [JsonProperty("xmlns$openSearch")]
        public string xmlnsopenSearch { get; set; }
        [JsonProperty("xmlns$gd")]
        public string xmlnsgd { get; set; }
        [JsonProperty("xmlns$yt")]
        public string xmlnsyt { get; set; }
        [JsonProperty("gd$etag")]
        public string gdetag { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Logo logo { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        public Generator generator { get; set; }
        [JsonProperty("openSearch$totalResults")]
        public OpenSearchTotalResults openSearchtotalResults { get; set; }
        [JsonProperty("openSearch$itemsPerPage")]
        public OpenSearchItemsPerPage openSearchitemsPerPage { get; set; }
        public List<CommentsEntry> entry { get; set; }
    }

    public class CommentsFeed
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Comments feed { get; set; }
    }
}
