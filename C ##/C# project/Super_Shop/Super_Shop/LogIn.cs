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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
           // textBox1.Text = "S-1000-1";
           // textBox2.Text = "2";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string identi = textBox1.Text;
            int l=textBox1.Text.Length;
            int l1 = textBox2.Text.Length;

            if (l == 5 || l == 6 || l == 7)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();           
                SqlCommand s1 = new SqlCommand("SELECT * FROM Customerinfo where userId = '" + textBox1.Text + "' and password = '"+textBox2.Text+"'", con);
                SqlDataReader dt;
                dt=s1.ExecuteReader();
                int c =0;

                  while (dt.Read())
                   {
                      c+=1;
                  }
                   if (c==1)
                     {
                         ChooseProduct cp = new ChooseProduct(identi);
                           cp.Show();
                           this.Hide();
                      }
                       else if (c > 0)
                       {
                           MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       }
                       else
                       {
                           MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       }
                   textBox1.Text = textBox1.Text;
                       textBox2.Clear();
                   }
            
            else if(l == 8 || l == 9 || l==10||l==11)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();           
                SqlCommand s1 = new SqlCommand("SELECT * FROM Salesmaninfo where SId = '" + textBox1.Text + "' and password = '"+textBox2.Text+"'", con);
                SqlDataReader dt;
                dt=s1.ExecuteReader();
                int c =0;

                  while (dt.Read())
                   {
                      c+=1;
                  }
                   if (c==1)
                     {
                         Salesman_Home sh = new Salesman_Home(identi);
                    sh.Show();
                    this.Hide();
                      }
                       else if (c > 0)
                       {
                           MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       }
                       else
                       {
                           MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       }
                      textBox1.Text = textBox1.Text;
                       textBox2.Clear();
            }
            else if (l == 2 || l == 3 || l == 4 )
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand s1 = new SqlCommand("SELECT * FROM Admininfo where AId = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
                SqlDataReader dt;
                dt = s1.ExecuteReader();
                int c = 0;

                while (dt.Read())
                {
                    c += 1;
                }
                if (c == 1)
                {
                    Admin_Home ah = new Admin_Home(identi);
                    ah.Show();
                    this.Hide();
                }
                else if (c > 0)
                {
                    MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                textBox1.Text = textBox1.Text;
                textBox2.Clear();
            }

            else
            {
             MessageBox.Show("Wrong User Id or password", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
            }
            /*if (textBox1.Text.Equals("A"))
            {
                if (textBox2.Text.Equals("A"))
                {
                    Admin_Home ah = new Admin_Home();
                    ah.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid User Id or password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox1.Text.Equals("S"))
            {

                if (textBox2.Text.Equals("S"))
                {
                    Salesman_Home sh = new Salesman_Home();
                    sh.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid User Id or password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
                MessageBox.Show("Invalid User Id or password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
            */
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            CheckState state = checkBox1.CheckState;
            switch (state)
            {
                case CheckState.Checked:
                    {
                        textBox2.Enabled = true;
                        textBox2.UseSystemPasswordChar = false;
                        break;
                    }
                case CheckState.Indeterminate:
                case CheckState.Unchecked:
                    {
                        break;
                    }
            }
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registation r = new Registation();
            r.Show();
            this.Hide();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
