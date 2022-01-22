using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get {  if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null )
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PB9JJF1\DUY_SQLSEVER;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int dt = 0;

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PB9JJF1\DUY_SQLSEVER;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dt= cmd.ExecuteNonQuery();
                conn.Close();
            }
            return dt;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object dt = 0;

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PB9JJF1\DUY_SQLSEVER;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return dt;
        }



    }
}
