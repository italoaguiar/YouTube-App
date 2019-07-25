using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeControls.GoogleAPI.YouTube.Video;

namespace YouTubeControls.GoogleAPI.YouTube.PlayList
{
    class PlayList
    {
        public async Task<VideoEntries> Search(string query)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/playlists/snippets?q={0}&v=2&alt=json", query))
            );
        }
        public async Task<VideoEntries> Search(string query, string args)
        {
            return JsonConvert.DeserializeObject<VideoEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/playlists/snippets?q={0}&v=2&alt=json&{1}", query,args))
            );
        }
    }
}
