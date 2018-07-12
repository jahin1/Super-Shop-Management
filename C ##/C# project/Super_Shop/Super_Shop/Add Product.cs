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
    public partial class Add_Product : Form
    {
        Databasecon cn = new Databasecon();
        string table_name;
        Product pp = new Product();
        Admin_Home a;
        public Add_Product()
        {
            InitializeComponent();
            label11.Text = pp.PID;
        }
        public Add_Product(Admin_Home a)
        {
            InitializeComponent();
            label11.Text = pp.PID;
            this.a = a;
            timer1.Start();
            label9.Hide();
        }


        private void Add_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Home a3 = new Admin_Home();
            a3.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //Admin_Home a3 = new Admin_Home();
            a.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            string cmbo = comboBox1.Text;
            if(cmbo.Equals("Home Appliances"))
            {
             this.table_name = "Home_Appliances";
            }
            else if (cmbo.Equals("Home & Cleaning"))
            {
                this.table_name = "Home_clearing";
            }
            else if (cmbo.Equals("Food"))
            {
                this.table_name = "Food";
            }
            else if (cmbo.Equals("Office Products"))
            {
                this.table_name = "Office_Products";
            }
            else if (cmbo.Equals("Beauty & Health"))
            {
                this.table_name = "Beauty_Health";
            }
            else if (cmbo.Equals("Others"))
            {
                this.table_name = "Others_Product";
            }
            else
            {
                MessageBox.Show("Catagory must select first !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            else
            {
                pp.PID = pp.PID;
                pp.ProductName = textBox1.Text;
                pp.Quantity = Convert.ToInt32(numericUpDown1.Value);
                pp.BuyingPrice = Convert.ToSingle(textBox6.Text);
                pp.SellingPrice = Convert.ToSingle(textBox7.Text);
                pp.TotalSold = 0;
                float cp = pp.SellingPrice - pp.BuyingPrice;
                pp.Profit = cp;
                pp.Details = textBox2.Text;


                cn.UpdateProfitForInvest(label9.Text, cn.GetInvestPRofit() + (Convert.ToInt32(numericUpDown1.Value) * Convert.ToSingle(textBox6.Text)));

                cn.InsertPro1(table_name, pp.PID, pp.ProductName, pp.Quantity, pp.BuyingPrice, pp.SellingPrice, pp.TotalSold, pp.Profit, pp.Details);
                cn.InsertPro(table_name, pp.PID, pp.ProductName, pp.Quantity, pp.BuyingPrice, pp.SellingPrice, pp.TotalSold, pp.Profit);
                a.Show();
                this.Hide();
            }
           

            //float inv=cn.GetInvestPRofit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Product_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = Convert.ToString(DateTime.Now.ToLocalTime());
        }
    }
}
