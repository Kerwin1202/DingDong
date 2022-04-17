namespace DingDong.Monitor.Models
{
    public class DingDongAddressInfoRoot
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public DingDongAddressOriginInfo data { get; set; }
    }

    public class DingDongAddressOriginInfo
    {
        public List<Valid_Address> valid_address { get; set; }
        public List<Valid_Address> invalid_address { get; set; }
        public int max_address_count { get; set; }
        public bool can_add_address { get; set; }
    }

    public class Valid_Address
    {
        public string id { get; set; }
        public int gender { get; set; }
        public string mobile { get; set; }
        public Location location { get; set; }
        public string label { get; set; }
        public string user_name { get; set; }
        public string addr_detail { get; set; }
        public string station_id { get; set; }
        public string station_name { get; set; }
        /// <summary>
        /// 是否默认地址
        /// </summary>
        public bool is_default { get; set; }
        public string city_number { get; set; }
        public int info_status { get; set; }
        public Station_Info station_info { get; set; }
        public string village_id { get; set; }
    }

    public class Location
    {
        public string typecode { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public float[] location { get; set; }
        public string id { get; set; }
    }

    public class Station_Info
    {
        public string id { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string business_time { get; set; }
        public string city_name { get; set; }
        public string city_number { get; set; }
    }

}
