using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace YouTube.DataModel
{
    class Downloader
    {
        public static async Task<string> MakeWebRequestAsync(string url)
        {
            try
            {
                HttpClient http = new System.Net.Http.HttpClient();
                HttpResponseMessage response = await http.GetAsync(url);
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string getVideoUrls(string html)
        {
            string v = Regex.Match(html, "\"url_encoded_fmt_stream_map\": \"(.*?)\"", RegexOptions.Singleline).Groups[1].ToString();
            return v;
        }
        public static async void getvideo(string url)
        {
            string v = await MakeWebRequestAsync(url);
            string q = getVideoUrls(v);
            Debug.WriteLine(q);
            MessageDialog d = new MessageDialog(q);
            await d.ShowAsync();
        }
    }
}
