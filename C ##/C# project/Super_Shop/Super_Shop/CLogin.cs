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
    public partial class CLogin : Form
    {
        DataTable t = new DataTable();

        public CLogin()
        {
            InitializeComponent();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registation r = new Registation();
            r.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogIn ll = new LogIn();
            ll.Show();
            this.Hide();

        }

        private void CLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
                string identi = textBox1.Text;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jahin\Documents\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
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
                  

            
           
        }
    }

