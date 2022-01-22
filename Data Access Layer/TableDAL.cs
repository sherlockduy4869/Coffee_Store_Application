using QuanLyQuanCafe.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class TableDAL
    {
        private static TableDAL instance;
        public static int tableWidth = 200;
        public static int tableHeight = 200;
        public static TableDAL Instance
        {
            get { if (instance == null) instance = new TableDAL(); return instance; }
            private set { instance = value; }
        }
        private TableDAL() { }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_TableList");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_SwitchTable @idTable1 , @idTable2", new object[] {id1, id2});
        }
    }
}
