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


    }
}
