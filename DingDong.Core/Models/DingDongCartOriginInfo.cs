using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingDong.Core.Models
{
    public class DingDongCartOriginInfo
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public CartData data { get; set; }
        public string tradeTag { get; set; }
        public int server_time { get; set; }
        public int is_trade { get; set; }
    }

    public class CartData
    {
        public Product product { get; set; }
        public string toast { get; set; }
        public object alert { get; set; }
        public object[] all_activity_cart { get; set; }
        public string station_id { get; set; }
        public object[] order_product_list { get; set; }
        /// <summary>
        /// 这是已经勾选的
        /// </summary>
        public List<New_Order_Product_List> new_order_product_list { get; set; }
        public string order_product_list_sign { get; set; }
        public string full_to_off { get; set; }
        public string freight_money { get; set; }
        public int free_freight_type { get; set; }
        public string instant_rebate_money { get; set; }
        public string goods_real_money { get; set; }
        public string total_money { get; set; }
        public int is_select_detail { get; set; }
        public string good_max_count_toast { get; set; }
        public int is_all_check { get; set; }
        public string onion_id { get; set; }
        public Onion_Tip onion_tip { get; set; }
        public string cart_notice { get; set; }
        public string cart_notice_new { get; set; }
        public Free_Freight_Notice free_freight_notice { get; set; }
        public object[] cart_top_floor_info { get; set; }
        public int cart_count { get; set; }
        public int total_count { get; set; }
        public Dictionary<string, int> product_num { get; set; }
        public string stop_order_toast { get; set; }
        public string gift_no_size_tip { get; set; }
        public bool is_hit_onion { get; set; }
        public int onion_ab_config { get; set; }
        public bool is_hit_gift_size { get; set; }
        public string coupon_text_a { get; set; }
        public string coupon_text_b { get; set; }
        public string need_amount { get; set; }
        public int is_vip_ticket { get; set; }
        public string coupon_amount { get; set; }
        public int coupon_state { get; set; }
        public int coupon_type { get; set; }
        public Next_Recommend_Coupon next_recommend_coupon { get; set; }
        public bool show_coupon_detail { get; set; }
        public int contains_advent_gift { get; set; }
        public Parent_Order_Info parent_order_info { get; set; }
        public int is_support_merge_payment { get; set; }
        public object[] sodexo_nonsupport_product_list { get; set; }
        public Valid_Product_Counts valid_product_counts { get; set; }
        public string cart_encry_Info { get; set; }
        public int flash_sale_check { get; set; }
    }

    public class Product
    {
        public List<Effective> effective { get; set; }
        public List<Invalid> invalid { get; set; }
    }

    public class Effective
    {
        public Activity_Info activity_info { get; set; }
        public Product1[] products { get; set; }
    }

    public class Activity_Info
    {
        public string id { get; set; }
        public object gifts { get; set; }
    }

    public class Product1
    {
        public string id { get; set; }
        public int type { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public object[] sizes { get; set; }
        public int count { get; set; }
        public int status { get; set; }
        public object[] gifts { get; set; }
        public int addTime { get; set; }
        public string cart_id { get; set; }
        public string activity_id { get; set; }
        public string sku_activity_id { get; set; }
        public string conditions_num { get; set; }
        public string activity_tag { get; set; }
        public string category_path { get; set; }
        public string manage_category_path { get; set; }
        public string total_price { get; set; }
        public string origin_price { get; set; }
        public string no_supplementary_price { get; set; }
        public string no_supplementary_total_price { get; set; }
        public string size_price { get; set; }
        public string add_price { get; set; }
        public string add_vip_price { get; set; }
        public int price_type { get; set; }
        public int buy_limit { get; set; }
        public int promotion_num { get; set; }
        public string product_name { get; set; }
        public int product_type { get; set; }
        public string small_image { get; set; }
        public object[] all_sizes { get; set; }
        public bool only_new_user { get; set; }
        public int is_check { get; set; }
        public int is_gift { get; set; }
        public int is_bulk { get; set; }
        public string view_total_weight { get; set; }
        public string net_weight { get; set; }
        public string net_weight_unit { get; set; }
        public bool is_stock { get; set; }
        public int old_count { get; set; }
        public int stock_number { get; set; }
        public object[] not_meet { get; set; }
        public int is_presale { get; set; }
        public string presale_id { get; set; }
        public int presale_type { get; set; }
        public int delivery_start_time { get; set; }
        public int delivery_end_time { get; set; }
        public int is_invoice { get; set; }
        public int is_onion { get; set; }
        public object[] sub_list { get; set; }
        public int is_booking { get; set; }
        public string today_stockout { get; set; }
        public int storage_value_id { get; set; }
        public string temperature_layer { get; set; }
        public int is_shared_station_product { get; set; }
        public int is_fresh_food { get; set; }
        public object[] accessory_gifts { get; set; }
        public string accessory_text { get; set; }
        public object[] supplementary_list { get; set; }
    }

    public class Invalid
    {
        public Product2[] products { get; set; }
    }

    public class Product2
    {
        public string id { get; set; }
        public int type { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public object[] sizes { get; set; }
        public int count { get; set; }
        public int status { get; set; }
        public object[] gifts { get; set; }
        public int addTime { get; set; }
        public string cart_id { get; set; }
        public string activity_id { get; set; }
        public string sku_activity_id { get; set; }
        public string conditions_num { get; set; }
        public string activity_tag { get; set; }
        public string category_path { get; set; }
        public string manage_category_path { get; set; }
        public string origin_price { get; set; }
        public string size_price { get; set; }
        public string add_price { get; set; }
        public string add_vip_price { get; set; }
        public int price_type { get; set; }
        public int buy_limit { get; set; }
        public int promotion_num { get; set; }
        public string product_name { get; set; }
        public int product_type { get; set; }
        public string small_image { get; set; }
        public bool only_new_user { get; set; }
        public int is_check { get; set; }
        public int is_gift { get; set; }
        public int is_bulk { get; set; }
        public string view_total_weight { get; set; }
        public string net_weight { get; set; }
        public string net_weight_unit { get; set; }
        public bool is_stock { get; set; }
        public int old_count { get; set; }
        public int stock_number { get; set; }
        public object[] not_meet { get; set; }
        public int is_presale { get; set; }
        public string presale_id { get; set; }
        public int presale_type { get; set; }
        public int delivery_start_time { get; set; }
        public int delivery_end_time { get; set; }
        public int is_invoice { get; set; }
        public int is_onion { get; set; }
        public object[] sub_list { get; set; }
        public int is_booking { get; set; }
        public string today_stockout { get; set; }
        public string promotion_info { get; set; }
        public int storage_value_id { get; set; }
        public string temperature_layer { get; set; }
        public int is_fresh_food { get; set; }
    }

    public class Onion_Tip
    {
    }

    public class Free_Freight_Notice
    {
    }

    public class Next_Recommend_Coupon
    {
        public object coupon_text_a { get; set; }
        public object coupon_text_b { get; set; }
        public object need_amount { get; set; }
        public object is_vip_ticket { get; set; }
        public object is_common_ticket { get; set; }
    }

    public class Parent_Order_Info
    {
        public string parent_order_sign { get; set; }
        public string total_rebate_money { get; set; }
        public string total_origin_money { get; set; }
        public object[] stockout_gift_product { get; set; }
        public string stockout_gift_text { get; set; }
        public bool is_open_presale_use_virtual_stock { get; set; }
    }

    public class Valid_Product_Counts
    {
        public int _61f4f2c9d66708a57189b04e { get; set; }
        public int _612cc0982c34fab505117d4e { get; set; }
        public int _612cc085095fb38bb1a61a0a { get; set; }
        public int _5dd645147cdbf01317694059 { get; set; }
        public int _612cc09e5e5c08be1d9f0236 { get; set; }
    }

    public class New_Order_Product_List
    {
        public List<Product3> products { get; set; }
        public string total_money { get; set; }
        public string total_origin_money { get; set; }
        public string goods_real_money { get; set; }
        public int total_count { get; set; }
        public int cart_count { get; set; }
        public int is_presale { get; set; }
        public string instant_rebate_money { get; set; }
        public string total_rebate_money { get; set; }
        public string used_balance_money { get; set; }
        public string can_used_balance_money { get; set; }
        public int used_point_num { get; set; }
        public string used_point_money { get; set; }
        public int can_used_point_num { get; set; }
        public string can_used_point_money { get; set; }
        public int is_share_station { get; set; }
        public object[] only_today_products { get; set; }
        public object[] only_tomorrow_products { get; set; }
        public int package_type { get; set; }
        public int package_id { get; set; }
        public string front_package_text { get; set; }
        public int front_package_type { get; set; }
        public string front_package_stock_color { get; set; }
        public string front_package_bg_color { get; set; }
    }


    public class New_Order_Product_List2
    {
        public List<Product3Base> products { get; set; }
        public string total_money { get; set; }
        public string total_origin_money { get; set; }
        public string goods_real_money { get; set; }
        public int total_count { get; set; }
        public int cart_count { get; set; }
        public int is_presale { get; set; }
        public string instant_rebate_money { get; set; }
        public string total_rebate_money { get; set; }
        public string used_balance_money { get; set; }
        public string can_used_balance_money { get; set; }
        public int used_point_num { get; set; }
        public string used_point_money { get; set; }
        public int can_used_point_num { get; set; }
        public string can_used_point_money { get; set; }
        public int is_share_station { get; set; }
        public object[] only_today_products { get; set; }
        public object[] only_tomorrow_products { get; set; }
        public int package_type { get; set; }
        public int package_id { get; set; }
        public string front_package_text { get; set; }
        public int front_package_type { get; set; }
        public string front_package_stock_color { get; set; }
        public string front_package_bg_color { get; set; }

        public reserved_time reserved_time { get; set; } = new reserved_time();
    }

    public class reserved_time
    {
        public long? reserved_time_start { get; set; }

        public long? reserved_time_end { get; set; }
    }


    public class Product3 : Product3Base
    {
        public string description { get; set; }
        public string cart_id { get; set; }
        public string parent_id { get; set; }
        public int parent_batch_type { get; set; }
        public string manage_category_path { get; set; }
        public string sku_activity_id { get; set; }
        public string product_name { get; set; }
        public string small_image { get; set; }
        public string total_price { get; set; }
        public string total_origin_price { get; set; }
        public string no_supplementary_price { get; set; }
        public string no_supplementary_total_price { get; set; }
        public string size_price { get; set; }
        public int buy_limit { get; set; }
        public int promotion_num { get; set; }
        public int is_invoice { get; set; }
        public int is_booking { get; set; }
        public int is_bulk { get; set; }
        public string view_total_weight { get; set; }
        public string net_weight { get; set; }
        public string net_weight_unit { get; set; }
        public int storage_value_id { get; set; }
        public string temperature_layer { get; set; }
        public Sale_Batches sale_batches { get; set; }
        public int is_shared_station_product { get; set; }
        public int is_gift { get; set; }
        public object[] supplementary_list { get; set; }
        public int is_presale { get; set; }
    }

    public class Sale_Batches
    {
        public int batch_type { get; set; }
    }




    public class Product3Base
    {
        public string id { get; set; }
        public string category_path { get; set; }
        public int count { get; set; }
        public string price { get; set; }
        public string total_money { get; set; }
        public string instant_rebate_money { get; set; }
        public string activity_id { get; set; }
        public string conditions_num { get; set; }
        public int product_type { get; set; }
        public object[] sizes { get; set; }
        public int type { get; set; }
        public string total_origin_money { get; set; }
        public int price_type { get; set; }
        public int batch_type { get; set; }
        public object[] sub_list { get; set; }
        public int order_sort { get; set; }
        public string origin_price { get; set; }
    }

    public class PaymentOrderInfo
    {
        public PaymentOrder payment_order { get; set; }

        public List<Package> packages { get; set; }
    }

    public class PaymentOrder
    {
        public int reserved_time_start { get; set; }
        public int reserved_time_end { get; set; }
        public string price { get; set; }
        public string freight_discount_money { get; set; }
        public string freight_money { get; set; }
        public string order_freight { get; set; }
        public string parent_order_sign { get; set; }
        public int product_type { get; set; }
        public string address_id { get; set; }
        public string form_id { get; set; }
        public object receipt_without_sku { get; set; }
        public int pay_type { get; set; }
        public string vip_money { get; set; }
        public string vip_buy_user_ticket_id { get; set; }
        public string coupons_money { get; set; }
        public string coupons_id { get; set; }
    }

    public class Package
    {
        public CreateOrderProduct[] products { get; set; }
        public string total_money { get; set; }
        public string total_origin_money { get; set; }
        public string goods_real_money { get; set; }
        public int total_count { get; set; }
        public int cart_count { get; set; }
        public int is_presale { get; set; }
        public string instant_rebate_money { get; set; }
        public string total_rebate_money { get; set; }
        public string used_balance_money { get; set; }
        public string can_used_balance_money { get; set; }
        public int used_point_num { get; set; }
        public string used_point_money { get; set; }
        public int can_used_point_num { get; set; }
        public string can_used_point_money { get; set; }
        public int is_share_station { get; set; }
        public object[] only_today_products { get; set; }
        public object[] only_tomorrow_products { get; set; }
        public int package_type { get; set; }
        public int package_id { get; set; }
        public string front_package_text { get; set; }
        public int front_package_type { get; set; }
        public string front_package_stock_color { get; set; }
        public string front_package_bg_color { get; set; }
        public string eta_trace_id { get; set; }
        public int reserved_time_start { get; set; }
        public int reserved_time_end { get; set; }
        public string soon_arrival { get; set; }
        public int first_selected_big_time { get; set; }
    }




    public class CreateOrderProduct
    {
        public CreateOrderProduct()
        {

        }

        public CreateOrderProduct(Product3 product)
        {
            id = product.id;
            parent_id = product.parent_id;
            cart_id = product.cart_id;
            product_name = product.product_name;
            is_booking = product.is_booking;
            small_image = product.small_image;
            sale_batches = product.sale_batches;
            count = product.count;
            price = product.price;
            product_type = product.product_type;
            sizes = product.sizes;
            order_sort = product.order_sort;
        }
        public string id { get; set; }
        public string parent_id { get; set; }
        public int count { get; set; }
        public string cart_id { get; set; }
        public string price { get; set; }
        public int product_type { get; set; }
        public int is_booking { get; set; }
        public string product_name { get; set; }
        public string small_image { get; set; }
        public Sale_Batches sale_batches { get; set; }
        public int order_sort { get; set; }
        public object[] sizes { get; set; }
    }

}



