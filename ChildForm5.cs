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
    public partial class ChildForm5 : Form
    {
        public ChildForm5()
        {
            InitializeComponent();
        }

        private void ChildForm5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 员工编号 = textBox1.Text;
            ChildForm5_1 childForm = new ChildForm5_1(员工编号);
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string 员工姓名 = textBox2.Text;
                string 员工电话 = textBox3.Text;
                string 员工地址 = textBox4.Text;

                string query = $"INSERT INTO employee (员工姓名, 员工电话, 员工地址) VALUES ('{员工姓名}', '{员工电话}', '{员工地址}'); SELECT SCOPE_IDENTITY()";

                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=8pro; Initial Catalog=shop1111; Integrated Security=True"))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // 执行插入并获取标识列的值
                            int 新员工编号 = Convert.ToInt32(command.ExecuteScalar());

                            MessageBox.Show($"新员工插入成功，员工编号为：{新员工编号}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 处理异常
                    MessageBox.Show($"发生异常：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
