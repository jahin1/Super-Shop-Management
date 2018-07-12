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
    public partial class Update_Product : Form
    {
        Admin_Home a8;
        string table_name_combo, cmb2;
        Databasecon db = new Databasecon();
        DataTable t = new DataTable();
        public Update_Product(Admin_Home a8)
        {
            InitializeComponent();
            this.a8 = a8;
            timer1.Start();
        }
        public Update_Product()
        {
            InitializeComponent();
           
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Update_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Home a8 = new Admin_Home();
            a8.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
           // Admin_Home a8 = new Admin_Home();
            a8.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0 || textBox7.Text.Length == 0)
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                int n = db.GetQuantityForup(table_name_combo, cmb2, textBox1.Text);

                db.UpdateProduct(table_name_combo, cmb2, Convert.ToSingle(textBox7.Text), Convert.ToSingle(textBox6.Text), Convert.ToInt32(numericUpDown1.Value) + n, textBox1.Text);
                db.UpdateProductDe("productdetails", cmb2, Convert.ToSingle(textBox7.Text), Convert.ToSingle(textBox6.Text), Convert.ToInt32(numericUpDown1.Value) + n, textBox1.Text);
                db.UpdateProfitForInvest(label12.Text, db.GetInvestPRofit() + (Convert.ToInt32(numericUpDown1.Value) * Convert.ToSingle(textBox6.Text)));
                t.Rows.Clear();
                t.Columns.Clear();
                dataGridView1.DataSource = t;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT PId,name,quantity,buyingprice,sellingprice From " + table_name_combo + " where name='" + textBox1.Text + "' or name='" + cmb2 + "'");

                SqlCommand s2 = new SqlCommand(sl, con1);

                SqlDataAdapter dt2 = new SqlDataAdapter(s2);
                dt2.Fill(t);
                dataGridView1.DataSource = t;

            }
            
            
           
        }

        private void Update_Product_Load(object sender, EventArgs e)
        {

        }
        void AutoCompleteText1()
        {

            string cmbo = comboBox1.Text;
            if (cmbo.Equals("Home Appliances"))
            {
                this.table_name_combo = "Home_Appliances";
            }
            else if (cmbo.Equals("Home & Cleaning"))
            {
                this.table_name_combo = "Home_clearing";
            }
            else if (cmbo.Equals("Food"))
            {
                this.table_name_combo = "Food";
            }
            else if (cmbo.Equals("Office Products"))
            {
                this.table_name_combo = "Office_Products";
            }
            else if (cmbo.Equals("Beauty & Health"))
            {
                this.table_name_combo = "Beauty_Health";
            }
            else if (cmbo.Equals("Others"))
            {
                this.table_name_combo = "Others_Product";
            }
            else
            {
                MessageBox.Show("Catagory must select first !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            SqlConnection cs = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            cs.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + table_name_combo + "", cs);
            DataTable dt1 = new DataTable();
            comboBox2.Items.Clear();

            da.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt1.Rows[i]["name"]);
            }
            cmb2 = comboBox2.Text;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string sp = string.Format("Select * FROM " + table_name_combo + "");
            SqlCommand io = new SqlCommand(sp, con);
            SqlDataReader dt = io.ExecuteReader();
            while (dt.Read())
            {

                string name = dt.GetString(1);
                coll.Add(name);


            }
            textBox1.AutoCompleteCustomSource = coll;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteText1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmb2 = comboBox2.Text;
            if (cmb2.Length == 0 && textBox1.Text.Length == 0)
            {
                MessageBox.Show("Catagory must select first !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand s = new SqlCommand("SELECT * From " + table_name_combo + " where name='" + textBox1.Text + "' or name='" + cmb2 + "'", con);
                SqlDataReader dt = s.ExecuteReader();

                while (dt.Read())
                {
                    label11.Text = Convert.ToString(dt[0]);
                    numericUpDown1.Value = Convert.ToInt32(dt[2]);
                    textBox6.Text = Convert.ToString(dt[3]);
                    textBox7.Text = Convert.ToString(dt[4]);
                    if (cmb2.Length == 0)
                    {
                        comboBox2.Text = "";

                    }
                    else if (textBox1.Text.Length == 0)
                    {
                        textBox1.Text = "";
                    }
                    else
                    { }
                }
                con.Close();
                t.Rows.Clear();
                t.Columns.Clear();
                dataGridView1.DataSource = t;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT PId,name,quantity,buyingprice,sellingprice From " + table_name_combo + " where name='" + textBox1.Text + "' or name='" + cmb2 + "'");

                SqlCommand s2 = new SqlCommand(sl, con1);

                SqlDataAdapter dt2 = new SqlDataAdapter(s);
                dt2.Fill(t);
                dataGridView1.DataSource = t;
                con1.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = Convert.ToString(DateTime.Now.ToLocalTime());
        }
    }
}
