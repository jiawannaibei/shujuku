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

namespace 销售管理系统
{
    public partial class ChildForm2 : Form
    {
        public ChildForm2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            // 获取查询条件
            string 商品编号 = textBox13.Text;
            string 生产厂商 = textBox14.Text;
            string 商品名 = textBox15.Text;
            string 进货年 = textBox16.Text;
            string 进货月 = textBox17.Text;
            string 进货日 = textBox18.Text;

            // 创建 ChildForm2_1 实例并传递条件
            ChildForm2_1 childForm = new ChildForm2_1(商品编号, 生产厂商, 商品名, 进货年, 进货月, 进货日);

            // 显示 ChildForm2_1
            childForm.Show();
        }


    }
}




