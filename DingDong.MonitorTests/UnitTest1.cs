using DingDong.Monitor.DingDong;
using DingDong.Monitor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DingDong.MonitorTests
{
    [TestClass]
    public class UnitTest1
    {
        private static DingDongCore _DingDongCore;

        static UnitTest1()
        {
            var url = "https://maicai.api.ddxq.mobi/cart/index?uid=6252dc5fe858c70001e6fdbd&longitude=121.583564&latitude=31.089303&station_id=5c8879d1716de1f6468b456d&city_number=0101&api_version=9.50.0&app_version=2.83.0&applet_source=&channel=applet&app_client_id=4&sharer_uid=&s_id=2837e1d9d00458c8c5f55746df7695b8&openid=osP8I0ThXYtaNd7PtvgeqAc-ZMXo&h5_source=&time=1650103979&device_token=WHJMrwNw1k%2FFKPjcOOgRd%2BFcQ12fJsDdFO4Cj6PkCoDHEw1OK4Rf29NdkTZMY7%2F39PpYIggpYPbnhKJIfzoI1SbBk56c%2FnXhLdCW1tldyDzmauSxIJm5Txg%3D%3D1487582755342&is_load=1&ab_config=%7B%22key_onion%22%3A%22D%22%2C%22key_cart_discount_price%22%3A%22C%22%7D&nars=36028de34f50efb314ca91375bf59588&sesi=mUR84m18d9c9773fe811f4ff6c8aa8117209e5c";

            var config = DingDongUtils.Convert2Config(url);
            _DingDongCore = new DingDongCore(config);
        }

        [TestMethod]
        public void TestGetDefaultAdress()
        {
            var address = _DingDongCore.GetDefaultAdress();
            Assert.IsTrue(address != null);
        }

        [TestMethod]
        public void TestGetMultiReserveTime()
        {
            //var address = _DingDongCore.GetMultiReserveTime();
            //Assert.IsTrue(address != null);
        }

        [TestMethod]
        public void TestGetCartInfo()
        {
            var cart = _DingDongCore.GetCartInfo();
            Assert.IsTrue(cart != null
           && cart.new_order_product_list != null
           && cart.new_order_product_list.Count > 0
           && cart.new_order_product_list.FirstOrDefault()?.products != null
           && cart.new_order_product_list.FirstOrDefault()?.products.Count > 0);
        }
    }
}