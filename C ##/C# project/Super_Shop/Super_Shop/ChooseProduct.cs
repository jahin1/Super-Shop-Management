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
    public partial class ChooseProduct : Form
    {
        DataTable t = new DataTable();
        string table_name_combo;
        string table_name_combo_dlt;
        int dquantity;//delete quantity get
        float discount;    
        float vat;
        string iddd;
        string keeptable_name_combo_dlt;
        string keepcmbo2;
        int max;
        public static float Tcost = 0.0f;
        int a = 0;
        Databasecon d = new Databasecon();
       
        string mobileNo;
        int Rank;
        Order o = new Order();
        int gquantity;
      
        public ChooseProduct()
        {
            InitializeComponent();
        }
        public ChooseProduct(string n)
        {
           
            InitializeComponent();
            label20.Text = n;
            label11.Text = d.AutoOId1();
            iddd = label11.Text;
            label21.Text = "2";
            discount = d.GetDiscount(label20.Text);
            label23.Text = Convert.ToString(discount);
            timer1.Start();
            if (discount > 0)
            {
                label24.Text = label24.Text;
            }
            else
            {

                label24.Hide();

            }
            AutoCompleteText();

        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CLogin c2 = new CLogin();
            c2.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn c3 = new LogIn();
            c3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (label4.Text.Length == 0 || label2.Text.Length == 0)
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                dquantity = d.GetQuantityForDlt(keeptable_name_combo_dlt, keepcmbo2);
                int gquantity1 = dquantity + o.Quantity;
                d.UpdateQuantity(keeptable_name_combo_dlt, keepcmbo2, gquantity1);
                d.GetProfitPerProduct(table_name_combo_dlt, keepcmbo2);
                d.UpdateTotalsellProfita(d.GetSellCostPRofit() - (d.GetProfitPerProduct(table_name_combo_dlt, keepcmbo2) * o.Quantity));

                d.DeleteOrder(label11.Text);
                t.Rows.Clear();
                label17.Text = "0";
                label13.Text = "0";
                Tcost = 0;
            }
           
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label4.Text.Length == 0 || label2.Text.Length == 0)
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {

                string cmbo = comboBox1.Text;
                if (cmbo.Equals("Home Appliances"))
                {
                    this.table_name_combo_dlt = "Home_Appliances";
                }
                else if (cmbo.Equals("Home & Cleaning"))
                {
                    this.table_name_combo_dlt = "Home_clearing";
                }
                else if (cmbo.Equals("Food"))
                {
                    this.table_name_combo_dlt = "Food";
                }
                else if (cmbo.Equals("Office Products"))
                {
                    this.table_name_combo_dlt = "Office_Products";
                }
                else if (cmbo.Equals("Beauty & Health"))
                {
                    this.table_name_combo_dlt = "Beauty_Health";
                }
                else if (cmbo.Equals("Others"))
                {
                    this.table_name_combo_dlt = "Others_Product";
                }
                else
                {
                    MessageBox.Show("Catagory must select first or Product Properly!! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                string cmbo2 = comboBox2.Text;
                keeptable_name_combo_dlt = table_name_combo_dlt;
                keepcmbo2 = cmbo2;

                dquantity = d.GetQuantityForDlt(table_name_combo_dlt, cmbo2);

                o.OId = label11.Text;
                o.CId = label20.Text;
                o.ProductName = comboBox2.Text;
                o.Quantity = Convert.ToInt32(numericUpDown1.Value);

                gquantity = dquantity - o.Quantity;

                d.UpdateQuantity(table_name_combo_dlt, cmbo2, gquantity);
                d.UpdateQuantityInDetails(cmbo2, gquantity);
                o.Price = o.Price;
                o.Cost = Convert.ToSingle(o.Quantity * o.Price);

                o.Status = "Unserved";

                d.InsertO(o.OId, o.CId, o.ProductName, o.Quantity, o.Price, o.Cost, o.Status);
                d.GetProfitPerProduct(table_name_combo_dlt, cmbo2);
                d.UpdateTotalsellProfita(d.GetSellCostPRofit() + (d.GetProfitPerProduct(table_name_combo_dlt, cmbo2) * o.Quantity));
                t.Rows.Clear();
                t.Columns.Clear();
                dataGridView1.DataSource = t;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT productName,price,quantity,cost FROM Orderinfo1 where OId='{0}'", label11.Text);

                SqlCommand s = new SqlCommand(sl, con1);

                SqlDataAdapter dt = new SqlDataAdapter(s);
                dt.Fill(t);
                dataGridView1.DataSource = t;
                // con.Close();
                Tcost += o.Cost;
                label13.Text = Convert.ToString(Tcost);

                discount = d.GetDiscount(label20.Text);

                vat = Convert.ToSingle(label21.Text);
                float th = (Tcost * discount) / 100;
                float th1 = Tcost - th;
                float th2 = (th1 * vat) / 100;
                float th3 = th1 + th2;
                label17.Text = Convert.ToString(th3);


                // comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                numericUpDown1.Value = 0;
                label4.Text = "0";
                label2.Text = "0";
                // label11.Text = d.AutoOId1();

            }


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nm = label20.Text;
            PasswordChange p1 = new PasswordChange(this,nm);

            p1.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ChooseProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ChooseProduct_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float f = Convert.ToInt32(numericUpDown1.Value);
            
            float f1 = Convert.ToSingle(label2.Text);
            label4.Text = Convert.ToString(f*f1);


         //   Tcost = Convert.ToSingle(label4.Text);
           // label13.Text = Convert.ToString(Tcost);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmbo = comboBox1.Text;
            if (cmbo.Equals("Home Appliances"))
            {
                this.table_name_combo = "Home_Appliances";
            }
            else if (cmbo.Equals("Home & Cleaning"))
            {
                this.table_name_combo = "Home_clearing";
            }
            else if (cmbo.Equals("Food"))
            {
                this.table_name_combo = "Food";
            }
            else if (cmbo.Equals("Office Products"))
            {
                this.table_name_combo = "Office_Products";
            }
            else if (cmbo.Equals("Beauty & Health"))
            {
                this.table_name_combo = "Beauty_Health";
            }
            else if (cmbo.Equals("Others"))
            {
                this.table_name_combo = "Others_Product";
            }
            else
            {
                MessageBox.Show("Catagory must select first !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            string cmbo2 = comboBox2.Text;

            o.Price = d.GetPrice(table_name_combo, cmbo2);
            label2.Text =Convert.ToString( o.Price);
            max = d.GetQuantityForDlt(table_name_combo, cmbo2);
            numericUpDown1.Maximum = max;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmbo = comboBox1.Text;
            if (cmbo.Equals("Home Appliances"))
            {
                this.table_name_combo = "Home_Appliances";
            }
            else if (cmbo.Equals("Home & Cleaning"))
            {
                this.table_name_combo = "Home_clearing";
            }
            else if (cmbo.Equals("Food"))
            {
                this.table_name_combo = "Food";
            }
            else if (cmbo.Equals("Office Products"))
            {
                this.table_name_combo = "Office_Products";
            }
            else if (cmbo.Equals("Beauty & Health"))
            {
                this.table_name_combo = "Beauty_Health";
            }
            else if (cmbo.Equals("Others"))
            {
                this.table_name_combo = "Others_Product";
            }
            else
            {
                MessageBox.Show("Catagory must select first !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            SqlConnection cs = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            cs.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM "+table_name_combo+"", cs);
            DataTable dt = new DataTable();
            comboBox2.Items.Clear();
            
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i]["name"]);
            }
          
            numericUpDown1.Value = 0;
            label4.Text = "0";
            label2.Text = "0";
            cs.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label17.Text.Length == 0)
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
              
            mobileNo = d.GetMobile(label20.Text);
            Order o1 = new Order();
            o1.OId = label11.Text;
            o1.CId = label20.Text;
            o1.Cost =Convert.ToSingle( label17.Text);
            o1.MobileNo = mobileNo;
            o1.Status = "unserved";

              d.InsertOrderDetails(o1.OId, o1.CId, o1.Cost, o1.Status, o1.MobileNo);
                // d.UpdateTotalsellProfita(d.GetSellCostPRofit() + Convert.ToSingle(label17.Text));
                numericUpDown1.Value = 0;
                label4.Text = "0";
                label2.Text = "0";
                t.Rows.Clear();
                label17.Text = "0";
                label13.Text = "0";

                Rank = d.GetRank(label20.Text);
                d.UpdateRank(label20.Text, Rank + 1);
            }


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MyCart c = new MyCart(this,label20.Text);
            c.Show();
            this.Hide();
        }

        void AutoCompleteText()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string sp = string.Format("Select * FROM productdetails");
            SqlCommand i = new SqlCommand(sp, con);
            SqlDataReader dt = i.ExecuteReader();
            while (dt.Read())
            {
               
                string name = dt.GetString(1);
                coll.Add(name);


            }
            textBox1.AutoCompleteCustomSource = coll;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            t.Rows.Clear();
            t.Columns.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT name,sellingprice,details FROM productdetails where name='{0}'",textBox1.Text);

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;  
            
            /*float pp = d.GetPriceForSearch(textBox1.Text);
            
                label2.Text =Convert.ToString( pp);

                a++;*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.SelectedCells[0].Value.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // aPToolStripMenuItem.Text =Convert.ToString( DateTime.Now.ToLocalTime()) ;
        }

        private void aPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditProfile ep = new EditProfile(this,label20.Text);
            ep.Show();
            this.Hide();
        }

        private void myShoppingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyCart c = new MyCart(this, label20.Text);
            c.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            EditProfile ep = new EditProfile(this, label20.Text);
            ep.Show();
            this.Hide();
        }
    }
}
