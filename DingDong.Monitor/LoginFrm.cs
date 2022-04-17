using DingDong.Monitor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DingDong.Monitor
{
    public partial class LoginFrm : Form
    {
        private Action<DingDongConfig> _saveConfig;
        public LoginFrm(Action<DingDongConfig> saveConfig)
        {
            InitializeComponent();
            _saveConfig = saveConfig;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var config = DingDongUtils.Convert2Config(textBox1.Text);
            if (config == null)
            {
                MessageBox.Show("配置错误");
                return;
            }
            _saveConfig.Invoke(config);
            this.Close();
        }
    }
}
