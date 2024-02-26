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
    public partial class User : Form
    {
        //private Panel panel1;
        private 销售统计 childForm1;
        private ChildForm2 childForm2;
        private ChildForm3 childForm3;
        private ChildForm4 childForm4;
        private ChildForm5 childForm5;
     
        private void CloseOtherChildForms(Form currentChildForm)
        {
            if (childForm1 != currentChildForm && childForm1.IsHandleCreated && !childForm1.IsDisposed)
            {
                childForm1.Close();
            }

            if (childForm2 != currentChildForm && childForm2.IsHandleCreated && !childForm2.IsDisposed)
            {
                childForm2.Close();
            }

            if (childForm3 != currentChildForm && childForm3.IsHandleCreated && !childForm3.IsDisposed)
            {
                childForm3.Close();
            }

            if (childForm4 != currentChildForm && childForm4.IsHandleCreated && !childForm4.IsDisposed)
            {
                childForm4.Close();
            }
            if (childForm5 != currentChildForm && childForm5.IsHandleCreated && !childForm5.IsDisposed)
            {
                childForm5.Close();
            }
        }
        public User()
        {
            InitializeComponent();

            // 在构造函数或Load事件中创建Panel
            panel1 = new Panel();
            panel1.Dock = DockStyle.Fill;  // 可根据需要设置Dock属性
            Controls.Add(panel1);
            childForm1 = new 销售统计();
            childForm2 = new ChildForm2();
            childForm3 = new ChildForm3();
            childForm4 = new ChildForm4();
            childForm5 = new ChildForm5();
            Load += User_Load;
        }
        private void User_Load(object sender, EventArgs e)
        {
            // 这里可以添加在User窗体加载时的处理逻辑
        }

        private void button1_Click(object sender, EventArgs e)
        {
            childForm1.StartPosition = FormStartPosition.Manual;
            childForm1.Location = new Point(50000, 50000); 
            CloseOtherChildForms(childForm1);
            childForm1 = new 销售统计();
            childForm1.TopLevel = false;
            childForm1.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(childForm1);
            childForm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseOtherChildForms(childForm2);
            childForm2 = new ChildForm2();
            childForm2.TopLevel = false;
            childForm2.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(childForm2);
            childForm2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CloseOtherChildForms(childForm3);
            childForm3 = new ChildForm3();
            childForm3.TopLevel = false;
            childForm3.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(childForm3);
            childForm3.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            CloseOtherChildForms(childForm4);
            childForm4 = new ChildForm4();
            childForm4.TopLevel = false;
            childForm4.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(childForm4);
            childForm4.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            CloseOtherChildForms(childForm5);
            childForm5 = new ChildForm5();
            childForm5.TopLevel = false;
            childForm5.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(childForm5);
            childForm5.Show();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
