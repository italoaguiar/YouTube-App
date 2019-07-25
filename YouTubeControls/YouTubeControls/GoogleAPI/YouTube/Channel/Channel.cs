using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace YouTubeControls.GoogleAPI.YouTube.Channel
{
    public sealed class Channel
    {
        public IAsyncOperation<ChannelEntries> Search(string query)
        {
            return Search(query, null).AsAsyncOperation();
        }
        private async Task<ChannelEntries> Search(string query,string args)
        {
            return JsonConvert.DeserializeObject<ChannelEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/channels?q={0}&v=2&alt=json&{1}", query,args))
            );
        }
    }
}
