using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

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
        public static async Task<string> MakeWebPostRequestAsync(string url, List<KeyValuePair<string, string>> values, string content, System.Net.Http.Headers.MediaTypeHeaderValue cType)
        {
            HttpClient http = new System.Net.Http.HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, url);

            foreach (KeyValuePair<string, string> s in values)
            {
                msg.Headers.Add(s.Key, s.Value);
            }
            msg.Content = new StringContent(content);
            msg.Content.Headers.ContentType = cType;
            
            return await http.SendAsync(msg).Result.Content.ReadAsStringAsync();
        }
        public static async Task<string> MakeWebRequestAsync(string url, List<KeyValuePair<string, string>> values)
        {
            HttpClient http = new System.Net.Http.HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url);

            foreach (KeyValuePair<string, string> s in values)
            {
                msg.Headers.Add(s.Key, s.Value);
            }

            return await http.SendAsync(msg).Result.Content.ReadAsStringAsync();
        }
        public static async Task<string> MakeWebDeleteRequestAsync(string url, List<KeyValuePair<string, string>> values, string content, System.Net.Http.Headers.MediaTypeHeaderValue cType)
        {
            HttpClient http = new System.Net.Http.HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Delete, url);

            foreach (KeyValuePair<string, string> s in values)
            {
                msg.Headers.Add(s.Key, s.Value);
            }
            msg.Content = new StringContent(content);
            msg.Content.Headers.ContentType = cType;

            return await http.SendAsync(msg).Result.Content.ReadAsStringAsync();
        }

    }
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // No format provided.
            if (parameter == null)
            {
                return value;
            }

            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public static class ColorHelper
    {
        public static SolidColorBrush GetColorFromHexa(string hexaColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    255,
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16)
                )
            );
        }
    }
}
