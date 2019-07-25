using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using YouTubeDataModel.GoogleAPI.YouTube.User;

namespace YouTubeControls.GoogleAPI.YouTube.Channel
{
    public class Channel
    {
        public async Task<ChannelEntries> Search(string query)
        {
            return JsonConvert.DeserializeObject<ChannelEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/channels?q={0}&v=2&alt=json", query))
            );
        }
        public async Task<ChannelEntries> Search(string query,string args)
        {
            return JsonConvert.DeserializeObject<ChannelEntries>(
                await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/channels?q={0}&v=2&alt=json&{1}", query,args))
            );
        }
        public async Task<Partner> GetPartnerData(string id)
        {
            return JsonConvert.DeserializeObject<Partner>(
               await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/partners/{0}/branding/default?v=2&alt=json&key=AIzaSyCH5E5roCLWZgTmZK938wTMFgT3BYXhsvI", id))
           );
        }
        public async Task<string> Subscribe(string username, AccessToken token)
        {
            string ch = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><entry xmlns=\"http://www.w3.org/2005/Atom\" " +
                "xmlns:yt=\"http://gdata.youtube.com/schemas/2007\"><category scheme=\"http://gdata.youtube.com/schemas/2007/subscriptiontypes.cat\" " +
                "term=\"channel\"/><yt:username>" + username + "</yt:username></entry>";


            List<KeyValuePair<string, string>> k = new List<KeyValuePair<string, string>>();
            k.Add(new KeyValuePair<string, string>("Host", "gdata.youtube.com"));
            k.Add(new KeyValuePair<string, string>("X-GData-Key", "key=AIzaSyCH5E5roCLWZgTmZK938wTMFgT3BYXhsvI"));
            k.Add(new KeyValuePair<string, string>("GData-Version", "2.1"));
            k.Add(new KeyValuePair<string, string>("Authorization", token.token_type + " " + token.access_token));

            return await Util.MakeWebPostRequestAsync("https://gdata.youtube.com/feeds/api/users/default/subscriptions/",
                k, ch, new System.Net.Http.Headers.MediaTypeHeaderValue("application/atom+xml")
            );
        }
    }
}
