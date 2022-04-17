using DingDong.Core.Models;
using DingDong.Monitor.DingDong;
using DingDong.Monitor.Models;
using Newtonsoft.Json;
using System.Web;

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
        private static bool IsMonitoring = false;
        private static CancellationTokenSource MonitorTokenSource = null;
        private static DateTime? MonitorBeginTime = null;

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            WriteLog("所有配置的更改，只有保存配置之后才会生效。。。");
            if (File.Exists("config.json"))
            {
                DdConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            }
            if (DdConfig == null || DdConfig.DdConfig == null)
            {
                new LoginFrm(SaveConfig).ShowDialog();
            }
            if (DdConfig != null && DdConfig.SoftConfig != null)
            {
                RefreshUiConfig();
            }

            if (DdConfig != null && DdConfig.DdConfig != null)
            {
                DdCore = new DingDongCore(DdConfig.DdConfig, WriteLog);
                if (DdConfig.SoftConfig != null)
                {
                    DdCore._track = DdConfig.SoftConfig.TrackLog;
                }
                RefreshCategories();
            }
        }

        private void RefreshUiConfig()
        {
            txtExclude.Text = String.Join(",", DdConfig.SoftConfig.ExcludeKeywords?? new List<string>());
            dtpBeginTime.Text= DdConfig.SoftConfig.TimeBegin;
            cbTimeStart.Checked= DdConfig.SoftConfig.IsTimeBegin;
            cbContinue.Checked = DdConfig.SoftConfig.MonitorContinue;
            nudContinue.Value= DdConfig.SoftConfig.MonitorContinueMins;
            nudInterval.Value= DdConfig.SoftConfig.MonitorInterval;
            txtPushUrl.Text = String.Join("\r\n", DdConfig.SoftConfig.PushUrls ?? new List<string>());
            cbPlayMusic.Checked= DdConfig.SoftConfig.PlayMusic;
            cbCartMonitor.Checked= DdConfig.SoftConfig.MonitorCart;
            cbCategoryMonitor.Checked= DdConfig.SoftConfig.MonitorCategory;
            cbTrackLog.Checked = DdConfig.SoftConfig.TrackLog;
        }

        private void SaveConfig(DingDongConfig config)
        {
            if (DdConfig == null)
            {
                DdConfig = new Config();
            }
            DdConfig.DdConfig = config;
            WriteConfig();
        }

        private static void WriteConfig()
        {
            File.WriteAllText("config.json", JsonConvert.SerializeObject(DdConfig));
        }

        private void RefreshCategories()
        {
            if (DdConfig.Categories == null)
            {
                if (DdCore == null)
                {
                    return;
                }
                try
                {
                    DdConfig.Categories = DdCore.GetAllCategories()
                                         .OrderByDescending(d => d.Monitor)
                                         .ToList();
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message);
                }
            }
            dgvCart.Rows.Clear();
            dgvCategory.DataSource = DdConfig.Categories;
            WriteLog("刷新分类成功..");
        }

        private CartData? RefreshCart()
        {
            if (DdCore == null)
            {
                return null;
            }
            try
            {
                var cart = DdCore.GetCartInfo();
                RefreshCartUi(cart);
                return cart;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
            return null;
        }

        private void RefreshCartUi(CartData? cart)
        {
            Invoke(() =>
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
            });
        }

        private void btnRefreshCart_Click(object sender, EventArgs e)
        {
            RefreshCart();
        }

        private void btnExportCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未实现...");
        }

        private void btnImportCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未实现...");
        }

        private void WriteLog(string message)
        {
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText($"{DateTime.Now.ToString("MM-dd HH:mm:ss")} \t {message}\r\n");
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
                        try
                        {
                            var cart = DdCore.UpdateCheckCart(thisProduct.id
                                                 , thisProduct.cart_id
                                                 , isCheck);
                        }
                        catch (Exception ex)
                        {
                            WriteLog(ex.Message);
                        }
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
            var cart = dgvCart.Tag as CartData;
            MakeOrder(cart);
        }

        private bool MakeOrder(CartData? cart)
        {
            try
            {
                if (cart == null || cart.new_order_product_list.FirstOrDefault() == null)
                {
                    WriteLog("洗车单为空，无法下单.");
                    return false;
                }
                var reserveTimes = DdCore.GetMultiReserveTime(cart.new_order_product_list.FirstOrDefault().products);
                if (reserveTimes.Count <= 0)
                {
                    WriteLog("暂无运力...");
                    return false;
                }
                if (reserveTimes.FirstOrDefault(d => d.closed).closed)
                {
                    WriteLog("今天关门了...");
                    return false;
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
                this.NotifyIcon_ShowBalloonTip(30_000, "叮咚助手", "下单成功，快去付款", ToolTipIcon.Info);
                if (DdConfig.SoftConfig.PlayMusic)
                {
                    PlayMusic();
                }
                for (int i = 0; i < 3; i++)
                {
                    foreach (var pushUrl in DdConfig.SoftConfig.PushUrls ?? new List<string>())
                    {
                        DingDongUtils.Push(pushUrl, "下单成功，快去付款");
                    }
                    Thread.Sleep(1000);
                }
                return true;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
        }

        private static void PlayMusic()
        {
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer())
            {
                player.SoundLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Music", "order.wav");
                player.Play();
            }
        }

        private void cbTrackLog_CheckedChanged(object sender, EventArgs e)
        {
            if (DdCore != null)
            {
                DdCore._track = cbTrackLog.Checked;
            }
        }

        private void btnSaveAllConfig_Click(object sender, EventArgs e)
        {
            if (DdConfig.SoftConfig == null)
            {
                DdConfig.SoftConfig = new SoftConfig();
            }
            DdConfig.SoftConfig.ExcludeKeywords = (txtExclude.Text  ?? string.Empty).Split(',').ToList();
            DdConfig.SoftConfig.TimeBegin = dtpBeginTime.Text;
            DdConfig.SoftConfig.IsTimeBegin = cbTimeStart.Checked;
            DdConfig.SoftConfig.MonitorContinue = cbContinue.Checked;
            DdConfig.SoftConfig.MonitorContinueMins = (int)nudContinue.Value;
            DdConfig.SoftConfig.MonitorInterval = (int)nudInterval.Value;
            DdConfig.SoftConfig.PushUrls = (txtPushUrl.Text ?? String.Empty).Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();
            DdConfig.SoftConfig.PlayMusic = cbPlayMusic.Checked;
            DdConfig.SoftConfig.MonitorCart = cbCartMonitor.Checked;
            DdConfig.SoftConfig.MonitorCategory = cbCategoryMonitor.Checked;
            DdConfig.SoftConfig.TrackLog = cbTrackLog.Checked;
            WriteConfig();
            RefreshUiConfig();
            WriteLog("配置保存成功...");
        }

        private void btnTestPush_Click(object sender, EventArgs e)
        {
            PlayMusic();
            this.NotifyIcon_ShowBalloonTip(3000, "叮咚助手", "测试提醒", ToolTipIcon.Info);
            var url = txtPushUrl.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("推送地址必填，请先去 IOS 商店下载 Bark APP");
                return;
            }
            DingDongUtils.Push(url, "测试推送");
        }

        private void cbCategoryMonitor_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("未实现...");
            //return;
            txtExclude.Enabled = dgvCategory.Enabled = cbCategoryMonitor.Checked;
        }

        private void cbTimeStart_CheckedChanged(object sender, EventArgs e)
        {
            dtpBeginTime.Enabled = cbTimeStart.Checked;
        }

        private void cbContinue_CheckedChanged(object sender, EventArgs e)
        {
            nudContinue.Enabled = cbContinue.Checked;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            if (IsMonitoring)
            {
                IsMonitoring = false;
                btnStartMonitor.Text = "开始监控";
                WriteLog("停止监控");
                MonitorTokenSource.Cancel();
                MonitorTokenSource.Dispose();
            }
            else
            {
                IsMonitoring = true;
                btnStartMonitor.Text = "停止监控";
                WriteLog("开始监控");
                MonitorTokenSource = new CancellationTokenSource();
                CancellationToken ct = MonitorTokenSource.Token;
                Task.Run(() =>
                {
                    ct.ThrowIfCancellationRequested();
                    while (true)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            // Clean up here, then...
                            ct.ThrowIfCancellationRequested();
                        }
                        if (!DdConfig.SoftConfig.IsTimeBegin)
                        {
                            break;
                        }
                        if (DateTime.TryParse($"{DateTime.Now.ToString("yyyy-MM-dd")} {DdConfig.SoftConfig.TimeBegin}"
                            , out var beginTime))
                        {
                            if (beginTime > DateTime.Now   // 设置的时间比现在晚
                                || DdConfig.SoftConfig.MonitorContinue
                                   && DdConfig.SoftConfig.MonitorContinueMins > 0
                                   && DateTime.Now > beginTime.AddMinutes(DdConfig.SoftConfig.MonitorContinueMins))   // 设置的时间比现在早，但是超过了持续时间
                            {
                                //
                            }
                            else
                            {
                                break;
                            }
                            // 要执行
                        }
                        else
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }

                    MonitorBeginTime = DateTime.Now;
                    while (IsMonitoring)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            // Clean up here, then...
                            ct.ThrowIfCancellationRequested();
                        }
                        if (DdConfig.SoftConfig.MonitorContinue
                           && DdConfig.SoftConfig.MonitorContinueMins > 0
                           && MonitorBeginTime.Value.AddMinutes(DdConfig.SoftConfig.MonitorContinueMins) < DateTime.Now)
                        {
                            WriteLog($"持续监控 {DdConfig.SoftConfig.MonitorContinueMins} 分钟后自动终止...");
                            IsMonitoring = false;
                            Invoke(new Action(() =>
                            {
                                btnStartMonitor.Text = "开始监控";
                            }));
                            MonitorTokenSource.Cancel();
                        }
                        else
                        {
                            if (DdConfig.SoftConfig.MonitorCart)
                            {
                                var cart = RefreshCart();
                                if (MakeOrder(cart))
                                {
                                    WriteLog($"已经提交订单，自动终止...");
                                    IsMonitoring = false;
                                    Invoke(new Action(() =>
                                    {
                                        btnStartMonitor.Text = "开始监控";
                                    }));
                                    MonitorTokenSource.Cancel();
                                }
                            }
                            if (DdConfig.SoftConfig.MonitorCategory)
                            {
                            }
                        }
                        Thread.Sleep(DdConfig.SoftConfig.MonitorInterval);
                    }
                }, MonitorTokenSource.Token);
            }
        }


        public void NotifyIcon_ShowBalloonTip(int tipDisplayTime, String tipTitle, String tipText, ToolTipIcon tipIcon)
        {
            Invoke(new Action(() =>
            {
                this.niDingDong.ShowBalloonTip(tipDisplayTime, tipTitle, tipText, tipIcon);
            }));
        }
    }
}
