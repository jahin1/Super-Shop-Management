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
    public partial class PasswordChangeA : Form
    {
        Admin_Home a;
        string nm;
        public PasswordChangeA()
        {
            InitializeComponent();
        }
        public PasswordChangeA(  Admin_Home a,string nm)
        {
            InitializeComponent();
            this.a = a;
            this.nm = nm;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string ab, b;
            ab = textBox2.Text;
            b = textBox3.Text;


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
                SqlCommand s1 = new SqlCommand("SELECT * FROM Admininfo where AId = '" + nm + "' and password = '" + textBox1.Text + "'", con);
                SqlDataReader dt;
                dt = s1.ExecuteReader();
                int c = 0;
                while (dt.Read())
                {
                    c += 1;
                }
                con.Close();
                if (c == 1)
                {
                    if (ab.Equals(b) && ab.Length > 0)
                    {
                        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                        con2.Open();
                        SqlCommand s = new SqlCommand("UPDATE Admininfo SET  password = '" + textBox2.Text + "' where AId = '" + nm + "'", con2);
                        if (s.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Successfully Saved");                      
                        }
                        else
                            MessageBox.Show("Error");
                        con2.Close();
                    }
                      else
            {
                MessageBox.Show("Password don't Match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

                }

                else if (c > 0)
                {
                    MessageBox.Show("Wrong current Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Wrong current Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.Show();
            this.Hide();
        }

        private void PasswordChangeA_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PasswordChangeA_Load(object sender, EventArgs e)
        {

        }
    }
}
