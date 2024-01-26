using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuan_1
{
    public class DataBase
    {
        public SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        public DataBase() { }
        public void getdata(string query, DataGridView dtView) {
            string sqlStr = string.Format(query);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dtView.DataSource = data;
        }
        public bool thucThi(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

    }
}
