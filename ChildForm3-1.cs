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
    public partial class ChildForm3_1 : Form
    {
        public ChildForm3_1(string 商品编号, string 厂商, string 商品名, string 退货年, string 退货月, string 退货日)
        {
            InitializeComponent();
            LoadDataFromDatabase(商品编号, 厂商, 商品名, 退货年, 退货月, 退货日);
        }
        private void LoadDataFromDatabase(string 商品编号, string 厂商, string 商品名, string 退货年, string 退货月, string 退货日)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 修改这里的连接字符串为你的数据库连接字符串
            string connectionString = @"Data Source = 8pro ; Initial Catalog = shop1111 ; Integrated Security = True ";

            // 修改这里的查询语句为你的查询语句
            string query = $"SELECT 退货编号, 厂商, 商品名, 型号, 单价, 数量, 总金额, 退货年, 退货月, 退货日, 业务员编号, 总金额 FROM retreat WHERE 退货编号 = '{商品编号}' AND 厂商 = '{厂商}' AND 商品名 = '{商品名}' AND 退货年 = '{退货年}' AND 退货月 = '{退货月}' AND 退货日 = '{退货日}'";


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
