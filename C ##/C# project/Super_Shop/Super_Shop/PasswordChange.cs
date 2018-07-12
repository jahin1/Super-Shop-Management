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
    public partial class PasswordChange : Form
    {
        Salesman_Home s;
        Admin_Home a;
        ChooseProduct c;
        string nm;
        public PasswordChange(ChooseProduct c,string nm)
        {
            InitializeComponent();
            this.c = c;
            this.nm = nm;
            
        }
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox2.Text;
            b = textBox3.Text;

            if (a.Equals(b))
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand s1 = new SqlCommand("SELECT * FROM Customerinfo where userId = '" + nm + "' and password = '" + textBox1.Text + "'", con);
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
                    if (a.Equals(b) && a.Length > 0)
                    {
                        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                        con2.Open();
                        SqlCommand s = new SqlCommand("UPDATE Customerinfo SET  password = '" + textBox2.Text + "' where userId = '" + nm + "'", con2);
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
                    MessageBox.Show("Wrong Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Wrong Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //MessageBox.Show("Save Changes","Done",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);


            }
        }
       
        private void PasswordChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Salesman_Home p = new Salesman_Home(this);
            c.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PasswordChange_Load(object sender, EventArgs e)
        {

        }
    }
}
