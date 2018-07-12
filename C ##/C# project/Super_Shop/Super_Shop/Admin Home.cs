using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop
{
    public partial class Admin_Home : Form
    {
        public Admin_Home()
        {
            InitializeComponent();
        }
        public Admin_Home(string n)
        {
            InitializeComponent();
            label5.Text = n;
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Information f2 = new Information();
            f2.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogIn l2 = new LogIn();
            l2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Salesman_Info ups = new Update_Salesman_Info();
            ups.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Salesman ds = new Delete_Salesman();
            ds.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Product ap = new Add_Product();
            ap.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update_Product up = new Update_Product();
            up.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Delete_Product dp = new Delete_Product();
            dp.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Update_Admin ua = new Update_Admin();
            ua.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Delete_Admin da = new Delete_Admin();
            da.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddSalesman as1 = new AddSalesman(this);
            as1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Update_Salesman_Info ups = new Update_Salesman_Info(this);
            ups.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Delete_Salesman ds = new Delete_Salesman(this);
            ds.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            Add_Product ap = new Add_Product(this);
            ap.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Update_Product up = new Update_Product(this);
            up.Show();
            this.Hide();

        }

        private void button6_Click_2(object sender, EventArgs e)
        {

            Delete_Product dp = new Delete_Product(this);
            dp.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            Add_Admin ad = new Add_Admin(this);
            ad.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Update_Admin ua = new Update_Admin(this);
            ua.Show();
            this.Hide();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            Delete_Admin da = new Delete_Admin(this);
            da.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            LogIn l2 = new LogIn();
            l2.Show();
            this.Hide();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nm = label5.Text;
            PasswordChangeA p = new PasswordChangeA(this,nm);
            p.Show();
            this.Hide();
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDetails c4 = new CustomerDetails(this);
            c4.Show();
            this.Hide();
        }

        private void Admin_Home_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(DateTime.Now.ToLocalTime());
        }

        private void salaryCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary ss = new Salary(this);
            ss.Show();
            this.Hide();
        }

        private void profitCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profit pp = new Profit(this);

            pp.Show();
            this.Hide();
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

    }
}
