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
    public partial class EditProfile : Form
    {
        ChooseProduct p;
        Databasecon db = new Databasecon();
        string m;
        public EditProfile()
        {
            InitializeComponent();
        }
        public EditProfile(ChooseProduct p,string m)
        {
            InitializeComponent();
            this.p = p;
            this.m = m;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From Customerinfo where userId='" + m + "'", con);
            SqlDataReader dt = s.ExecuteReader();

            while (dt.Read())
            {
                label14.Text = Convert.ToString(dt["name"]);
                label13.Text = Convert.ToString(dt["userId"]);
                textBox1.Text = Convert.ToString(dt["mobileNo"]);
                textBox2.Text = Convert.ToString(dt["email"]);
                textBox3.Text = Convert.ToString(dt["Address"]);
                label4.Text = Convert.ToString(dt["DOB"]);
                label10.Text = Convert.ToString(dt["gender"]);
                label3.Text = Convert.ToString(dt["discount"]);


            }

        }
        private void EditProfile_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text.Equals("Enter Valid Mobile No") || textBox2.Text.Length == 0 || textBox2.Text.Equals("Enter Valid Email") || textBox3.Text.Length == 0 || textBox3.Text.Equals("Enter Your Original Address"))
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand s = new SqlCommand("SELECT * From Customerinfo where userId='" + label13.Text + "'", con);
                SqlDataReader dt = s.ExecuteReader();

                while (dt.Read())
                {
                    label14.Text = Convert.ToString(dt["name"]);
                    label13.Text = Convert.ToString(dt["userId"]);
                    textBox1.Text = Convert.ToString(dt["mobileNo"]);
                    textBox2.Text = Convert.ToString(dt["email"]);
                    textBox3.Text = Convert.ToString(dt["Address"]);
                    label4.Text = Convert.ToString(dt["DOB"]);
                    label10.Text = Convert.ToString(dt["gender"]);
                    label3.Text = Convert.ToString(dt["discount"]);


                }
                con.Close();
            }
            else
            {
                db.UpdateCustomerInfo(textBox1.Text, textBox2.Text, textBox3.Text, m);

                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();
                SqlCommand s = new SqlCommand("SELECT * From Customerinfo where userId='" + label13.Text + "'", con1);
                SqlDataReader dt = s.ExecuteReader();

                while (dt.Read())
                {
                    label14.Text = Convert.ToString(dt["name"]);
                    label13.Text = Convert.ToString(dt["userId"]);
                    textBox1.Text = Convert.ToString(dt["mobileNo"]);
                    textBox2.Text = Convert.ToString(dt["email"]);
                    textBox3.Text = Convert.ToString(dt["Address"]);
                    label4.Text = Convert.ToString(dt["DOB"]);
                    label10.Text = Convert.ToString(dt["gender"]);
                    label3.Text = Convert.ToString(dt["discount"]);


                }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Enter Valid Mobile No";

            }
            else if (textBox1.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox1.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                this.textBox1.ForeColor = System.Drawing.Color.Black;
                textBox1.Text = textBox1.Text;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                this.textBox1.ForeColor = System.Drawing.Color.Silver;
                textBox1.Text = "Enter Valid Mobile No";
            }
            else if (textBox1.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox1.ForeColor = System.Drawing.Color.Silver;
            }
            else if (textBox1.Text.Length == 11)
            {

                string n = textBox1.Text.Substring(2, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox1.Text = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                }


            }
            else if (textBox1.Text.Equals("Enter Valid Mobile No"))
            {
                textBox1.Text = "Enter Valid Mobile No";
            }
            else if (textBox1.Text.Length == 14)
            {
                string n = textBox1.Text.Substring(5, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox1.Text = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                }
            }

            else if (textBox1.Text.Length >= 15 || textBox1.Text.Length <= 10)
            {
                MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            if (textBox1.Text.Equals("Enter Valid Mobile No"))
            {
                textBox1.Text = "";

            }
            else
            {
                textBox1.Text = textBox1.Text;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {


            if (textBox2.Text.Length == 0)
            {
                this.textBox2.ForeColor = System.Drawing.Color.Silver;
                textBox2.Text = "Enter Valid Email";
            }
            else if (textBox2.Text.Equals("Enter Valid Email"))
            {
                this.textBox2.ForeColor = System.Drawing.Color.Silver;
            }
            else if (textBox2.Text.Length >= 10)
            {
                int len = textBox2.Text.Length;
                string n = textBox2.Text.Substring(len - 10, 10);
                if (n.Equals("@gmail.com"))
                {
                    textBox2.Text = textBox2.Text;
                }
                else if (textBox2.Text.Equals("Enter Valid Email"))
                {
                    textBox2.Text = "Enter Valid Email";
                }
                else
                {
                    MessageBox.Show("Please Enter Valid G-mail", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                }


            }

            else
            {
                MessageBox.Show("Please Enter Valid G-mail", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Enter Valid Email";

            }
            else if (textBox2.Text.Equals("Enter Valid Email"))
            {
                this.textBox2.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                this.textBox2.ForeColor = System.Drawing.Color.Black;
                textBox2.Text = textBox2.Text;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            if (textBox2.Text.Equals("Enter Valid Email"))
            {
                textBox2.Text = "";

            }
            else
            {
                textBox2.Text = textBox2.Text;
            }
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {

            if (textBox3.Text.Length == 0)
            {
                this.textBox3.ForeColor = System.Drawing.Color.Silver;
                textBox3.Text = "Enter Your Original Address";
            }
            else if (textBox3.Text.Equals("Enter Your Original Address"))
            {
                this.textBox3.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {

                textBox3.Text = textBox3.Text;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {

            this.textBox3.ForeColor = System.Drawing.Color.Silver;
            if (textBox3.Text.Length == 0)
            {
                textBox3.Text = "Enter Your Original Address";

            }
            else if (textBox3.Text.Equals("Enter Your Original Address"))
            {
                this.textBox3.ForeColor = System.Drawing.Color.Silver;
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
            if (textBox3.Text.Equals("Enter Your Original Address"))
            {
                textBox3.Text = "";

            }
            else
            {
                textBox3.Text = textBox3.Text;
            }
        }

        private void EditProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
