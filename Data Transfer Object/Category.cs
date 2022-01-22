using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Transfer_Object
{
    public class Category
    {
        private int _id;
        private string _name;
        public Category(DataRow row) 
        {
            _id = (int)row["id"];
            _name = (string)row["name"];
        }
        public Category(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
