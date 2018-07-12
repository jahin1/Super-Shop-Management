using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop
{
    public partial class Information : Form
    {
        Customer u; Registation g;
        public Information()
        {
            InitializeComponent();
        }
        public Information(Customer u, Registation g)
        {
            this.g = g;
            InitializeComponent();
            this.u = u;

            label14.Text = u.Name;
            label13.Text = u.CId;
           // label13.Text = u.Password;
            label12.Text = u.MobileNo;
            label11.Text = u.Email;
            label10.Text = u.Gender;
            label4.Text = u.DateOfBirth;
           
            label3.Text = u.Address;

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLogin l1 = new CLogin();
            l1.Show();
            this.Hide();
        }

        private void Information_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            LogIn l2 = new LogIn();
            l2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LogIn l = new LogIn();
            l.Show();
            this.Hide();
        }
    }
}
