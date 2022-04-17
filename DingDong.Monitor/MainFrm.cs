using DingDong.Core.Models;
using DingDong.Monitor.DingDong;
using DingDong.Monitor.Models;
using Newtonsoft.Json;

namespace DingDong.Monitor
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private static Config DdConfig = null;
        private static DingDongCore DdCore = null;
        private static List<DingDongCategoryInfo> Categories = null;

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            if (File.Exists("config.json"))
            {
                DdConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            }
            if (DdConfig == null || DdConfig.DdConfig == null)
            {
                new LoginFrm(SaveConfig).ShowDialog();
            }
            if (DdConfig != null && DdConfig.DdConfig != null)
            {
                DdCore = new DingDongCore(DdConfig.DdConfig, WriteLog);
                RefreshCategories();
            }
        }

        private void SaveConfig(DingDongConfig config)
        {
            if (DdConfig == null)
            {
                DdConfig = new Config();
            }
            DdConfig.DdConfig = config;
            File.WriteAllText("config.json", JsonConvert.SerializeObject(DdConfig));
        }

        private void RefreshCategories()
        {
            if (DdCore == null)
            {
                return;
            }
            dgvCart.Rows.Clear();
            Categories = DdCore.GetAllCategories()
                                .OrderByDescending(d => d.Monitor)
                                .ToList();
            dgvCategory.DataSource = Categories;
            WriteLog("刷新分类成功..");
        }

        private void RefreshCart()
        {
            if (DdCore == null)
            {
                return;
            }
            var cart = DdCore.GetCartInfo();
            RefreshCartUi(cart);
        }

        private void RefreshCartUi(CartData? cart)
        {
            if (cart != null
                && cart.new_order_product_list != null
                && cart.new_order_product_list.Count > 0
                && cart.new_order_product_list.FirstOrDefault()?.products != null
                && cart.new_order_product_list.FirstOrDefault()?.products.Count > 0)
            {
                dgvCart.Rows.Clear();
                foreach (var item in cart.new_order_product_list?.FirstOrDefault()?.products ?? new List<Product3>())
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.product_name });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.count });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.origin_price });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.total_origin_price });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = true });
                    row.Tag = item;
                    dgvCart.Rows.Add(row);
                }
                dgvCart.Tag = cart;
                label1.Text = $"总金额：{cart.new_order_product_list.FirstOrDefault().total_origin_money}";
                WriteLog($"刷新购物车成功.已勾选:{cart.new_order_product_list.FirstOrDefault().products.Count} 件商品 {label1.Text}.");
            }
            else
            {
                WriteLog("刷新购物车失败..");
            }
        }

        private void btnRefreshCart_Click(object sender, EventArgs e)
        {
            RefreshCart();
        }

        private void btnExportCart_Click(object sender, EventArgs e)
        {

        }

        private void btnImportCart_Click(object sender, EventArgs e)
        {

        }

        private void WriteLog(string message)
        {
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText($"{DateTime.Now.ToString("MM-dd HH:mm:ss")} {message}\r\n");
                //让文本框获取焦点 
                this.richTextBox1.Focus();
                //设置光标的位置到文本尾 
                this.richTextBox1.Select(this.richTextBox1.TextLength - 1, 0);
                //滚动到控件光标处 
                this.richTextBox1.ScrollToCaret();
            }));
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != -1 && !dgvCart.Rows[e.RowIndex].IsNewRow)
            {
                if (e.ColumnIndex == 1)
                {
                    if ((bool)this.dgvCart[e.ColumnIndex, e.RowIndex].Value == true)
                    {
                        this.dgvCart[1, e.RowIndex].Value = 100;
                    }
                    else
                    {
                        this.dgvCart[1, e.RowIndex].Value = 10;
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    var thisProduct = dgvCart.Rows[e.RowIndex].Tag as Product3;
                    if (thisProduct != null)
                    {
                        var isCheck = (bool)this.dgvCart[e.ColumnIndex, e.RowIndex].Value == true;
                        var cart = DdCore.UpdateCheckCart(thisProduct.id
                             , thisProduct.cart_id
                             , isCheck);
                        WriteLog($"{(isCheck ? "加入" : "取消")} 【{thisProduct.product_name}】 到购物车成功.");
                        RefreshCart();
                    }
                }
            }
        }

        private void dgvCart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCart.IsCurrentCellDirty)
            {
                dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            var cart = dgvCart.Tag  as CartData;
            if (cart == null)
            {
                return;
            }
            var reserveTimes = DdCore.GetMultiReserveTime(cart.new_order_product_list.FirstOrDefault().products);
            if (reserveTimes.Count <= 0)
            {
                WriteLog("暂无运力...");
                return;
            }
            if (reserveTimes.FirstOrDefault(d => d.closed).closed)
            {
                WriteLog("今天关门了...");
                return;
            }
            WriteLog($"有运力：{reserveTimes.FirstOrDefault().arrival_time_msg} ...");

            var orderCart = JsonConvert.DeserializeObject<New_Order_Product_List2>(JsonConvert.SerializeObject(cart.new_order_product_list[0]));
            orderCart.reserved_time = new reserved_time()
            {
                reserved_time_end = reserveTimes.FirstOrDefault().end_timestamp.Value,
                reserved_time_start = reserveTimes.FirstOrDefault().start_timestamp.Value,
            };
            foreach (var item in orderCart.products)
            {
                item.total_money = item.total_origin_money = item.price;
            }
            DdCore.CheckOrder(orderCart);

            DdCore.CreateNewOrder(cart, (reserveTimes.FirstOrDefault().start_timestamp.Value, reserveTimes.FirstOrDefault().end_timestamp.Value));
            WriteLog("下单成功，快去付款。。");
        }

        private void cbTrackLog_CheckedChanged(object sender, EventArgs e)
        {
            DdCore._track = cbTrackLog.Checked;
        }

        private void btnSaveAllConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
