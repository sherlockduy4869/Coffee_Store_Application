using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Transfer_Object
{
    public class Food
    {
        private int _id;
        private int _idCategory;
        private string _name;
        private float _price;

        public Food(DataRow row)
        { 
            _id = (int)row["id"];
            _idCategory = (int)row["idCategory"];
            _name = (string)row["name"];
            _price = (float)Convert.ToDouble(row["price"].ToString());
        }
        public Food(int id, int idCategory, string name, float price)
        {
            _id = id;
            _idCategory = idCategory;
            _name = name;
            _price = price;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
