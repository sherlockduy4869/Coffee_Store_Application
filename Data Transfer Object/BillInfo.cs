using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Data_Transfer_Object
{
    public class BillInfo
    {
        private int _id;
        private int _idBill;
        private int _idFood;
        private int _count;

        public BillInfo(DataRow row)
        {
            _id =(int) row["id"];
            _idBill = (int) row["idBill"];
            _idFood = (int)row["idFood"];
            _count = (int) row["count"];
        }

        public BillInfo(int id, int idBill, int idFood, int count)
        {
            _id = id;
            _idBill = idBill;
            _idFood = idFood;
            _count = count;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int IdBill
        {
            get { return _idBill; }
            set { _idBill = value; }
        }
        public int IdFood
        {
            get { return _idFood; }
            set { _idFood = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }


    }
}
