using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 销售管理系统
{
    public partial class 销售统计 : Form
    {
        public 销售统计()
        {
            InitializeComponent();
        }

  
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 销售统计_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private int GetProductQuantity(string productId)
        {
            // 通过 SELECT 语句查询商品库存数量
            string selectSql = $"SELECT 数量 FROM goods WHERE 型号 = '{productId}'";

            Dao dao = new Dao();
                // 执行查询
            int quantity = Convert.ToInt32(dao.ExecuteScalar(selectSql));
            return quantity;            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox8.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "" && textBox15.Text != "" && textBox14.Text != "" && textBox4.Text != "")
            {
                decimal unitPrice = 0;
                if (decimal.TryParse(textBox7.Text, out unitPrice) == false)
                {
                    MessageBox.Show("请输入有效的单价");
                    return; // 或者采取适当的错误处理措施
                }

                int quantity = 0;
                if (int.TryParse(textBox6.Text, out quantity) == false)
                {
                    MessageBox.Show("请输入有效的数量");
                    return; // 或者采取适当的错误处理措施
                }
                int currentQuantity = GetProductQuantity(textBox3.Text);
                if (currentQuantity >= quantity)
                {
                    decimal totalAmount = unitPrice * currentQuantity;
                    Dao dao = new Dao();
                    string sql = $"SET IDENTITY_INSERT sell ON; INSERT INTO sell (商品编号, 生产厂商, 商品名, 型号, 单价, 数量, 总金额, 销售年 , 销售月, 销售日, 业务员编号) VALUES ({textBox1.Text}, '{textBox8.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox7.Text}', '{textBox6.Text}', '{totalAmount}', '{textBox5.Text}', '{textBox15.Text}', '{textBox14.Text}', '{textBox4.Text}'); SET IDENTITY_INSERT sell OFF;";
                    string sql1 = $"UPDATE goods SET 数量 = 数量 - {textBox6.Text} WHERE 型号 = '{textBox3.Text}'";

                    int n = dao.Execute(sql) , m = dao.Execute(sql1);
                    if (n > 0 && m > 0)
                    { 
                        MessageBox.Show("销售成功");
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                    // 如果需要在处理完后给用户反馈，可以显示一个消息框
                }
                else
                {
                    MessageBox.Show("商品库存不足");
                }
            }
        }

        // 获取商品库存数量



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox8.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "" && textBox15.Text != "" && textBox14.Text != "" && textBox4.Text != "")
            {
                decimal unitPrice = 0;
                if (decimal.TryParse(textBox7.Text, out unitPrice) == false)
                {
                    MessageBox.Show("请输入有效的单价");
                    return; // 或者采取适当的错误处理措施
                }

                int quantity = 0;
                if (int.TryParse(textBox6.Text, out quantity) == false)
                {
                    MessageBox.Show("请输入有效的数量");
                    return; // 或者采取适当的错误处理措施
                }

                // 计算总金额
                decimal totalAmount = unitPrice * quantity;
                Dao dao = new Dao();
                string sql = $"SET IDENTITY_INSERT retreat ON; INSERT INTO retreat (退货编号, 厂商, 商品名, 型号, 单价, 数量, 总金额, 退货年, 退货月, 退货日, 业务员编号) VALUES ({textBox1.Text}, '{textBox8.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox7.Text}', '{textBox6.Text}', '{totalAmount}', '{textBox5.Text}', '{textBox15.Text}', '{textBox14.Text}', '{textBox4.Text}'); SET IDENTITY_INSERT retreat OFF;";
                int n = dao.Execute(sql);
                if(n > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                MessageBox.Show("请重新输入");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox8.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "" && textBox15.Text != "" && textBox14.Text != "" && textBox4.Text != "")
            {
                decimal unitPrice = 0;
                if (decimal.TryParse(textBox7.Text, out unitPrice) == false)
                {
                    MessageBox.Show("请输入有效的单价");
                    return; // 或者采取适当的错误处理措施
                }

                int quantity = 0;
                if (int.TryParse(textBox6.Text, out quantity) == false)
                {
                    MessageBox.Show("请输入有效的数量");
                    return; // 或者采取适当的错误处理措施
                }

                // 计算总金额
                decimal totalAmount = unitPrice * quantity;
                Dao dao = new Dao();
                string sql = $"SET IDENTITY_INSERT goods ON; INSERT INTO goods (商品编号, 生产厂商, 商品名, 型号, 单价, 数量, 总金额, 进货年, 进货月, 进货日, 业务员编号) VALUES ({textBox1.Text}, '{textBox8.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox7.Text}', '{textBox6.Text}', '{totalAmount}', '{textBox5.Text}', '{textBox15.Text}', '{textBox14.Text}', '{textBox4.Text}'); SET IDENTITY_INSERT goods OFF;";
                int n = dao.Execute(sql);
                if (n > 0)
                {

                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            } 
            else
            {
                MessageBox.Show("请重新输入");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {
                Dao dao = new Dao();

                // 将textBox8.Text转换为整数
                if (int.TryParse(textBox9.Text, out int 厂商编号))
                {
                    string str = $"SET IDENTITY_INSERT manufacturer ON; " +
                                  $"INSERT INTO manufacturer (厂商编号, 厂商名称, 法人代表, 电话, 厂商地址) " +
                                  $"VALUES ({厂商编号}, '{textBox8.Text}', '{textBox10.Text}', '{textBox13.Text}', '{textBox12.Text}'); " +
                                  $"SET IDENTITY_INSERT manufacturer OFF;";

                    int n = dao.Execute(str);

                    if (n > 0)
                    {
                        MessageBox.Show("入库成功");
                    }
                    else
                    {
                        MessageBox.Show("入库失败");
                    }
                }
                else
                {
                    MessageBox.Show("厂商编号必须是整数类型");
                }
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
