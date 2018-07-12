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
    public partial class Delete_Product : Form
    {
        Admin_Home a;
        string table_name_combo;
        string cmb2;
        Databasecon db = new Databasecon();
        public Delete_Product()
        {
            InitializeComponent();
          
        }
        public Delete_Product(Admin_Home a)
        {
            InitializeComponent();
            this.a = a;
          
        }


        private void Delete_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Admin_Home a5 = new Admin_Home();
            a5.Show();
            this.Hide();
        }

        private void Delete_Product_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Admin_Home a5 = new Admin_Home();
            a.Show();
            this.Hide();
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
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
            cmb2=comboBox2.Text;
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

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteText1();
        }

       private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 && comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Catagory must select first !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                db.DeleteProduct(table_name_combo, cmb2, textBox1.Text);
                db.DeleteProductDetails(cmb2, textBox1.Text);
                textBox1.Text = "";
            }   //MessageBox.Show("Delete Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
