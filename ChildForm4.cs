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
    public partial class ChildForm4 : Form
    {
        public ChildForm4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 员工编号 = textBox1.Text;
            string 年份 = textBox2.Text;
            string 月份 = textBox3.Text;
            ChildForm4_1 childForm = new ChildForm4_1(员工编号, 年份, 月份);
            childForm.Show();            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string 员工编号 = textBox1.Text;
            string 年份 = textBox2.Text;
            ChildForm4_2 childForm = new ChildForm4_2(员工编号, 年份);
            childForm.Show();
        }

    }
}
