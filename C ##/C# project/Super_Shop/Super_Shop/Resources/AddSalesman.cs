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
    public partial class AddSalesman : Form
    {
        Salesman ss = new Salesman();
        Admin_Home a1;
        Databasecon db = new Databasecon();
        public AddSalesman(Admin_Home a1)
        {
            InitializeComponent();


            label11.Text = ss.SId;
            this.a1 = a1;
        }
        private void AddSalesman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Home a1 = new Admin_Home();
            a1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Admin_Home a1 = new Admin_Home();
            a1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || textBox5.Text.Length == 0 || textBox4.Text.Length == 0 || dateTimePicker1.Text.Equals(DateTime.Now.ToLongDateString()))
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                ss.SId = ss.SId;
                ss.Name = textBox1.Text;

                ss.Password = textBox5.Text;
                ss.MobileNo = textBox6.Text;
                ss.Email = textBox4.Text;

                bool isChecked = radioButton1.Checked;
                if (isChecked)
                {
                    ss.Gender = radioButton1.Text;
                }
                else
                {
                    ss.Gender = radioButton2.Text;
                }
                ss.DateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                ss.Address = textBox7.Text;
                ss.Salary = Convert.ToSingle(textBox3.Text);
                ss.SalaryStatus = "Unpaid";
                ss.PaidDate = "- - -";
                ss.Totalsalary = Convert.ToSingle("0");

                db.InsertSalesman(ss.SId, ss.Name, ss.Password, ss.Email, ss.DateOfBirth, ss.Gender, ss.MobileNo, ss.Address, ss.Salary, ss.SalaryStatus, ss.PaidDate, ss.Totalsalary);

                a1.Show();
                this.Hide();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

       

        private void AddSalesman_Load(object sender, EventArgs e)
        {

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

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                this.textBox6.ForeColor = System.Drawing.Color.BlueViolet;
                textBox6.Text = "Enter Valid Mobile No";
            }
            else if (textBox6.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox6.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else if (textBox6.Text.Length == 11)
            {

                string n = textBox6.Text.Substring(2, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox6.Text = textBox6.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox6.Text = "";
                }


            }
            else if (textBox6.Text.Equals("Enter Valid Mobile No"))
            {
                textBox6.Text = "Enter Valid Mobile No";
            }
            else if (textBox6.Text.Length == 14)
            {
                string n = textBox6.Text.Substring(5, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox6.Text = textBox6.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox6.Text = "";
                }
            }

            else if (textBox6.Text.Length >= 15 || textBox6.Text.Length <= 10)
            {
                MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Text = "";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {

            this.textBox6.ForeColor = System.Drawing.Color.BlueViolet;
            if (textBox6.Text.Length == 0)
            {
                textBox6.Text = "Enter Valid Mobile No";

            }
            else if (textBox6.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox6.ForeColor = System.Drawing.Color.BlueViolet;
            }
            else
            {
                this.textBox6.ForeColor = System.Drawing.Color.Black;
                textBox6.Text = textBox6.Text;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            this.textBox6.ForeColor = System.Drawing.Color.Black;
            if (textBox6.Text.Equals("Enter Valid Mobile No"))
            {
                textBox6.Text = "";

            }
            else
            {
                textBox6.Text = textBox6.Text;
            }
        }
    }
}
