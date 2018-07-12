using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop
{
    public partial class Delete_Salesman : Form
    {
        Databasecon db = new Databasecon();
        Admin_Home ah;
        public Delete_Salesman()
        {
            InitializeComponent();
            AutoCompleteText();
            AutoCompleteText1();
        }
        public Delete_Salesman(Admin_Home ah)
        {
            InitializeComponent();
            AutoCompleteText();
            AutoCompleteText1();
            this.ah = ah;
        }

        private void Delete_Salesman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Admin_Home a6 = new Admin_Home();
            a6.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0 || textBox2.Text.Length == 0 )
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                db.DeleteSalesAndAdmin("Salesmaninfo", "SId", textBox1.Text, textBox2.Text);
                ah.Show();
                this.Hide();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Admin_Home a6 = new Admin_Home();
            ah.Show();
            this.Hide();
        }

        private void Delete_Salesman_Load(object sender, EventArgs e)
        {

        }
        void AutoCompleteText()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string sp = string.Format("Select * FROM Salesmaninfo");
            SqlCommand i = new SqlCommand(sp, con);
            SqlDataReader dt = i.ExecuteReader();
            while (dt.Read())
            {

                string name = dt.GetString(0);
                coll.Add(name);


            }
            textBox1.AutoCompleteCustomSource = coll;

        }
        void AutoCompleteText1()
        {
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string sp = string.Format("Select * FROM Salesmaninfo");
            SqlCommand i = new SqlCommand(sp, con);
            SqlDataReader dt = i.ExecuteReader();
            while (dt.Read())
            {

                string name = dt.GetString(1);
                coll.Add(name);


            }
            textBox2.AutoCompleteCustomSource = coll;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From Salesmaninfo where SId='" + textBox1.Text + "' Or name='"+textBox2.Text+"'", con);
            SqlDataReader dt = s.ExecuteReader();

            while (dt.Read())
            {
                textBox2.Text = Convert.ToString(dt[1]);
                textBox3.Text = Convert.ToString(dt[6]);
                textBox5.Text = Convert.ToString(dt[7]);
                textBox1.Text=Convert.ToString(dt[0]);
                
            }

               
        }
    }
}
