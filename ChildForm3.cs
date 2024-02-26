using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 销售管理系统
{
    public partial class ChildForm3 : Form
    {
        public ChildForm3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 获取查询条件
            string 退货编号 = textBox13.Text;
            string 厂商 = textBox14.Text;
            string 商品名 = textBox15.Text;
            string 退货年 = textBox16.Text;
            string 退货月 = textBox17.Text;
            string 退货日 = textBox18.Text;

            
            ChildForm3_1 childForm = new ChildForm3_1(退货编号, 厂商, 商品名, 退货年, 退货月, 退货日);

            
            childForm.Show();
            
            
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
