using QuanLyQuanCafe.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class BillInfoDAL
    {
        private static BillInfoDAL instance;
        public static BillInfoDAL Instance
        {
            get { if (instance == null) instance = new BillInfoDAL(); return instance; }
            private set { instance = value; }
        }
        private BillInfoDAL() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> list = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE id ="+id);
            foreach (DataRow row in data.Rows)
            {
                BillInfo info = new BillInfo(row);
                list.Add(info);

            }
            return list;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillInfo @idBill , @idFood , @count", new object[] {idBill,idFood,count});
        }
    }
}
