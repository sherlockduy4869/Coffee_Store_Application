using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class AccountDAL
    {
        
        private static AccountDAL instance;
        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set { instance = value; }
        }
        private AccountDAL() { }
        public bool Login(string userName, string passWord)
        {
            string query = "EXEC dbo.USP_Login @UserName , @PassWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName,passWord});
            return result.Rows.Count > 0;
        }

    }
}
