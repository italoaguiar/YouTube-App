using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeControls.GoogleAPI.YouTube
{
    class Util
    {
        public static async Task<string> MakeWebRequestAsync(string url)
        {
            HttpClient http = new System.Net.Http.HttpClient();
            HttpResponseMessage response = await http.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> MakeWebPostRequestAsync(string url, List<KeyValuePair<string, string>> values)
        {
            var content = new FormUrlEncodedContent(values);
            HttpClient http = new System.Net.Http.HttpClient();
            return await http.PostAsync(url, content).Result.Content.ReadAsStringAsync();
        }
    }
}
