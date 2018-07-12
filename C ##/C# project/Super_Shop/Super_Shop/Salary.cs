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
    public partial class Salary : Form
    {
        Admin_Home ah;
        Databasecon db = new Databasecon();
        DataTable t = new DataTable();
        public Salary()
        {
            InitializeComponent();
        }
        public Salary(Admin_Home ah)
        {
            InitializeComponent();
            this.ah = ah;
            timer1.Start();

            t.Rows.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT SId,salary,salarystatus,paiddate FROM Salesmaninfo");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
           // t.DefaultView.Sort = "count asc";
            t = t.DefaultView.ToTable(true);
            label10.Hide();
            
        }
        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ah.Show();
            this.Hide();
        }

        private void Salary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string n = dataGridView1.SelectedCells[0].Value.ToString();

            int len = n.Length;
            string m = n.Substring(1, 1);
            string m1 = n.Substring(0, len);
            if (m.Equals("-"))
            {
                label10.Hide();
                label11.Text = dataGridView1.SelectedCells[0].Value.ToString();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand s = new SqlCommand("SELECT * From Salesmaninfo where SId='" + label11.Text + "'", con);
                SqlDataReader dt = s.ExecuteReader();

                while (dt.Read())
                {
                    label5.Text = Convert.ToString(dt[10]);
                    label7.Text = Convert.ToString(dt[8]);
                    label3.Text = Convert.ToString(dt[8]);
                  //  label8.Text = Convert.ToString(dt[7]);
                 //   label8.Text = Convert.ToString(dt[8]);
                 


                }
                
            }
            else
            {
                MessageBox.Show(dataGridView1.SelectedCells[0].Value.ToString());
                label10.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = Convert.ToString(DateTime.Now.ToLocalTime());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float p=db.GetSalaryTotal(label11.Text);
            db.UpdateSalary(label11.Text, Convert.ToSingle(label3.Text), p + Convert.ToSingle(label3.Text), label8.Text);
            t.Rows.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT SId,salary,salarystatus,paiddate,totalsalary FROM Salesmaninfo");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
            // t.DefaultView.Sort = "count asc";
            t = t.DefaultView.ToTable(true);

            db.UpdateSalaryProfita(db.GetSalaryPRofit() + Convert.ToSingle(label7.Text));

        }
    }
}
