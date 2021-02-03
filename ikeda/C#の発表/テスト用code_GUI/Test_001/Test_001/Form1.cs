using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("メインスレッド例外");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() => throw new Exception("別スレッド例外"));
        }
    }
}
