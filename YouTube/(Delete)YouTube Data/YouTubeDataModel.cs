using Google.YouTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_Data
{
    public class YouTubeDataModel
    {
        public static string devKey = "AI39si6bhGnf6Td6xQYRBbLsAXOBZCQeqh77iqf6dL4h_ssEI8Q5tdUBHC8dazU4bQbZAbByI4D6Cxr0kkrt-2OwSZn3Ni46Jg";

        public static Video getVideoDetails(string videoID)
        {
            YouTubeRequestSettings settings = new YouTubeRequestSettings("YouTube VideoDownloader", devKey);
            YouTubeRequest request = new YouTubeRequest(settings);
            Uri videoEntryUrl = new Uri(string.Format("http://gdata.youtube.com/feeds/api/videos/{0}", videoID));
            Video video = request.Retrieve<Video>(videoEntryUrl);

            //video.Contents[0].Url;
            return video;
        }


    }
}
