using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 销售管理系统
{
    internal class Dao
    {
        SqlConnection sc;
        public Dao()
        {
            sc = connect(); // 在构造函数中调用 connect 方法打开连接
        }
        public SqlConnection connect() {
            string str = @"Data Source = 8pro ; Initial Catalog = shop1111 ; Integrated Security = True ";
            sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }
        public SqlCommand command(string str)
        {
            SqlCommand cmd = new SqlCommand(str , connect());
            return cmd;
        }
        public int Execute(string sql) {
            return command(sql).ExecuteNonQuery();
                
        }
        public int Execute1(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }
        public SqlDataReader read(string sql) {
            return command(sql).ExecuteReader();
        }
        public void DaoClose() { 
               sc.Close();
        }
        internal object ExecuteScalar(string selectSql)
        {
            using (SqlCommand command = new SqlCommand(selectSql, sc))
            {
                //sc.Open(); // 不需要手动打开连接，因为在构造函数中已经打开了
                return command.ExecuteScalar();
            }
        }
    }
}
