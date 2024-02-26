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
    public partial class ChildForm2_1 : Form
    {
        public ChildForm2_1(string 商品编号, string 生产厂商, string 商品名, string 进货年, string 进货月, string 进货日)
        {
            InitializeComponent();
            LoadDataFromDatabase(商品编号, 生产厂商, 商品名, 进货年, 进货月, 进货日);
        }

        public ChildForm2_1()
        {
        }

        private void LoadDataFromDatabase(string 商品编号, string 生产厂商, string 商品名, string 进货年, string 进货月, string 进货日)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 修改这里的连接字符串为你的数据库连接字符串
            string connectionString = @"Data Source = 8pro ; Initial Catalog = shop1111 ; Integrated Security = True ";

            // 修改这里的查询语句为你的查询语句
            string query = $"SELECT 商品编号, 生产厂商, 商品名, 型号, 单价, 数量, 总金额, 进货年, 进货月, 进货日, 业务员编号, 总金额 FROM goods WHERE 商品编号 = '{商品编号}' AND 生产厂商 = '{生产厂商}' AND 商品名 = '{商品名}' AND 进货年 = '{进货年}' AND 进货月 = '{进货月}' AND 进货日 = '{进货日}'";


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

        // 重写 OnLoad 方法，在窗体加载时调用 LoadDataFromDatabase
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //LoadDataFromDatabase(string 商品编号, string 生产厂商, string 商品名, string 进货年, string 进货月, string 进货日);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 处理单元格点击事件
        }
    }
}

