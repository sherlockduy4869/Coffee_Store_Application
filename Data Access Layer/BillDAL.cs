using QuanLyQuanCafe.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class BillDAL
    {
        private static BillDAL instance;
        public static BillDAL Instance
        {
            get { if (instance == null) instance = new BillDAL(); return instance; }
            private set { instance = value; }
        }
        private BillDAL() { }
        public int GetUncheckedBillIdByTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * From Bill WHERE idTable ="+id+"and status = 0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            else
            {
                return -1;
            }
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertBill @idTable = ", new object[] {id});
        }
        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select Max(id) from Bill");
            }
            catch (Exception ex)
            {
                return 1;
            }

        }
        public void CheckOut(int id)
        {
            string query = "Delete BillInfo where idBill= "+id ;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertHistory(int discount )
        {
            DataProvider.Instance.ExecuteQuery("INSERT INTO History(Discount) VALUES("+discount+")");
        }

       
    }
}
