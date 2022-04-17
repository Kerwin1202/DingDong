namespace DingDong.Monitor
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudContinue = new System.Windows.Forms.NumericUpDown();
            this.cbContinue = new System.Windows.Forms.CheckBox();
            this.cbCartMonitor = new System.Windows.Forms.CheckBox();
            this.cbCategoryMonitor = new System.Windows.Forms.CheckBox();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.cbTimeStart = new System.Windows.Forms.CheckBox();
            this.txtExclude = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.dgv_Category_Check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Category_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Category_Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnImportCart = new System.Windows.Forms.Button();
            this.btnExportCart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshCart = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.dgv_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvg_TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.cbTrackLog = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSaveAllConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPushUrl = new System.Windows.Forms.TextBox();
            this.btnTestPush = new System.Windows.Forms.Button();
            this.cbPlayMusic = new System.Windows.Forms.CheckBox();
            this.niDingDong = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudContinue);
            this.groupBox1.Controls.Add(this.cbContinue);
            this.groupBox1.Controls.Add(this.cbCartMonitor);
            this.groupBox1.Controls.Add(this.cbCategoryMonitor);
            this.groupBox1.Controls.Add(this.btnStartMonitor);
            this.groupBox1.Controls.Add(this.dtpBeginTime);
            this.groupBox1.Controls.Add(this.cbTimeStart);
            this.groupBox1.Controls.Add(this.txtExclude);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudInterval);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvCategory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 446);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监控模块";
            // 
            // nudContinue
            // 
            this.nudContinue.Enabled = false;
            this.nudContinue.Location = new System.Drawing.Point(121, 387);
            this.nudContinue.Name = "nudContinue";
            this.nudContinue.Size = new System.Drawing.Size(89, 23);
            this.nudContinue.TabIndex = 11;
            // 
            // cbContinue
            // 
            this.cbContinue.AutoSize = true;
            this.cbContinue.Location = new System.Drawing.Point(11, 389);
            this.cbContinue.Name = "cbContinue";
            this.cbContinue.Size = new System.Drawing.Size(107, 21);
            this.cbContinue.TabIndex = 10;
            this.cbContinue.Text = "监控持续(分钟)";
            this.cbContinue.UseVisualStyleBackColor = true;
            this.cbContinue.CheckedChanged += new System.EventHandler(this.cbContinue_CheckedChanged);
            // 
            // cbCartMonitor
            // 
            this.cbCartMonitor.AutoSize = true;
            this.cbCartMonitor.Location = new System.Drawing.Point(280, 343);
            this.cbCartMonitor.Name = "cbCartMonitor";
            this.cbCartMonitor.Size = new System.Drawing.Size(111, 21);
            this.cbCartMonitor.TabIndex = 9;
            this.cbCartMonitor.Text = "购物车运力监控";
            this.cbCartMonitor.UseVisualStyleBackColor = true;
            // 
            // cbCategoryMonitor
            // 
            this.cbCategoryMonitor.AutoSize = true;
            this.cbCategoryMonitor.Location = new System.Drawing.Point(280, 299);
            this.cbCategoryMonitor.Name = "cbCategoryMonitor";
            this.cbCategoryMonitor.Size = new System.Drawing.Size(99, 21);
            this.cbCategoryMonitor.TabIndex = 8;
            this.cbCategoryMonitor.Text = "分类菜系监控";
            this.cbCategoryMonitor.UseVisualStyleBackColor = true;
            this.cbCategoryMonitor.CheckedChanged += new System.EventHandler(this.cbCategoryMonitor_CheckedChanged);
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.Location = new System.Drawing.Point(280, 387);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(127, 37);
            this.btnStartMonitor.TabIndex = 7;
            this.btnStartMonitor.Text = "开始监控";
            this.btnStartMonitor.UseVisualStyleBackColor = true;
            this.btnStartMonitor.Click += new System.EventHandler(this.btnStartMonitor_Click);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Enabled = false;
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBeginTime.Location = new System.Drawing.Point(121, 343);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(89, 23);
            this.dtpBeginTime.TabIndex = 6;
            // 
            // cbTimeStart
            // 
            this.cbTimeStart.AutoSize = true;
            this.cbTimeStart.Location = new System.Drawing.Point(11, 345);
            this.cbTimeStart.Name = "cbTimeStart";
            this.cbTimeStart.Size = new System.Drawing.Size(87, 21);
            this.cbTimeStart.TabIndex = 5;
            this.cbTimeStart.Text = "定时开始：";
            this.cbTimeStart.UseVisualStyleBackColor = true;
            this.cbTimeStart.CheckedChanged += new System.EventHandler(this.cbTimeStart_CheckedChanged);
            // 
            // txtExclude
            // 
            this.txtExclude.Enabled = false;
            this.txtExclude.Location = new System.Drawing.Point(121, 238);
            this.txtExclude.Multiline = true;
            this.txtExclude.Name = "txtExclude";
            this.txtExclude.Size = new System.Drawing.Size(286, 38);
            this.txtExclude.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "排除菜类关键词：\r\n(英文逗号分割)";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(121, 299);
            this.nudInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(89, 23);
            this.nudInterval.TabIndex = 2;
            this.nudInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "监控间隔毫秒：";
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.AllowUserToDeleteRows = false;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Category_Check,
            this.dgv_Category_Name,
            this.dgv_Category_Status});
            this.dgvCategory.Enabled = false;
            this.dgvCategory.Location = new System.Drawing.Point(8, 32);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowTemplate.Height = 25;
            this.dgvCategory.Size = new System.Drawing.Size(399, 193);
            this.dgvCategory.TabIndex = 0;
            // 
            // dgv_Category_Check
            // 
            this.dgv_Category_Check.DataPropertyName = "Id";
            this.dgv_Category_Check.HeaderText = "#";
            this.dgv_Category_Check.Name = "dgv_Category_Check";
            this.dgv_Category_Check.ReadOnly = true;
            this.dgv_Category_Check.Width = 120;
            // 
            // dgv_Category_Name
            // 
            this.dgv_Category_Name.DataPropertyName = "Name";
            this.dgv_Category_Name.HeaderText = "分类名字";
            this.dgv_Category_Name.Name = "dgv_Category_Name";
            this.dgv_Category_Name.ReadOnly = true;
            this.dgv_Category_Name.Width = 150;
            // 
            // dgv_Category_Status
            // 
            this.dgv_Category_Status.DataPropertyName = "Monitor";
            this.dgv_Category_Status.HeaderText = "监控";
            this.dgv_Category_Status.Name = "dgv_Category_Status";
            this.dgv_Category_Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Category_Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv_Category_Status.Width = 66;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreateOrder);
            this.groupBox2.Controls.Add(this.btnImportCart);
            this.groupBox2.Controls.Add(this.btnExportCart);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnRefreshCart);
            this.groupBox2.Controls.Add(this.dgvCart);
            this.groupBox2.Location = new System.Drawing.Point(459, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "购物车模块";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(431, 298);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(127, 37);
            this.btnCreateOrder.TabIndex = 5;
            this.btnCreateOrder.Text = "人工提交订单";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnImportCart
            // 
            this.btnImportCart.Location = new System.Drawing.Point(152, 243);
            this.btnImportCart.Name = "btnImportCart";
            this.btnImportCart.Size = new System.Drawing.Size(127, 37);
            this.btnImportCart.TabIndex = 4;
            this.btnImportCart.Text = "导入购物车";
            this.btnImportCart.UseVisualStyleBackColor = true;
            this.btnImportCart.Click += new System.EventHandler(this.btnImportCart_Click);
            // 
            // btnExportCart
            // 
            this.btnExportCart.Location = new System.Drawing.Point(289, 243);
            this.btnExportCart.Name = "btnExportCart";
            this.btnExportCart.Size = new System.Drawing.Size(127, 37);
            this.btnExportCart.TabIndex = 3;
            this.btnExportCart.Text = "导出购物车";
            this.btnExportCart.UseVisualStyleBackColor = true;
            this.btnExportCart.Click += new System.EventHandler(this.btnExportCart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "总金额：";
            // 
            // btnRefreshCart
            // 
            this.btnRefreshCart.Location = new System.Drawing.Point(431, 243);
            this.btnRefreshCart.Name = "btnRefreshCart";
            this.btnRefreshCart.Size = new System.Drawing.Size(127, 37);
            this.btnRefreshCart.TabIndex = 1;
            this.btnRefreshCart.Text = "人工刷新购物车";
            this.btnRefreshCart.UseVisualStyleBackColor = true;
            this.btnRefreshCart.Click += new System.EventHandler(this.btnRefreshCart_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Name,
            this.dgv_Number,
            this.dgv_Price,
            this.dvg_TotalPrice,
            this.dgv_Status});
            this.dgvCart.Location = new System.Drawing.Point(17, 22);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowTemplate.Height = 25;
            this.dgvCart.Size = new System.Drawing.Size(541, 203);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellValueChanged);
            this.dgvCart.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCart_CurrentCellDirtyStateChanged);
            // 
            // dgv_Name
            // 
            this.dgv_Name.HeaderText = "名称";
            this.dgv_Name.Name = "dgv_Name";
            this.dgv_Name.ReadOnly = true;
            this.dgv_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgv_Name.Width = 150;
            // 
            // dgv_Number
            // 
            this.dgv_Number.HeaderText = "数量";
            this.dgv_Number.Name = "dgv_Number";
            this.dgv_Number.Width = 66;
            // 
            // dgv_Price
            // 
            this.dgv_Price.HeaderText = "单价";
            this.dgv_Price.Name = "dgv_Price";
            this.dgv_Price.ReadOnly = true;
            this.dgv_Price.Width = 88;
            // 
            // dvg_TotalPrice
            // 
            this.dvg_TotalPrice.HeaderText = "总价";
            this.dvg_TotalPrice.Name = "dvg_TotalPrice";
            this.dvg_TotalPrice.ReadOnly = true;
            this.dvg_TotalPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dvg_TotalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dvg_TotalPrice.Width = 88;
            // 
            // dgv_Status
            // 
            this.dgv_Status.HeaderText = "要不要";
            this.dgv_Status.Name = "dgv_Status";
            this.dgv_Status.Width = 88;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearLog);
            this.groupBox3.Controls.Add(this.cbTrackLog);
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 464);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1025, 267);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(830, 231);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 7;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // cbTrackLog
            // 
            this.cbTrackLog.AutoSize = true;
            this.cbTrackLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cbTrackLog.ForeColor = System.Drawing.Color.White;
            this.cbTrackLog.Location = new System.Drawing.Point(920, 231);
            this.cbTrackLog.Name = "cbTrackLog";
            this.cbTrackLog.Size = new System.Drawing.Size(85, 21);
            this.cbTrackLog.TabIndex = 6;
            this.cbTrackLog.Text = "Track Log";
            this.cbTrackLog.UseVisualStyleBackColor = false;
            this.cbTrackLog.CheckedChanged += new System.EventHandler(this.cbTrackLog_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(3, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1019, 245);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // btnSaveAllConfig
            // 
            this.btnSaveAllConfig.Location = new System.Drawing.Point(890, 421);
            this.btnSaveAllConfig.Name = "btnSaveAllConfig";
            this.btnSaveAllConfig.Size = new System.Drawing.Size(127, 37);
            this.btnSaveAllConfig.TabIndex = 3;
            this.btnSaveAllConfig.Text = "保存所有配置";
            this.btnSaveAllConfig.UseVisualStyleBackColor = true;
            this.btnSaveAllConfig.Click += new System.EventHandler(this.btnSaveAllConfig_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bark 推送：";
            // 
            // txtPushUrl
            // 
            this.txtPushUrl.Location = new System.Drawing.Point(557, 373);
            this.txtPushUrl.Multiline = true;
            this.txtPushUrl.Name = "txtPushUrl";
            this.txtPushUrl.Size = new System.Drawing.Size(308, 49);
            this.txtPushUrl.TabIndex = 5;
            // 
            // btnTestPush
            // 
            this.btnTestPush.Location = new System.Drawing.Point(890, 373);
            this.btnTestPush.Name = "btnTestPush";
            this.btnTestPush.Size = new System.Drawing.Size(127, 37);
            this.btnTestPush.TabIndex = 6;
            this.btnTestPush.Text = "测试提醒";
            this.btnTestPush.UseVisualStyleBackColor = true;
            this.btnTestPush.Click += new System.EventHandler(this.btnTestPush_Click);
            // 
            // cbPlayMusic
            // 
            this.cbPlayMusic.AutoSize = true;
            this.cbPlayMusic.Location = new System.Drawing.Point(476, 430);
            this.cbPlayMusic.Name = "cbPlayMusic";
            this.cbPlayMusic.Size = new System.Drawing.Size(75, 21);
            this.cbPlayMusic.TabIndex = 7;
            this.cbPlayMusic.Text = "播放音乐";
            this.cbPlayMusic.UseVisualStyleBackColor = true;
            // 
            // niDingDong
            // 
            this.niDingDong.Icon = ((System.Drawing.Icon)(resources.GetObject("niDingDong.Icon")));
            this.niDingDong.Text = "DingDong";
            this.niDingDong.Visible = true;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 743);
            this.Controls.Add(this.cbPlayMusic);
            this.Controls.Add(this.btnTestPush);
            this.Controls.Add(this.txtPushUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveAllConfig);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrm";
            this.Shown += new System.EventHandler(this.MainFrm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContinue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvCategory;
        private GroupBox groupBox2;
        private DataGridView dgvCart;
        private GroupBox groupBox3;
        private Button btnRefreshCart;
        private Label label1;
        private Button btnImportCart;
        private Button btnExportCart;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn dgv_Name;
        private DataGridViewTextBoxColumn dgv_Number;
        private DataGridViewTextBoxColumn dgv_Price;
        private DataGridViewTextBoxColumn dvg_TotalPrice;
        private DataGridViewCheckBoxColumn dgv_Status;
        private Button btnCreateOrder;
        private CheckBox cbTrackLog;
        private NumericUpDown nudInterval;
        private Label label2;
        private Button btnSaveAllConfig;
        private Label label3;
        private TextBox txtPushUrl;
        private TextBox txtExclude;
        private Label label4;
        private Button btnTestPush;
        private CheckBox cbPlayMusic;
        private CheckBox cbCartMonitor;
        private CheckBox cbCategoryMonitor;
        private Button btnStartMonitor;
        private DateTimePicker dtpBeginTime;
        private CheckBox cbTimeStart;
        private NumericUpDown nudContinue;
        private CheckBox cbContinue;
        private Button btnClearLog;
        private DataGridViewTextBoxColumn dgv_Category_Check;
        private DataGridViewTextBoxColumn dgv_Category_Name;
        private DataGridViewCheckBoxColumn dgv_Category_Status;
        private NotifyIcon niDingDong;
    }
}