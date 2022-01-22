using System;
using QuanLyQuanCafe.Data_Transfer_Object;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class MenuDAL
    {
        private static MenuDAL instance;
        public static MenuDAL Instance
        {
            get { if (instance == null) instance = new MenuDAL(); return instance; }
            private set { instance = value; }
        }
        private MenuDAL() { }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> list = new List<Menu>();
            string query = "SELECT Food.name, BillInfo.count, Food.price, Food.price*BillInfo.count as totalPrice FROM BillInfo JOIN Bill ON BillInfo.idBill = Bill.id JOIN Food ON BillInfo.idFood = Food.id WHERE idTable = "+id+"and status = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Menu menu = new Menu(row);
                list.Add(menu);
            }
            return list;
        }
    }
}
