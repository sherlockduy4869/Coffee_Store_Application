using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Transfer_Object
{
    public class Menu
    {
        private string _foodName;
        private int _count;
        private float _price;
        private float _totalPrice;

        public Menu(DataRow row)
        {
            _count = (int)row["count"];
            _foodName = (string)row["name"];
            _price = (float)Convert.ToDouble(row["price"].ToString());
            _totalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        public Menu(string foodName, int count, float price, float totalPrice = 0)
        {
            _count = count;
            _foodName = foodName;
            _price = price;
            _totalPrice = totalPrice;
        }
        public string FoodName
        {
            get { return _foodName; }
            set { _foodName = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public float TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
    }
}
