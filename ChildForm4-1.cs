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
    public partial class ChildForm4_1 : Form
    {
        public ChildForm4_1(string 员工编号, string 年份,string 月份)
        {
            InitializeComponent();
            LoadDataFromDatabase(员工编号, 年份,月份);
        }
        private void LoadDataFromDatabase(string 员工编号, string 年份 ,string 月份)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 修改这里的连接字符串为你的数据库连接字符串
            string connectionString = @"Data Source = 8pro ; Initial Catalog = shop1111 ; Integrated Security = True ";

            // 修改这里的查询语句为你的查询语句
            string query = $"SELECT 业务员编号, 销售年,销售月, SUM(总金额) AS 总销售额 FROM sell WHERE 业务员编号 = '{员工编号}' AND 销售年 = '{年份}'AND 销售月 = '{月份}' GROUP BY 业务员编号, 销售年,销售月";




            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // 填充 DataTable
                    adapter.Fill(dataTable);

                    // 将 DataTable 直接绑定到 DataGridView，不再手动添加列
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}