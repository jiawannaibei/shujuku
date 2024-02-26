using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 销售管理系统
{
    public partial class ChangePswform : Form
    {
        public ChangePswform()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string id = textBox1.Text;
            string currentPassword = textBox2.Text;
            string newPassword = textBox3.Text;

            // Check if the user exists in the database
            string checkUserSql = $"SELECT * FROM [userdb] WHERE id = '{id}'";
            IDataReader checkUserReader = dao.read(checkUserSql);

            if (checkUserReader.Read())
            {
                checkUserReader.Close();

                // Check if the current password is correct
                string checkPasswordSql = $"SELECT * FROM [userdb] WHERE id = '{id}' AND psw = '{currentPassword}'";
                IDataReader checkPasswordReader = dao.read(checkPasswordSql);

                if (checkPasswordReader.Read())
                {
                    // Current password is correct, proceed to update the password
                    checkPasswordReader.Close();

                    if (textBox3.Text != "" && textBox4.Text != "" && textBox3.Text == textBox4.Text)
                    {
                        // Update password in the database
                        string updatePasswordSql = $"UPDATE [userdb] SET psw = '{newPassword}' WHERE id = '{id}'";

                        try
                        {
                            dao.Execute(updatePasswordSql);
                            MessageBox.Show("密码更新成功");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"密码更新失败：{ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("新密码和确认密码不匹配");
                    }
                }
                else
                {
                    MessageBox.Show("当前密码不正确");
                }
            }
            else
            {
                MessageBox.Show("用户不存在，请先注册");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChangePswform_Load(object sender, EventArgs e)
        {

        }
    }
}
