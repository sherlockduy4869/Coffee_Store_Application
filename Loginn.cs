using QuanLyQuanCafe.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace QuanLyQuanCafe
{
    public partial class Loginn : Form
    {
        public Loginn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if(Login(userName, passWord))
            {
                TableMananger TableMananger = new TableMananger();
                this.Hide();
                TableMananger.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong!!!");
            }
            
        }
        bool Login(string userName, string passWord)
        {
            return AccountDAL.Instance.Login(userName,passWord);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
