using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Transfer_Object
{
     public class Table
    {
        private int _id;
        private string _name;
        private string _status;

        public Table(DataRow row)
        {
            _id = (int)row["id"];
            _name = (string)row["name"];
            _status = (string)row["status"];
        }
        public Table(int id, string name, string status)
        {
            _id = id;
            _name = name;  
            _status = status;  
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
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
