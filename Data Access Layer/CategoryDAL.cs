using QuanLyQuanCafe.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class CategoryDAL
    {
        private static CategoryDAL instance;
        public static CategoryDAL Instance
        {
            get { if (instance == null) instance = new CategoryDAL(); return instance; }
            private set { instance = value; }
        }
        private CategoryDAL() { }
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from FoodCategory");
            foreach(DataRow dr in data.Rows)
            {
                Category category = new Category(dr);
                list.Add(category);
            }
            return list;
        }
    }
}
