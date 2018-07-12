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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Super_Shop
{
    public partial class Salesman_Home : Form
    {
        PasswordChange p;
        Databasecon d = new Databasecon();
        //

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
        string cmbo2;
        string mobileNo;
        int Rank;
        Order o = new Order();
        int gquantity;
        //
        public Salesman_Home()
        {
            InitializeComponent();
        }
        public Salesman_Home(PasswordChange p)
        {
            InitializeComponent();
            this.p = p;
           
        }
        public Salesman_Home( string nm)
        {
            InitializeComponent();
      
            label28.Text = nm;
        }


        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn l = new LogIn();
            l.Show();
            this.Hide();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information f1 = new Information();
            f1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (label3.Text.Length == 0 || label2.Text.Length == 0)
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


                o.ProductName = comboBox2.Text;
                o.Quantity = Convert.ToInt32(numericUpDown1.Value);

                gquantity = dquantity - o.Quantity;

                d.UpdateQuantity(table_name_combo_dlt, cmbo2, gquantity);
                d.UpdateQuantityInDetails(cmbo2, gquantity);
                o.Price = o.Price;
                o.Cost = Convert.ToSingle(o.Quantity * o.Price);


                d.InsertBill(o.ProductName, o.Price, o.Quantity, o.Cost);
                // d.InsertO(o.OId, o.CId, o.ProductName, o.Quantity, o.Price, o.Cost, o.Status);
                d.UpdateTotalsellProfita(d.GetSellCostPRofit() + (d.GetProfitPerProduct(table_name_combo_dlt, cmbo2) * o.Quantity));

                t.Rows.Clear();
                t.Columns.Clear();
                dataGridView1.DataSource = t;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT name,price,quantity,totalprice FROM salesmanbill1");

                SqlCommand s = new SqlCommand(sl, con1);

                SqlDataAdapter dt = new SqlDataAdapter(s);
                dt.Fill(t);
                dataGridView1.DataSource = t;
                // con.Close();
                Tcost += o.Cost;
                label13.Text = Convert.ToString(Tcost);




                // comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                numericUpDown1.Value = 0;
                label3.Text = "0";
                label2.Text = "0";
                // label11.Text = d.AutoOId1();


            }
     
           
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nm = label28.Text;
            PasswordChangeS p3 = new PasswordChangeS(this,nm);
            p3.Show();
            this.Hide();
        }

        private void Salesman_Home_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void homeDelivaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeDelivary hm = new HomeDelivary(this, label28.Text);
            hm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (label13.Text.Length == 0 )
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {//d.UpdateTotalsellProfita(d.GetSellCostPRofit() + Convert.ToSingle(label13.Text));

                //normal
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
                doc.Open();

                Paragraph paragraph = new Paragraph("                                                                               SuperShop");

                Paragraph paragraph1 = new Paragraph("                                                               House #30, Sonargaon Janapath, Sector# 09");
                Paragraph paragraph2 = new Paragraph("                                                               Uttara Model Town,Uttara,Dhaka-1203.");
                Paragraph paragraph3 = new Paragraph("                                                               \n");
                doc.Add(paragraph);
                doc.Add(paragraph1);
                doc.Add(paragraph2);
                doc.Add(paragraph3);
                // doc.Close();

                //data grid view
                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));

                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }
                    }

                }

                doc.Add(table);
                // Paragraph paragraph4 = new Paragraph("                                                               \n");
                doc.Add(paragraph3);
                Paragraph para = new Paragraph("                                                          " + label12.Text + "  " + label13.Text);
                doc.Add(para);
                Paragraph paragraph5 = new Paragraph(" \n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                doc.Add(paragraph5);
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("barcode4.png");//image add
                PNG.SetAbsolutePosition(doc.PageSize.Width - 36f - 360f, doc.PageSize.Height - 36f - 600.6f);//resize
                doc.Add(PNG);

                Paragraph paragraph6 = new Paragraph(" \n");
                doc.Add(paragraph6);
                Paragraph paragraph7 = new Paragraph(" \n");
                doc.Add(paragraph7);

                Paragraph para1 = new Paragraph(@"                                                                                                                                                                                       
            
            
            
            ");
                doc.Add(para1);
                //textbox

                //  para.Alignment = Element.ALIGN_CENTER;

                //  Paragraph par = new Paragraph(label3.Text);
                // doc.Add(par);

                Paragraph paragraph4 = new Paragraph(@"                                               Thank you for purchasing.Save money,Live better.......");
                doc.Add(paragraph4);
                doc.Close();
                System.Diagnostics.Process.Start("Test.pdf");
                ///
                d.DeleteSalesmanBill();
                t.Rows.Clear();
                label13.Text = "0";
                Tcost = 0;
            }  

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
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + table_name_combo + "", cs);
            DataTable dt = new DataTable();
            comboBox2.Items.Clear();

            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i]["name"]);
            }

            numericUpDown1.Value = 0;
            label3.Text = "0";
            label2.Text = "0";
            cs.Close();
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
            label3.Text = Convert.ToString(o.Price);
            max = d.GetQuantityForDlt(table_name_combo, cmbo2);
            numericUpDown1.Maximum = max;

        }

        private void Salesman_Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float f = Convert.ToInt32(numericUpDown1.Value);

            float f1 = Convert.ToSingle(label3.Text);
            label2.Text = Convert.ToString(f * f1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (label3.Text.Length == 0 || label2.Text.Length == 0)
            {
                MessageBox.Show("Fill all The Field !! ", "OK ??", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                dquantity = d.GetQuantityForDlt(keeptable_name_combo_dlt, keepcmbo2);
                int gquantity1 = dquantity + o.Quantity;
                d.UpdateQuantity(keeptable_name_combo_dlt, keepcmbo2, gquantity1);
                d.UpdateTotalsellProfita(d.GetSellCostPRofit() - (d.GetProfitPerProduct(table_name_combo_dlt, cmbo2) * o.Quantity));

                // d.DeleteOrder(label11.Text);
                d.DeleteSalesmanBill();
                t.Rows.Clear();
                label13.Text = "0";
                Tcost = 0;
            }
        }

        private void homeServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeDelivary hm = new HomeDelivary(this, label28.Text);
            hm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            //button2.BackColor= Color.Red;
        }

        private void button2_BackColorChanged(object sender, EventArgs e)
        {
            //button2.BackColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeDelivary hm = new HomeDelivary(this, label28.Text);
            hm.Show();
            this.Hide();
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }
    }
}
