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
    public partial class Registation : MetroFramework.Forms.MetroForm
    {
        Customer u = new Customer();
      /*  public Registation()
        {
            InitializeComponent();
            textBox2.Enabled = false;
        }*/

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Information f = new Information();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CLogin l2 = new CLogin();
            l2.Show();
            this.Hide();
        }

        private void Registation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            CheckState state = checkBox1.CheckState;
            if (textBox3.Text.Equals("Enter Password"))
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                switch (state)
                {
                    case CheckState.Checked:
                        {
                            textBox3.Enabled = true;
                            textBox3.UseSystemPasswordChar = false;
                            break;
                        }
                    case CheckState.Indeterminate:
                    case CheckState.Unchecked:
                        {
                            break;
                        }

                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            CheckState state = checkBox2.CheckState;
            if (textBox4.Text.Equals("Enter Password"))
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                switch (state)
                {
                    case CheckState.Checked:
                        {
                            textBox4.Enabled = true;
                            textBox4.UseSystemPasswordChar = false;
                            break;
                        }
                    case CheckState.Indeterminate:
                    case CheckState.Unchecked:
                        {
                            break;
                        }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {

           /* if (textBox2.Text.Length == 0)
            {
                this.textBox2.ForeColor = System.Drawing.Color.Silver;
                textBox2.Text = "Enter Your User Name";
            }
            else if (textBox2.Text.Equals("Enter Your User Name"))
            {
                this.textBox2.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {

                textBox2.Text = textBox2.Text;
            }*/
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
           /* this.textBox2.ForeColor = System.Drawing.Color.Silver;
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Enter Your User Name";

            }
            else if (textBox2.Text.Equals("Enter Your User Name"))
            {
                this.textBox2.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                this.textBox2.ForeColor = System.Drawing.Color.Black;
                textBox2.Text = textBox2.Text;
            }*/
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* this.textBox2.ForeColor = System.Drawing.Color.Black;
            if (textBox2.Text.Equals("Enter Your User Name"))
            {
                textBox2.Text = "";

            }
            else
            {
                textBox2.Text = textBox2.Text;
            }*/
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            if (textBox1.Text.Length == 0)
            {
             
                textBox1.Text = "Enter Your Name";

            }
            else if (textBox1.Text.Equals("Enter Your Name"))
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
                textBox1.Text = "Enter Your Name";
            }
            else if (textBox1.Text.Equals("Enter Your Name"))
            {
                this.textBox1.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
               
                textBox1.Text = textBox1.Text;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            if (textBox1.Text.Equals("Enter Your Name"))
            {
                textBox1.Text = "";

            }
            else
            {
                textBox1.Text = textBox1.Text;
            }
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {

            if (textBox5.Text.Length == 0)
            {
                this.textBox5.ForeColor = System.Drawing.Color.Silver;
                textBox5.Text = "Enter Valid Mobile No";
            }
            else if (textBox5.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox5.ForeColor = System.Drawing.Color.Silver;
            }
            else if (textBox5.Text.Length == 11)
            {

                string n = textBox5.Text.Substring(2, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox5.Text = textBox5.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Text = "";
                }


            }
            else if (textBox5.Text.Equals("Enter Valid Mobile No"))
            {
                textBox5.Text = "Enter Valid Mobile No";
            }
            else if (textBox5.Text.Length == 14)
            {
                string n = textBox5.Text.Substring(5, 1);
                if (n == "8" || n == "9" || n == "5" || n == "6" || n == "7")
                {
                    textBox5.Text = textBox5.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Text = "";
                }
            }

            else if (textBox5.Text.Length >= 15 || textBox5.Text.Length <= 10)
            {
                MessageBox.Show("Please Enter Valid Mobile No", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Text = "";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox5.ForeColor = System.Drawing.Color.Silver;
            if (textBox5.Text.Length == 0)
            {
                textBox5.Text = "Enter Valid Mobile No";

            }
            else if (textBox5.Text.Equals("Enter Valid Mobile No"))
            {
                this.textBox5.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                this.textBox5.ForeColor = System.Drawing.Color.Black;
                textBox5.Text = textBox5.Text;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox5.ForeColor = System.Drawing.Color.Black;
            if (textBox5.Text.Equals("Enter Valid Mobile No"))
            {
                textBox5.Text = "";

            }
            else
            {
                textBox5.Text = textBox5.Text;
            }
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {

            if (textBox6.Text.Length == 0)
            {
                this.textBox6.ForeColor = System.Drawing.Color.Silver;
                textBox6.Text = "Enter Valid Email";
            }
            else if (textBox6.Text.Equals("Enter Valid Email"))
            {
                this.textBox6.ForeColor = System.Drawing.Color.Silver;
            }
            else if (textBox6.Text.Length >= 10)
            {
                int len = textBox6.Text.Length;
                string n = textBox6.Text.Substring(len - 10, 10);
                if (n.Equals("@gmail.com"))
                {
                    textBox6.Text = textBox6.Text;
                }
                else if (textBox6.Text.Equals("Enter Valid Email"))
                {
                    textBox6.Text = "Enter Valid Email";
                }
                else
                {
                    MessageBox.Show("Please Enter Valid G-mail", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox6.Text = "";
                }


            }          

            else
            {
                MessageBox.Show("Please Enter Valid G-mail", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Text = "";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox6.ForeColor = System.Drawing.Color.Silver;
            if (textBox6.Text.Length == 0)
            {
                textBox6.Text = "Enter Valid Email";

            }
            else if (textBox6.Text.Equals("Enter Valid Email"))
            {
                this.textBox6.ForeColor = System.Drawing.Color.Silver;
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
            if (textBox6.Text.Equals("Enter Valid Email"))
            {
                textBox6.Text = "";

            }
            else
            {
                textBox6.Text = textBox6.Text;
            }
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                this.textBox4.ForeColor = System.Drawing.Color.Silver;
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Enter Password";
            }
            else if (textBox4.Text.Equals("Enter Password"))
            {
                this.textBox4.ForeColor = System.Drawing.Color.Silver;
            }

            else if (textBox4.Text.Equals("Enter Password"))
            {
                if (textBox3.Text.Equals("Enter Password"))
                {
                    if (textBox4.Text.Equals("Enter Password"))
                    {
                        textBox4.Text = textBox4.Text;
                    }
                }
                else if (textBox3.Text.Equals(textBox4.Text))
                {
                    textBox4.UseSystemPasswordChar = false;
                    textBox4.Text = textBox4.Text;
                }
                else
                {
                    MessageBox.Show("Password don't match", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Text = "";
                }

            }
            else
            {
                if (textBox3.Text.Equals(textBox4.Text))
                {
                    textBox4.UseSystemPasswordChar = true;
                    textBox4.Text = textBox4.Text;
                }
                else
                {
                    MessageBox.Show("Password don't match", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Text = "";
                }
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox4.ForeColor = System.Drawing.Color.Silver;
            if (textBox4.Text.Length == 0)
            {
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Enter Password";

            }
            else if (textBox4.Text.Equals("Enter Password"))
            {
                this.textBox4.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                this.textBox4.ForeColor = System.Drawing.Color.Black;
                // textBox6.UseSystemPasswordChar = true;
                textBox4.Text = textBox4.Text;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        
        {
            
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            if (textBox4.Text.Equals("Enter Password"))
            {
                textBox4.Text = "";

            }

            else
            {
                textBox4.UseSystemPasswordChar = true;
                textBox4.Text = textBox4.Text;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            if (textBox3.Text.Equals("Enter Password"))
            {
                textBox3.Text = "";

            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
                textBox3.Text = textBox3.Text;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox3.ForeColor = System.Drawing.Color.Silver;
            if (textBox3.Text.Length == 0)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Enter Password";

            }
            else if (textBox3.Text.Equals("Enter Password"))
            {
                this.textBox3.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                this.textBox3.ForeColor = System.Drawing.Color.Black;
                // textBox6.UseSystemPasswordChar = true;
                textBox3.Text = textBox3.Text;
            }
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {

            if (textBox3.Text.Length == 0)
            {
                this.textBox3.ForeColor = System.Drawing.Color.Silver;
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Enter Password";
            }
            else if (textBox3.Text.Equals("Enter Password"))
            {
                this.textBox3.ForeColor = System.Drawing.Color.Silver;
            }

            else if (textBox3.Text.Equals("Enter Password"))
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = textBox3.Text;

            }

            else
            {
                textBox3.UseSystemPasswordChar = true;
                textBox3.Text = textBox3.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        /* private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } */

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox7.ForeColor = System.Drawing.Color.Silver;
          if (textBox7.Text.Length == 0)
            {
                textBox7.Text = "Enter Your Original Address";

            }
          else if (textBox7.Text.Equals("Enter Your Original Address"))
          {
              this.textBox7.ForeColor = System.Drawing.Color.Silver;
          }
            else
          {
              this.textBox7.ForeColor = System.Drawing.Color.Black;
                textBox7.Text = textBox7.Text;
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

        private void textBox7_MouseLeave(object sender, EventArgs e)
        {
              if (textBox7.Text.Length == 0)
            {
                this.textBox7.ForeColor = System.Drawing.Color.Silver;
                textBox7.Text = "Enter Your Original Address";
            }
            else if (textBox7.Text.Equals("Enter Your Original Address"))
            {
                this.textBox7.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {

                textBox7.Text = textBox7.Text;
            }
        }

        private void Registation_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            u.Name = textBox1.Text;
            u.CId = u.CId;
            u.Password = textBox3.Text;
            u.MobileNo = textBox5.Text;
            u.Email = textBox6.Text;

            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                u.Gender = radioButton1.Text;
            }
            else
            {
                u.Gender = radioButton2.Text;
            }
            u.DateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            u.Address = textBox7.Text;
            u.Counter = 0;
            u.Discount = 0.0f;
            if (textBox1.Text.Length == 0 || textBox1.Text.Equals("Enter Your Name") || textBox3.Text.Length == 0 || textBox3.Text.Equals("Enter Password") || textBox4.Text.Length == 0 || textBox4.Text.Equals("Enter Password") || textBox5.Text.Length == 0 || textBox5.Text.Equals("Enter Valid Mobile No") || textBox6.Text.Length == 0 || textBox6.Text.Equals("Enter Valid Email") || textBox7.Text.Length == 0 || textBox7.Text.Equals("Enter Your Original Address") || dateTimePicker1.Text.Equals(DateTime.Now.ToLongDateString()))
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                SqlCommand s = new SqlCommand("INSERT INTO Customerinfo (userId,name,password,mobileNo,email, gender,DOB,Address,discount,count) values ('" + u.CId + "','" + u.Name + "','" + u.Password + "','" + u.MobileNo + "','" + u.Email + "','" + u.Gender + "','" + u.DateOfBirth + "','" + u.Address + "'," + u.Discount + "," + u.Counter + ")", con);


                if (s.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("successfully Added", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                else
                {
                    MessageBox.Show("Unsuccessfully Added", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

                con.Close();
                Information f = new Information(u, this);
                f.Show();
                this.Hide();
            }
        }

        public Registation()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            textBox2.Text = u.CId;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogIn l2 = new LogIn();
            l2.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
