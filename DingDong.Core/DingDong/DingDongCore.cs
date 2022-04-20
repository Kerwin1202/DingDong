using DingDong.Core.Models;
using DingDong.Monitor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Web;

namespace DingDong.Monitor.DingDong
{
    /// <summary>
    /// 1. 检查购物车
    /// 2. 检查订单 & 配送时间
    /// 3. 提交订单
    /// </summary>
    public class DingDongCore
    {
        private const string AB_CONFIG = "%7B%22key_onion%22%3A%22D%22%2C%22key_cart_discount_price%22%3A%22C%22%7D";

        private readonly DingDongConfig _config;

        private string? _addressId = null;

        private Action<string> _log = null;
        public bool _track = false;

        public DingDongCore(DingDongConfig config, Action<string> log = null)
        {
            _config = config;
            _log = log;
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        public List<DingDongCategoryInfo> GetAllCategories()
        {
            var url = "https://maicai.api.ddxq.mobi/homeApi/newDetails";
            var result = RequestGet(url, null);
            var json = JObject.Parse(result);
            var categories = new List<DingDongCategoryInfo>();
            foreach (var item in json["data"]["list"])
            {
                if (item["type"].ToString() != "4")
                {
                    continue;
                }
                foreach (var zoneItem in item["icon_zone"])
                {
                    categories.Add(new DingDongCategoryInfo(zoneItem["material"]["link"].ToString().Split('=')[1], zoneItem["material"]["title"].ToString()));
                }
            }
            return categories;
        }

        public void GetCategoriesNewDetail(string categoryId)
        {
            var url = "https://maicai.api.ddxq.mobi/homeApi/categoriesNewDetail";

            var bodys = new Dictionary<string, string>();

            var result = RequestGet(url, GetCommonParams(bodys));

            // https://maicai.api.ddxq.mobi/homeApi/categoriesNewDetail?uid=6252dc5fe858c70001e6fdbd&longitude=121.583564&latitude=31.089303&station_id=5c8879d1716de1f6468b456d&city_number=0101&api_version=9.50.0&app_version=2.83.0&applet_source=&channel=applet&app_client_id=4&sharer_uid=&s_id=be938e944d6a8634567ab7dfba59ec64&openid=osP8I0ThXYtaNd7PtvgeqAc-ZMXo&h5_source=&time=1650031897&device_token=WHJMrwNw1k%2FFKPjcOOgRd%2BFcQ12fJsDdFO4Cj6PkCoDHEw1OK4Rf29NdkTZMY7%2F39PpYIggpYPbnhKJIfzoI1SbBk56c%2FnXhLdCW1tldyDzmauSxIJm5Txg%3D%3D1487582755342&category_id=5fb5644c8858c1fb7f61a660&version_control=new&nars=f092191c9edcb6ef47736b35f85965ce&sesi=FjesEEV974934be98b58008815dd5a53763bdd6
        }

        /// <summary>
        /// 检查订单
        /// </summary>
        public void CheckOrder(New_Order_Product_List2 cart)
        {
            var url = "https://maicai.api.ddxq.mobi/order/checkOrder";
            var bodys = new Dictionary<string, string>();

            bodys.Add("address_id", _addressId);
            bodys.Add("user_ticket_id", "default");
            bodys.Add("freight_ticket_id", "default");
            bodys.Add("is_use_point", "0");
            bodys.Add("is_use_balance", "0");
            bodys.Add("is_buy_vip", "0");
            bodys.Add("coupons_id", "");
            bodys.Add("is_buy_coupons", "0");

            bodys.Add("packages", $"[{JsonConvert.SerializeObject(cart)}]");
            bodys.Add("check_order_type", "1");
            bodys.Add("is_support_merge_payment", "1");

            bodys.Add("showMsg", "false");
            bodys.Add("showData", "true");
            var result = RequestPost(url, GetCommonParams(bodys));
            var obj = JObject.Parse(result);
            if (obj["success"].ToString().ToLower() != "true")
            {
                _log?.Invoke($"检查订单失败. {obj["msg"]}");
                throw new DingDongException(obj["msg"].ToString());
            }
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        public void CreateNewOrder(CartData data, (long startTime, long endTime) reservedTime)
        {
            var url = "https://maicai.api.ddxq.mobi/order/addNewOrder";
            var bodys = new Dictionary<string, string>();

            bodys.Add("ab_config", AB_CONFIG); // %7B%22key_onion%22%3A%22C%22%7D

            var order = new PaymentOrderInfo();
            order.payment_order = new PaymentOrder()
            {
                address_id = _addressId,
                coupons_id = String.Empty,
                coupons_money = String.Empty,
                form_id =  Guid.NewGuid().ToString().Replace("-", string.Empty),
                price = data.total_money,
                freight_discount_money = "5.00",
                freight_money = "5.00",
                order_freight = "0.00",
                parent_order_sign = data.parent_order_info.parent_order_sign,
                pay_type = 6,
                reserved_time_end = (int)reservedTime.endTime,
                reserved_time_start = (int)reservedTime.startTime,
                product_type = 1,
                receipt_without_sku = null,
                vip_buy_user_ticket_id = String.Empty,
                vip_money = string.Empty,
            };

            order.packages = JsonConvert.DeserializeObject<List<Package>>(JsonConvert.SerializeObject(data.new_order_product_list));
            foreach (var package in order.packages)
            {
                package.reserved_time_start = order.payment_order.reserved_time_start;
                package.reserved_time_end = order.payment_order.reserved_time_end;
            }

            bodys.Add("package_order", JsonConvert.SerializeObject(order));
            bodys.Add("showMsg", "false");
            bodys.Add("showData", "true");

            var result = RequestPost(url, GetCommonParams(bodys));
            // {"success":true,"code":0,"msg":"success","data":{"pay_url":"{\"timeStamp\":\"1650182341\",\"package\":\"prepay_id=wx17155901110395404e2ec64b5eccda0000\",\"appId\":\"wx1e113254eda17715\",\"sign\":\"082F7C89FE3FBFB545D9E82EB3712FBF\",\"signType\":\"MD5\",\"nonceStr\":\"70MAHai08O9KqLbll7RVMTAovjgGsj03\"}","pay_online":true,"order_number":"2204171874886872238","cart_count":28,"station_id":"5c8879d1716de1f6468b456d","event_tracking":{"post_product_algo":"{}"}},"tradeTag":"success","server_time":1650182341,"is_trade":1}
            var obj = JObject.Parse(result);
            if (obj["success"].ToString().ToLower() != "true")
            {
                _log?.Invoke($"创建订单失败. {obj["msg"]}");
                throw new DingDongException("");
            }
        }

        /// <summary>
        /// 获取配送时间
        /// </summary>
        /// <param name="addressId"></param>
        public List<(bool closed, long? start_timestamp, long? end_timestamp, string? arrival_time_msg)> GetMultiReserveTime(List<Product3> products)
        {
            CheckDefaultAddress();

            var url = "http://maicai.api.ddxq.mobi/order/getMultiReserveTime";
            var bodys = new Dictionary<string, string>();
            bodys.Add("address_id", _addressId);
            bodys.Add("group_config_id", "");
            bodys.Add("products", $"[{JsonConvert.SerializeObject(products)}]");
            bodys.Add("isBridge", "false");

            var result = RequestPost(url, GetCommonParams(bodys));
            var obj = JObject.Parse(result);

            var times = new List<(bool closed, long? start_timestamp, long? end_timestamp, string? arrival_time_msg)>();
            foreach (var item in obj["data"][0]["time"])
            {
                if (item["times"][0]["disableType"].ToString() != "0")
                {
                    continue;
                }
                times.Add((false
                    , Convert.ToInt64(item["times"][0]["start_timestamp"].ToString())
                    , Convert.ToInt64(item["times"][0]["end_timestamp"].ToString())
                    , item["times"][0]["arrival_time_msg"].ToString()));
            }

            return times;
        }

        /// <summary>
        /// 获取购物车可购商品
        /// </summary>
        /// <returns></returns>
        public CartData? GetCartInfo()
        {
            var url = "https://maicai.api.ddxq.mobi/cart/index";
            var bodys = new Dictionary<string, string>();

            bodys.Add("is_load", "1");

            var result = RequestGet(url, GetCommonParams(bodys));
            return JsonConvert.DeserializeObject<DingDongCartOriginInfo>(result)
                                ?.data;
        }

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cartId"></param>
        /// <param name="isCheck"></param>
        public New_Order_Product_List? UpdateCheckCart(string id, string cartId, bool isCheck)
        {
            var url = "https://maicai.api.ddxq.mobi/cart/updateCheck";
            var bodys = new Dictionary<string, string>();
            bodys.Add("product", JsonConvert.SerializeObject(new
            {
                id = id,
                is_check = isCheck,
                cart_id = cartId,
                sizes = new List<string>(),
            }));
            bodys.Add("is_load", "1");
            var result = RequestGet(url, GetCommonParams(bodys));
            return JsonConvert.DeserializeObject<DingDongCartOriginInfo>(result)
                                ?.data
                                ?.new_order_product_list[0];
        }

        /// <summary>
        /// 校验默认地址
        /// </summary>
        /// <exception cref="DingDongException"></exception>
        private void CheckDefaultAddress()
        {
            if (!string.IsNullOrWhiteSpace(_addressId))
            {
                return;
            }
            var defaultAddress = GetDefaultAdress();
            if (defaultAddress == null)
            {
                throw new DingDongException("没有默认地址", DingDongStatus.NO_DEFAULT_ADDRESS);
            }
            else
            {
                _addressId = defaultAddress.id;
            }
        }

        /// <summary>
        /// 获取默认地址
        /// </summary>
        /// <returns></returns>
        public Valid_Address? GetDefaultAdress()
        {
            var baseUri = "http://sunquan.api.ddxq.mobi/api/v1/user/address/";
            var paramInfo = new Dictionary<string, string>();
            paramInfo.Add("is_load", "1");
            paramInfo.Add("ab_config", AB_CONFIG);
            var result = RequestGet(baseUri, paramInfo);
            var addressInfo = JsonConvert.DeserializeObject<DingDongAddressInfoRoot>(result);
            if (addressInfo == null)
            {
                return null;
            }
            var defaultAddress = addressInfo.data.valid_address.FirstOrDefault(d => d.is_default);
            if (defaultAddress != null)
            {
                _addressId = defaultAddress.id;
            }
            return defaultAddress;
        }

        /// <summary>
        /// get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string RequestGet(string url, Dictionary<string, string?> paramBodys)
        {
            foreach (var item in paramBodys?? new Dictionary<string, string?>())
            {
                url = new Uri(url).Append(item.Key, item.Value).ToString();
            }
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            InitRequest(client, request);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (_track)
            {
                _log?.Invoke($"{url}\r\n{response.Content}");
            }
            CheckResultSuccess(response.Content);
            return response.Content;
        }

        /// <summary>
        /// post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bodys"></param>
        /// <returns></returns>
        private string RequestPost(string url, Dictionary<string, string> bodys)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            InitRequest(client, request);

            foreach (var item in bodys ?? new Dictionary<string, string>())
            {
                request.AddParameter(item.Key, item.Value);
            }
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (_track)
            {
                _log?.Invoke($"{url}\r\n{response.Content}");
            }
            CheckResultSuccess(response.Content);
            return response.Content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        private void InitRequest(RestClient client, RestRequest request)
        {
#if DEBUG
            client.Proxy = new System.Net.WebProxy("127.0.0.1", 8888);
#endif
            request.AddHeader("accept-encoding", "utf-8");
            client.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/8.0.20(0x18001429) NetType/WIFI Language/zh_CN";
            request.AddHeader("referer", "https://servicewechat.com/wx1e113254eda17715/422/page-frame.html");
            request.AddHeader("cookie", $"DDXQSESSID={_config.S_Id}");
            request.AddHeader("ddmc-api-version", _config.Api_Version);
            request.AddHeader("ddmc-build-version", _config.App_Version);
            request.AddHeader("ddmc-app-client-id", "4");
            request.AddHeader("ddmc-channel", "applet");
            request.AddHeader("ddmc-os-version", "[object Undefined]");
            request.AddHeader("ddmc-ip", "");
            request.AddHeader("ddmc-city-number", "0101");
            request.AddHeader("ddmc-device-id", "osP8I0ThXYtaNd7PtvgeqAc-ZMXo");
            request.AddHeader("ddmc-station-id", _config.Station_Id);
            request.AddHeader("ddmc-longitude", _config.Longitude);
            request.AddHeader("ddmc-latitude", _config.Latitude);
            request.AddHeader("ddmc-uid", _config.Uid);
            request.AddHeader("ddmc-time", DingDongUtils.NowTimeStamp.ToString());

            //request.AddParameter("api_version", API_VERSION);
            //request.AddParameter("app_version", APP_VERSION);
            //request.AddParameter("app_client_id", "4");
            //request.AddParameter("channel", "applet");
            //request.AddParameter("applet_source", "");
            //request.AddParameter("sharer_uid", "");
            //request.AddParameter("h5_source", "");
            //request.AddParameter("uid", _config.Uid);
            //request.AddParameter("longitude", _config.Longitude);
            //request.AddParameter("latitude", _config.Latitude);
            //request.AddParameter("station_id", _config.Station_Id);
            //request.AddParameter("city_number", _config.City_Number);
            //request.AddParameter("s_id", _config.S_Id);
            //request.AddParameter("openid", _config.OpenId);
            //request.AddParameter("device_token", _config.Device_Token);
            //request.AddParameter("time", DingDongUtils.NowTimeStamp.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bodys"></param>
        /// <returns></returns>
        /// <exception cref="DingDongException"></exception>
        private Dictionary<string, string?> GetCommonParams(Dictionary<string, string> bodys)
        {
            var commonParams = new Dictionary<string, string?>();
            commonParams.Append("uid", _config.Uid)
                        .Append("longitude", _config.Longitude)
                        .Append("latitude", _config.Latitude)
                        .Append("station_id", _config.Station_Id)
                        .Append("city_number", _config.City_Number)
                        .Append("api_version", _config.Api_Version)
                        .Append("app_version", _config.App_Version)
                        .Append("applet_source")
                        .Append("channel", "applet")
                        .Append("app_client_id", "4")
                        .Append("sharer_uid")
                        .Append("s_id", _config.S_Id)
                        .Append("openid", _config.OpenId)
                        .Append("h5_source")
                        .Append("time", DingDongUtils.NowTimeStamp.ToString())
                        .Append("device_token", _config.Device_Token);
            foreach (var item in bodys)
            {
                commonParams.Add(item.Key, HttpUtility.UrlEncode(item.Value));
            }
            var sign = Sign(JsonConvert.SerializeObject(commonParams));
            foreach (var item in bodys)
            {
                commonParams[item.Key] = item.Value;
            }
            commonParams.Add("nars", sign.nars);
            commonParams.Add("sesi", sign.sesi);
            return commonParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <exception cref="DingDongException"></exception>
        private void CheckResultSuccess(string response)
        {
            if (string.IsNullOrEmpty(response))
            {
                throw new DingDongException("请求结果是空", DingDongStatus.UNKNOWN_ERROR);
            }
            var obj = JObject.Parse(response);
            if (obj["code"]?.ToString() == "1111")
            {
                // {"code":1111,"msg":"您的访问已过期,请重新登录","success":false,"timestamp":"2022-04-14 00:20:08"}
                _log?.Invoke(obj["msg"].ToString());
                throw new DingDongException(obj["msg"]?.ToString(), DingDongStatus.NEED_LOGIN);
            }
            if (obj["success"]?.ToString() == "false")
            {
                // {"success":false,"code":1,"msg":"参数错误","data":[],"tradeTag":"success","server_time":1649869118,"is_trade":1}
                // {"success":false,"code": -3001,"msg": "","tips": {"duration": 400,"limitMsg": "前方拥挤，请稍后再试..."},"data": {}}
                _log?.Invoke(obj["msg"].ToString());
                throw new DingDongException(obj["msg"]?.ToString(), DingDongStatus.UNKNOWN_ERROR);
            }
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private (string nars, string sesi) Sign(string body)
        {
            var js = File.ReadAllText("sign.js");
            var result = new Jint.Engine()
                                    .SetValue("consolelog", new Action<object>(ConsoleLog))
                                    .Execute(js)
                                    .Evaluate($"sign('{body}')")
                                    .ToObject()
                                    .ToString();

            // {"nars":"07fe0e555b67da705ea69d18282e74e4","sesi":"eoJCMBR0764ddcd6ff864a2a4e8b508ddc06c42"}
            var obj = JObject.Parse(result);
            return (obj["nars"].ToString(), obj["sesi"].ToString());
        }

        public void ConsoleLog(object msg)
        {
            Console.WriteLine(JsonConvert.SerializeObject(msg));
        }
    }
}
