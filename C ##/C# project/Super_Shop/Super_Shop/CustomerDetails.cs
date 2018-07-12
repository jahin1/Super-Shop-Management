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
    public partial class CustomerDetails : Form
    {
        Admin_Home aa;
        DataTable t = new DataTable();
        public static int c = 0;
        Databasecon dt = new Databasecon();
        int cc;

        public CustomerDetails()
        {
            InitializeComponent();

        }    
        public CustomerDetails(Admin_Home aa)
        {
            InitializeComponent();
            this.aa = aa;


            t.Rows.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT userId,name,mobileNo,discount,count FROM Customerinfo");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
            t.DefaultView.Sort = "count asc";
            t = t.DefaultView.ToTable(true);
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Admin_Home aa = new Admin_Home();
            aa.Show();
            this.Hide();
        }

        private void CustomerDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            string n = dataGridView1.SelectedCells[0].Value.ToString();

            int len = n.Length;
            string m = n.Substring(1, 1);
            string m1 = n.Substring(0, len);
            if (m.Equals("-"))
            {
                label5.Hide();
                c++;
               label8.Text = dataGridView1.SelectedCells[0].Value.ToString();
            }
        
            else
            {
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c > 0)
            {
                timer1.Start();
                cc = dt.UpdateDiscount(label8.Text, textBox5.Text);
                
            }
            else
            {
                label5.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                progressBar1.Value = 0;
                if (cc == 1)
                {

                    t.Rows.Clear();
                    dataGridView1.DataSource = t;
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                    con1.Open();

                    string sl = string.Format("SELECT userId,name,mobileNo,discount,count FROM Customerinfo");

                    SqlCommand s = new SqlCommand(sl, con1);

                    SqlDataAdapter dt = new SqlDataAdapter(s);
                    dt.Fill(t);
                    dataGridView1.DataSource = t;

                    MessageBox.Show("Discount Updated successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {

                    MessageBox.Show("Discount no updated", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            else
            {

                progressBar1.Value++;

            }
        }
    }
}
