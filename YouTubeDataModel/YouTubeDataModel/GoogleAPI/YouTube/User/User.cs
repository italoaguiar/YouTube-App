using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using YouTubeControls.GoogleAPI.YouTube;

namespace YouTubeDataModel.GoogleAPI.YouTube.User
{
    public class User
    {
        public async Task<AccessToken> MakeLogin()
        {
            return await MakeLogin(null);
        }
        public async Task<UserEntries> GetUserDetails(string userId)
        {
            string content = await Util.MakeWebRequestAsync(string.Format("http://gdata.youtube.com/feeds/api/users/{0}?v=2&alt=json", userId));
            return JsonConvert.DeserializeObject<UserEntries>(content);
        }
        public async Task<AccessToken> MakeLogin(string Token)
        {
            const string url = "https://accounts.google.com/o/oauth2/auth?" +
                                "client_id=" + "409828063726.apps.googleusercontent.com" +
                                "&redirect_uri=" + "urn:ietf:wg:oauth:2.0:oob" +
                                "&response_type=code" +
                                "&scope=" + "https://www.googleapis.com/auth/userinfo.profile+https://www.googleapis.com/auth/youtube+"+
                                "https://www.googleapis.com/auth/youtube.readonly+https://www.googleapis.com/auth/youtube.upload";

            Uri startUri = new Uri(url);
            Uri endUri = new Uri("https://accounts.google.com/o/oauth2/approval?");


            if (Token != null)
            {
                return await GetAccessToken(Token, GrantType.refresh_token);
            }
            else
            {
                WebAuthenticationResult webAuthenticationResult =
                    await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.UseTitle, startUri, endUri);

                if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    string token = webAuthenticationResult.ResponseData.Replace("Success code=", "");
                    return await GetAccessToken(token, GrantType.authorization_code);
                }
                else if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                {
                    throw new System.Net.Http.HttpRequestException("Failed to Connect to Login WebService");
                }
                else if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.UserCancel)
                {
                    throw new OperationCanceledException("The user canceled the login attempt.");
                }
                else
                {
                    throw new Exception("Unknown Error");
                }
            }
        }
        enum GrantType
        {
            authorization_code,
            refresh_token
        }
        private async Task<AccessToken> GetAccessToken(string token, GrantType t)
        {
            List<KeyValuePair<string, string>> k = new List<KeyValuePair<string, string>>();
            k.Add(new KeyValuePair<string, string>(t == GrantType.authorization_code ? "code" : "refresh_token", token));
            k.Add(new KeyValuePair<string, string>("client_id", "409828063726.apps.googleusercontent.com"));
            k.Add(new KeyValuePair<string, string>("client_secret", "maIX_et6wkJ5sqDcSjeGJRWZ"));
            if (t == GrantType.authorization_code)
                k.Add(new KeyValuePair<string, string>("redirect_uri", "urn:ietf:wg:oauth:2.0:oob"));
            k.Add(new KeyValuePair<string, string>("grant_type", t.ToString()));

            string response = await Util.MakeWebPostRequestAsync("https://accounts.google.com/o/oauth2/token", k);
            AccessToken at = JsonConvert.DeserializeObject<AccessToken>(response);

            return at;
        }
        public async Task<UserInfo> GetUserInfo(AccessToken token)
        {
            string response = await Util.MakeWebRequestAsync(
                string.Format("https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token={0}", token.access_token)
            );
            UserInfo u = JsonConvert.DeserializeObject<UserInfo>(response);
            return u;
        }
    }
    public class UserInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
    }
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
