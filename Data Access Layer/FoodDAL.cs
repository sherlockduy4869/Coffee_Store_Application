using QuanLyQuanCafe.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Access_Layer
{
    public class FoodDAL
    {
        private static FoodDAL instance;
        public static FoodDAL Instance
        {
            get { if (instance == null) instance = new FoodDAL(); return instance; }
            private set { instance = value; }
        }
        private FoodDAL() { }

        public List<Food> GetFoodListByCategoryId(int id)
        {
            List<Food> list = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Food where idCategory = " + id);
            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                list.Add(food);
            }
            return list;
        }
    }
}
