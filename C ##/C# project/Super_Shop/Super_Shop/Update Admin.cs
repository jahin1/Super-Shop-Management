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
    public partial class Update_Admin : Form
    {
        Admin_Home a7;
        DataTable t = new DataTable();
        Databasecon db = new Databasecon();
        public Update_Admin(Admin_Home a7)
        {
            InitializeComponent();
            this.a7 = a7;
            AutoCompleteText();
            t.Rows.Clear();
            t.Columns.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT AId,name,email,mobileNo,address FROM Admininfo");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
            label10.Hide();
        }
        public Update_Admin()
        {
            InitializeComponent();
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Update_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                db.UpdateAdmin(textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text, textBox6.Text);
                t.Rows.Clear();
                t.Columns.Clear();
                dataGridView1.DataSource = t;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT AId,name,email,mobileNo,address FROM Admininfo");

                SqlCommand s = new SqlCommand(sl, con1);

                SqlDataAdapter dt = new SqlDataAdapter(s);
                dt.Fill(t);
                dataGridView1.DataSource = t;
            } //MessageBox.Show("Admin Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Back_Click(object sender, EventArgs e)
        {
           // Admin_Home a7 = new Admin_Home();
            a7.Show();
            this.Hide();
        }

        void AutoCompleteText()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string sp = string.Format("Select * FROM Admininfo");
            SqlCommand i = new SqlCommand(sp, con);
            SqlDataReader dt = i.ExecuteReader();
            while (dt.Read())
            {

                string name = dt.GetString(0);
                coll.Add(name);


            }
            textBox1.AutoCompleteCustomSource = coll;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From Admininfo where AId='" + textBox1.Text + "'", con);
            SqlDataReader dt = s.ExecuteReader();

            while (dt.Read())
            {
                label8.Text = Convert.ToString(dt[1]);
                textBox3.Text = Convert.ToString(dt[6]);
                textBox4.Text = Convert.ToString(dt[3]);
                textBox5.Text = Convert.ToString(dt[7]);
                textBox6.Text = Convert.ToString(dt[2]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string n = dataGridView1.SelectedCells[0].Value.ToString();

            int len = n.Length;
            string m = n.Substring(0, 1);
            string m1 = n.Substring(0, len);
            if (m.Equals("A"))
            {
                textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
                label10.Hide();
            }
            else
            {
                MessageBox.Show(dataGridView1.SelectedCells[0].Value.ToString());
                label10.Show();
            }
        }

        private void Update_Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
