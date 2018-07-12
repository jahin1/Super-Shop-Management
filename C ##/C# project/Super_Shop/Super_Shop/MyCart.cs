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
    public partial class MyCart : Form
    {
        ChooseProduct cp;
        DataTable t = new DataTable();
        public MyCart()
        {
            
            InitializeComponent();
        }
        public MyCart(ChooseProduct cp,string m)
        {

            InitializeComponent();
            this.cp = cp;

            t.Rows.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT * FROM Orderinfo1 where CId='{0}'",m);

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
        }

        private void MyCart_Load(object sender, EventArgs e)
        {

        }

        private void MyCart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cp.Show();
            this.Hide();
        }
    }
}
