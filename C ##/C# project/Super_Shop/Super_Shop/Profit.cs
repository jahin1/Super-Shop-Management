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
    public partial class Profit : Form
    {
        Admin_Home ah;
        float pro;
        float stor;
        float whole;
        Databasecon db = new Databasecon();

        public Profit()
        {
            InitializeComponent();
        }

        public Profit(Admin_Home ah)
        {
            InitializeComponent();

            this.ah = ah;
            timer1.Start();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From profita ", con);
            SqlDataReader dt = s.ExecuteReader();
           /// db.UpdateWholeProfita(label4.Text, (Convert.ToSingle(label11.Text) + Convert.ToSingle(label6.Text) + Convert.ToSingle(textBox1.Text)) - Convert.ToSingle(label2.Text));

            while (dt.Read())
            {
                label11.Text = Convert.ToString(dt[0]);
                label2.Text = Convert.ToString(dt[1]);
                label6.Text = Convert.ToString(dt[3]);
                label10.Text = Convert.ToString(dt[5]);
                label8.Text = Convert.ToString(dt[4]);
                textBox1.Text = Convert.ToString(dt[2]);

            }
            whole = Convert.ToSingle(label2.Text) - (Convert.ToSingle(label11.Text) + Convert.ToSingle(label6.Text) + Convert.ToSingle(textBox1.Text));
            db.UpdateWholeProfita(whole );

            textBox1.Enabled = false;

            //

            stor = db.GetStorecostPRofit() + Convert.ToSingle(textBox1.Text);

            

          //  db.UpdateProfit(stor, label4.Text, whole);
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand s1 = new SqlCommand("SELECT * From profita ", con1);
            SqlDataReader dt1 = s1.ExecuteReader();

            while (dt1.Read())
            {
                label11.Text = Convert.ToString(dt1[0]);
                label2.Text = Convert.ToString(dt1[1]);
                label6.Text = Convert.ToString(dt1[3]);
                label10.Text = Convert.ToString(dt1[5]);
                label8.Text = Convert.ToString(dt1[4]);
                textBox1.Text = Convert.ToString(dt1[2]);

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Profit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ah.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pro = Convert.ToSingle(label8.Text) - Convert.ToSingle(textBox1.Text);
         
            stor = db.GetStorecostPRofit() + Convert.ToSingle(textBox1.Text);

           // db.UpdateWholeProfita(whole);

            db.UpdateProfit(stor, label4.Text, whole);
            whole = Convert.ToSingle(label2.Text) - (Convert.ToSingle(label11.Text) + Convert.ToSingle(label6.Text) + Convert.ToSingle(textBox1.Text));

            db.UpdateWholeProfita(whole);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From profita ", con);
            SqlDataReader dt = s.ExecuteReader();

            while (dt.Read())
            {
                label11.Text = Convert.ToString(dt[0]);
                label2.Text = Convert.ToString(dt[1]);
                label6.Text = Convert.ToString(dt[3]);
                label10.Text = Convert.ToString(dt[5]);
                label8.Text = Convert.ToString(dt[4]);
                textBox1.Text = Convert.ToString(dt[2]);

            }
            textBox1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Profit_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = checkBox1.CheckState;

            switch (state)
            {
                case CheckState.Checked:
                    {
                        textBox1.Enabled = true;
                        break;
                    }
                case CheckState.Indeterminate:
                case CheckState.Unchecked:
                    {
                        break;
                    }

            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(DateTime.Now.ToLocalTime());
        }
    }
}
