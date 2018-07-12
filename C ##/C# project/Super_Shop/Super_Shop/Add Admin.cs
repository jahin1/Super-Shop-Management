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
    public partial class Add_Admin : Form
    {
        Databasecon cn = new Databasecon();

        Admin aa = new Admin();
        Admin_Home a;

        public Add_Admin(Admin_Home a)
        {
            InitializeComponent();
            label11.Text = aa.AID;
            this.a = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Home a = new Admin_Home();
            a.Show();
            this.Hide();
            
        }

        private void Add_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox5.Text.Length == 0 || textBox4.Text.Length == 0 || textBox4.Text.Equals("Enter Valid Email") || textBox3.Text.Length == 0 || textBox3.Text.Equals("Enter Valid Mobile No") || textBox7.Text.Length == 0 || textBox7.Text.Equals("Enter Your Original Address") || dateTimePicker1.Text.Equals(DateTime.Now.ToLongDateString()))
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                aa.AID = aa.AID;
                aa.Name = textBox1.Text;
                aa.Password = textBox5.Text;
                aa.Email = textBox4.Text;
                aa.MobileNo = textBox3.Text;
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                {
                    aa.Gender = radioButton1.Text;
                }
                else
                {
                    aa.Gender = radioButton2.Text;
                }
                aa.DateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                aa.Address = textBox7.Text;

                


                cn.Insert(aa.AID, aa.Name, aa.Password, aa.Email, aa.DateOfBirth, aa.Gender, aa.MobileNo, aa.Address);
                a.Show();
                this.Hide();
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          //  Admin_Home a = new Admin_Home();
            a.Show();
            this.Hide();
        }



        private void Add_Admin_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                this.textBox3.ForeColor = System.Drawing.Color.BlueViolet;
                textBox3.Text = "Enter Valid Mobile No";
            }
            else if (textBox3.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox3.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else if (textBox3.Text.Length == 11)
            {

                string n = textBox3.Text.Substring(2, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox3.Text = textBox3.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Text = "";
                }


            }
            else if (textBox3.Text.Equals("Enter Valid Mobile No"))
            {
                textBox3.Text = "Enter Valid Mobile No";
            }
            else if (textBox3.Text.Length == 14)
            {
                string n = textBox3.Text.Substring(5, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox3.Text = textBox3.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Text = "";
                }
            }

            else if (textBox3.Text.Length >= 15 || textBox3.Text.Length <= 10)
            {
                MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = "";
            }
        }

        private void textBox7_MouseLeave(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0)
            {
                this.textBox7.ForeColor = System.Drawing.Color.BlueViolet;
                textBox7.Text = "Enter Your Original Address";
            }
            else if (textBox7.Text.Equals("Enter Your Original Address"))
            {
                this.textBox7.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else
            {

                textBox7.Text = textBox7.Text;
            }
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                this.textBox4.ForeColor = System.Drawing.Color.BlueViolet;
                textBox4.Text = "Enter Valid Email";
            }
            else if (textBox4.Text.Equals("Enter Valid Email"))
            {
                this.textBox4.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else if (textBox4.Text.Length >= 10)
            {
                int len = textBox4.Text.Length;
                string n = textBox4.Text.Substring(len - 10, 10);
                if (n.Equals("@gmail.com"))
                {
                    textBox4.Text = textBox4.Text;
                }
                else if (textBox4.Text.Equals("Enter Valid Email"))
                {
                    textBox4.Text = "Enter Valid Email";
                }
                else
                {
                    MessageBox.Show("Please Enter Valid G-mail", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Text = "";
                }


            }

            else
            {
                MessageBox.Show("Please Enter Valid G-mail", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "";
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox7.ForeColor = System.Drawing.Color.Black;
            if (textBox7.Text.Equals("Enter Your Original Address"))
            {
                textBox7.Text = "";

            }
            else
            {
                textBox7.Text = textBox7.Text;
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox7.ForeColor = System.Drawing.Color.BlueViolet;
            if (textBox7.Text.Length == 0)
            {
                textBox7.Text = "Enter Your Original Address";

            }
            else if (textBox7.Text.Equals("Enter Your Original Address"))
            {
                this.textBox7.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else
            {
                this.textBox7.ForeColor = System.Drawing.Color.BlueViolet;
                textBox7.Text = textBox7.Text;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {

            this.textBox3.ForeColor = System.Drawing.Color.BlueViolet;
            if (textBox3.Text.Length == 0)
            {
                textBox3.Text = "Enter Valid Mobile No";

            }
            else if (textBox3.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox3.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else
            {
                this.textBox3.ForeColor = System.Drawing.Color.Black;
                textBox3.Text = textBox3.Text;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            this.textBox3.ForeColor = System.Drawing.Color.Black;
            if (textBox3.Text.Equals("Enter Valid Mobile No"))
            {
                textBox3.Text = "";

            }
            else
            {
                textBox3.Text = textBox3.Text;
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox4.ForeColor = System.Drawing.Color.BlueViolet;
            if (textBox4.Text.Length == 0)
            {
                textBox4.Text = "Enter Valid Email";

            }
            else if (textBox4.Text.Equals("Enter Valid Email"))
            {
                this.textBox4.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else
            {
                this.textBox4.ForeColor = System.Drawing.Color.BlueViolet;
                textBox4.Text = textBox4.Text;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            this.textBox4.ForeColor = System.Drawing.Color.Black;
            if (textBox4.Text.Equals("Enter Valid Email"))
            {
                textBox4.Text = "";

            }
            else
            {
                textBox4.Text = textBox4.Text;
            }
        }
    }
}
