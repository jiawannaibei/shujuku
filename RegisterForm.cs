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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void RegisterNewAccount(string username, string password)
        {
            try
            {
                // 使用 ADO.NET 连接到数据库
                using (SqlConnection connection = new SqlConnection("Data Source=8pro; Initial Catalog=shop1111; Integrated Security=True"))
                {
                    connection.Open();

                    // 构建检查是否存在相同 ID 的 SQL 查询
                    string checkExistenceQuery = $"SELECT COUNT(*) FROM userdb WHERE id = '{username}'";

                    // 使用 SqlCommand 执行查询
                    using (SqlCommand checkExistenceCommand = new SqlCommand(checkExistenceQuery, connection))
                    {
                        int count = (int)checkExistenceCommand.ExecuteScalar();

                        // 如果已存在相同的 ID，则注册失败
                        if (count > 0)
                        {
                            MessageBox.Show("注册失败，已存在相同的用户名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 如果没有相同的 ID，则执行插入新用户的 SQL 查询
                    string insertQuery = $"INSERT INTO userdb (id, psw) VALUES ('{username}', '{password}')";

                    // 使用 SqlCommand 执行插入操作
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("注册成功");
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                MessageBox.Show($"注册失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox2.Text == textBox3.Text)
            {
                RegisterNewAccount(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("输入有误，请重新输入");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
