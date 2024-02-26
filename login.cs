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
    public partial class login : Form
    {
        public login()
        {

            InitializeComponent();
        }

        public void Login()
        {
            Dao dao = new Dao();
            string sql = "select * from [userdb] where id= '"+textBox1.Text+"' and psw='"+textBox2.Text+"'";
            IDataReader dc = dao.read(sql);
            if(dc.Read()) {
                MessageBox.Show("登陆成功");
                User user = new User();
                this.Hide();
                user.ShowDialog();
                this.Show();
            }else
            {
                MessageBox.Show("登陆失败");
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有误，请重新输入");
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePswform changePasswordForm = new ChangePswform();

            // 显示 ChangePasswordForm 窗体
            changePasswordForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
