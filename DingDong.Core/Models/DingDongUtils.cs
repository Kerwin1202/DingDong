using RestSharp;
using System.Text;
using System.Web;

namespace DingDong.Monitor.Models
{

    public static class DingDongUtils
    {
        public static Uri Append(this Uri uri, string key, string? value = null)
        {
            var param = $"&{key}={value}";
            var url = uri.ToString();
            if (url.Contains("?"))
            {
                url += param;
            }
            else
            {
                url += $"?{param.Trim('&')}";
            }
            return new Uri(url);
        }

        public static string ToBody(this Dictionary<string, string?> body)
        {
            var sb = new StringBuilder();
            foreach (var item in body)
            {
                sb.Append(item.Key)
                    .Append("=")
                    .Append(item.Value == null ? string.Empty : HttpUtility.UrlEncode(item.Value))
                    .Append("&");
            }
            return sb.ToString().Trim('&');
        }

        public static Dictionary<string, string?> Append(this Dictionary<string, string?> body, string key, string? value = null)
        {
            body.Add(key, value);
            return body;
        }


        public static DingDongConfig? Convert2Config(string url)
        {
            var uri = new Uri(url);
            var config = new DingDongConfig();
            if (config == null)
            {
                return null;
            }
            var paramInfos = HttpUtility.ParseQueryString(uri.Query);
            var allPrepertiesIsOk = false;
            foreach (var item in typeof(DingDongConfig).GetProperties())
            {
                var value = paramInfos.Get(item.Name);
                if (string.IsNullOrWhiteSpace(value))
                {
                    break;
                }
                allPrepertiesIsOk = true;
                item.SetValue(config, value);
            }
            if (allPrepertiesIsOk)
            {
                return config;
            }
            return null;
        }

        public static long NowTimeStamp => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="message"></param>
        public static void Push(string url, string message)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }
            var groupName = HttpUtility.UrlEncode("叮咚助手");
            var msg = HttpUtility.UrlEncode(message);
            var client = new RestClient($"{url.TrimEnd('/')}/{groupName}/{msg}?group={groupName}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
