using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Transfer_Object
{
    public class Bill
    {
        private int _id;
        private int _status;
        private DateTime? _dateCheckIn;
        private DateTime? _dateCheckOut;
        private int _discount;
        
        public Bill(int id, int status, DateTime dateCheckIn, DateTime dateCheckOut, int discount = 0)
        {
            _id = id;
            _status = status;
            _dateCheckIn = dateCheckIn;
            _dateCheckOut = dateCheckOut;
            _discount = discount;
        }
        public Bill(DataRow row)
        {
            _id = (int) row["id"];
            _status = (int) row["status"];
            _dateCheckIn = (DateTime?) row["DateCheckIn"];
            _discount = (int)row["discount"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")
            _dateCheckOut = (DateTime?)dateCheckOutTemp;
            
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public DateTime? DateCheckIn
        {
            get { return _dateCheckIn; }
            set { _dateCheckIn = value; }
        }
        public DateTime? DateCheckOut
        {
            get { return _dateCheckOut; }
            set { _dateCheckOut = value; }
        }
        public int Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
    }
}
