using QuanLyQuanCafe.Data_Access_Layer;
using QuanLyQuanCafe.Data_Transfer_Object;
using static System.Windows.Forms.ListViewItem;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class TableMananger : Form
    {
        public TableMananger()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbChangeTable);
        }

        #region Method
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAL.Instance.LoadTableList();
            foreach (Table table in tableList)
            {
                Button btn = new Button() { Width = TableDAL.tableWidth, Height = TableDAL.tableHeight };
                flpTable.Controls.Add(btn);
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += btn_Click;
                btn.Tag = table;
                switch (table.Status)
                {
                    case "Trong":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.Yellow;
                        break;
                }
                
            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<Menu> list = MenuDAL.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (Menu bill in list)
            {
                ListViewItem lsvitem = new ListViewItem(bill.FoodName.ToString());
                lsvitem.SubItems.Add(bill.Count.ToString());
                lsvitem.SubItems.Add(bill.Price.ToString());
                lsvitem.SubItems.Add(bill.TotalPrice.ToString());
                totalPrice+=bill.TotalPrice;
                lsvBill.Items.Add(lsvitem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalPrice.ToString("c",culture);

           
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAL.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "name";

        }
        void LoadFoodListByCategoryId(int id)
        {
            List<Food> listFood = FoodDAL.Instance.GetFoodListByCategoryId(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "name";

        }
        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAL.Instance.LoadTableList();
            cb.DisplayMember = "name";
        }
        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).Id;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile fAccountProfile = new AccountProfile();
            fAccountProfile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin fAdmin = new Admin();
            fAdmin.ShowDialog();
        }

        private void fTableMananger_Load(object sender, EventArgs e)
        {

        }
        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.Id;
            LoadFoodListByCategoryId(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Table table = lsvBill.Tag as Table;
            int idBill = BillDAL.Instance.GetUncheckedBillIdByTableId(table.Id);
            int idFood = (cbFood.SelectedItem as Food).Id;
            int count = (int)nmFoodCount.Value;
            if(idBill == -1)
            {
                BillDAL.Instance.InsertBill(table.Id);
                BillInfoDAL.Instance.InsertBillInfo(BillDAL.Instance.GetMaxIdBill(), idFood,count);
            }
            else
            {
                BillInfoDAL.Instance.InsertBillInfo(idBill, idFood, count);
            }
            ShowBill(table.Id);
            LoadTable();
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAL.Instance.GetUncheckedBillIdByTableId(table.Id);
            int discount = (int)nmDiscount.Value;
            string ttprice = lsTotalPrice.ToString();
            double totalPrice = double.Parse(txbTotalPrice.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            double finalTotalPrice = totalPrice - totalPrice / 100 * discount;
            if(idBill != -1)
            {
                if(MessageBox.Show(string.Format("Do you want to pay the bill for {0}\n TotalPrice - TotalPrice/100*Discount\n => {1} - {1}/100*{2} = {3} ", table.Name, totalPrice, discount, finalTotalPrice),"Attention",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    
                    BillDAL.Instance.InsertHistory(discount);
                    BillDAL.Instance.CheckOut(idBill);
                    ShowBill(table.Id);
                    LoadTable();
                    nmDiscount.Value = 0;
                }
            }
        }
        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            
            int id1 = (lsvBill.Tag as Table).Id;

            int id2 = (cbChangeTable.SelectedItem as Table).Id;

            string name1 = (lsvBill.Tag as Table).Name;

            string name2 = (cbChangeTable.SelectedItem as Table).Name;

            if (MessageBox.Show(String.Format("Do you want to change from table {0} to table {1}", name1, name2), "Attention", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                TableDAL.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }
        #endregion


    }
}
