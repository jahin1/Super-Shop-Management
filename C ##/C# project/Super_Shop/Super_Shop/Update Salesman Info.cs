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
    public partial class Update_Salesman_Info : Form
    {
        Admin_Home a2;
        Databasecon db = new Databasecon();
        DataTable t = new DataTable();
        public Update_Salesman_Info(Admin_Home a2)
        {
            InitializeComponent();
            this.a2 = a2;
            AutoCompleteText();
            t.Rows.Clear();
            t.Columns.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT SId,name,email,mobileNo,address,salary FROM Salesmaninfo");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
            label10.Hide();
        }
        public Update_Salesman_Info()
        {
            InitializeComponent();
            
        }

        private void Update_Salesman_Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Admin_Home a2 = new Admin_Home();
            a2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From Salesmaninfo where SId='" + textBox1.Text + "'", con);
            SqlDataReader dt = s.ExecuteReader();

            while (dt.Read())
            {
                label8.Text = Convert.ToString(dt[1]);
                textBox3.Text = Convert.ToString(dt[6]);
                textBox4.Text = Convert.ToString(dt[3]);
                textBox5.Text = Convert.ToString(dt[7]);
                textBox2.Text = Convert.ToString(dt[8]);
                textBox6.Text = Convert.ToString(dt[2]);


            }
        }

        private void Back_Click_1(object sender, EventArgs e)
        {

           // Admin_Home a2 = new Admin_Home();
            a2.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0 || textBox6.Text.Length == 0 || textBox5.Text.Length == 0 || textBox4.Text.Length == 0 || textBox3.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {


                db.UpdateSalesman(textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToSingle(textBox2.Text), textBox1.Text, textBox6.Text);
                t.Rows.Clear();
                t.Columns.Clear();
                dataGridView1.DataSource = t;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT SId,name,email,mobileNo,address,salary FROM Salesmaninfo");

                SqlCommand s = new SqlCommand(sl, con1);

                SqlDataAdapter dt = new SqlDataAdapter(s);
                dt.Fill(t);
                dataGridView1.DataSource = t;
            }
        }

        private void Update_Salesman_Info_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             string n = dataGridView1.SelectedCells[0].Value.ToString();
            
            int len=n.Length;
            string m=n.Substring(1,1);
            string m1 = n.Substring(0,len);
            if (m.Equals("-"))
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
