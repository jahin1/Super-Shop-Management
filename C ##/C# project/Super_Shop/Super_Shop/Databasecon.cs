using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop
{
    class Databasecon
    {
        float p; //price return
        float dis;// discount return
        string mobileno;// mobileno return
        int quantity;// quantity return dlt
        int quantity1;// quantity return for update
        int Rank;//rank return
        float sal;//get salary
        float store;//get store cost for profit
        float invest;//get invest for profit
        float salll;//get salary for profit
        float sold;//get total sellcost for profit
        float profit;//get profit per product
        //admin
        private string aId;
        private string aP = "A";

        //order

        private string oId;
        private string oP = "O-1-";

        //product
        private string pId;
        private string pP = "P-P-";

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");

        public Databasecon()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }

        //insert Admin
        public void Insert(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            con.Open();

            SqlCommand s = new SqlCommand("INSERT INTO Admininfo (AId,name,password,email,DOB,gender,mobileNo,address) values ('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "')", con);


            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successfully Added Salesman", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {

                MessageBox.Show("Unsuccessfully Added", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

        //insert order
        public void InsertO(string a, string b, string c, int d, float e, float f, string g)
        {
            con.Open();

            SqlCommand s = new SqlCommand("INSERT INTO Orderinfo1 (OId,CId,productName,quantity,price,cost,status) values ('" + a + "','" + b + "','" + c + "','" + d + "'," + e + "," + f + ",'" + g + "')", con);


            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successfully Added Order", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {

                MessageBox.Show("Unsuccessfully Added order", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();

        }

        //insert product details and ..

        public void InsertPro1(string table,string a, string b, int c, float d, float e, int f, float g,string h)
        {
            con.Open();

            string table_name = table;


            SqlCommand s = new SqlCommand("INSERT INTO productdetails(PId,name,quantity,buyingprice,sellingprice,totalsold,profit,details) values ('" + a + "','" + b + "','" + c + "','" + d + "'," + e + "," + f + ",'" + g + "','" + h + "')", con);


            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successfully Added Order", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {

                MessageBox.Show("Unsuccessfully Added order", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            
            con.Close();
        }
        //insert into salesmanbill
        public void InsertBill(string a, float b, int c, float d)
        {
            con.Open();
            SqlCommand s1 = new SqlCommand("INSERT INTO salesmanbill1(name,price,quantity,totalprice) values ('" + a + "','" + b + "','" + c + "','" + d + "')", con);
            if (s1.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successfully Added salesmanbill1", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {

                MessageBox.Show("Unsuccessfully Added salesmanbill", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

        //insert pro details
        public void InsertPro(string table, string a, string b, int c, float d, float e, int f, float g)
        {
            con.Open();

            string table_name = table;


            SqlCommand s1 = new SqlCommand("INSERT INTO " + table_name + " (PId,name,quantity,buyingprice,sellingprice,totalsold,profit) values ('" + a + "','" + b + "','" + c + "','" + d + "'," + e + "," + f + ",'" + g + "')", con);


          
            if (s1.ExecuteNonQuery() == 1)
            {
            }

            else
            {


            }
            con.Close();
        }

        //insert Order details to Order
        public void InsertOrderDetails( string a, string b, float c, string d, string e)
        {
            con.Open();

            SqlCommand s = new SqlCommand("INSERT INTO Orderdetails(OId,CId,totalCost,status,mobileno) values ('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "')", con);

            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successfully Added Order", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {

                MessageBox.Show("Unsuccessfully Added order", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            con.Close();
        }

        //insert salesman
        public void InsertSalesman(string a, string b, string c, string d, string e,string f,string g,string h,float i,string j,string k,float l)
        {
           


            con.Open();

            SqlCommand s = new SqlCommand("INSERT INTO Salesmaninfo(SId,name,password,email,DOB,gender,mobileNo,address,salary,salarystatus,paiddate,totalsalary) values ('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h+ "'," + i + ",'" + j + "','" + k + "'," + l + ")", con);


            if (s.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("successfully Added Salesman", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                MessageBox.Show("Unsuccessfully Added", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

        // admin autoid
        public string AutoAId1()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("SELECT count(AId) From Admininfo ", con);
            
            int i = Convert.ToInt32(s.ExecuteScalar());
            con.Close();
            i++;
            this.aId = aP + i.ToString();
            con.Close();
            return aId;
           
        }

        public string AutoOId1()
        {


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("SELECT count(OId) From Orderinfo1 ", con);

            int i = Convert.ToInt32(s.ExecuteScalar());
            con.Close();
            i++;
            this.oId = oP + i.ToString();
            con.Close();
            return oId;
            
        }

        public string AutoPId()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("SELECT count(PId) From productdetails", con);

            int i = Convert.ToInt32(s.ExecuteScalar());
            con.Close();
            i++;
            this.pId = pP + i.ToString();

            return pId;
        }
        //get product price
        public float GetPrice(string a,string b)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
          
            SqlCommand s = new SqlCommand("SELECT * From " + a + " where name='" + b + "'", con);

           

           SqlDataReader dt = s.ExecuteReader();
     

          while (dt.Read())
               {
                   p = Convert.ToSingle( dt[4]);// +" " + dt.GetString(1) + " " + dt["Name"];
               }
          con.Close();
            return p ;
        }
      // get Discount
        public float GetDiscount(string a)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand s = new SqlCommand("SELECT * From Customerinfo where userId='" + a + "'", con);
            SqlDataReader dt = s.ExecuteReader();

            while (dt.Read())
            {
                dis = Convert.ToSingle(dt[8]);// +" " + dt.GetString(1) + " " + dt["Name"];
            }
            con.Close();
            return dis;
            
        }

        //get price for search
        public float GetPriceForSearch(string a)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From productdetails where name='" + a + "'", con);



            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                p = Convert.ToSingle(dt[4]);// +" " + dt.GetString(1) + " " + dt["Name"];
            }
            con.Close();
            return p;
        }

       //delete orderinfo

        public void DeleteOrder(string a)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM Orderinfo1 where OId In ('{0}','{1}')",a,a);
            SqlCommand s = new SqlCommand(sl, con);
            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Order deleted successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           else
            {
                MessageBox.Show("Order deleted deleted", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }           
            con.Close();
        }
        // delete order from order details for salesman
        public void DeleteOrderDetailsForSalesman(string a)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM Orderdetails where OId IN ('{0}','{1}') Or CId IN ('{0}','{1}') ", a, a);
            SqlCommand s = new SqlCommand(sl, con);
            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Order deleted successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Order deleted deleted", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }
        // delete order from order Info for salesman
        public void DeleteOrderInfoForSalesman(string a)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM Orderinfo1 where OId IN ('{0}','{1}') Or CId IN ('{0}','{1}') ", a, a);
            SqlCommand s = new SqlCommand(sl, con);
            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Order deleted successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Order deleted deleted", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }
        // GetMObileno

        public string GetMobile(string a)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From Customerinfo where userId='" + a + "'", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                mobileno = Convert.ToString(dt[3]); ;
            }
            
         
            con.Close();
            return mobileno;

           
        }

        //Get quantity for dlt

        public int GetQuantityForDlt(string a,string b)
        {

            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From "+a+" where name='" + b + "'", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                quantity = Convert.ToInt32(dt["quantity"]); ;
            }

            con.Close();
            return quantity;
        }

        //get quantity for update
        public int GetQuantityForup(string a, string b,string c)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From " + a + " where name='" + b + "' or name='"+c+"'", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                quantity1 = Convert.ToInt32(dt["quantity"]); ;
            }

            con.Close();
            return quantity1;
        }

        //get current rank


        public int GetRank(string a)
        {

            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From Customerinfo where userId='" + a + "'", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                Rank = Convert.ToInt32(dt["count"]); ;
            }

            con.Close();
            return Rank;
        }
        ///get salary of salesman

        public float GetSalaryTotal(string a)
        {
            
            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From Salesmaninfo where SID='" + a + "'", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                sal = Convert.ToSingle(dt["totalsalary"]); ;
            }

            con.Close();
            return sal;
        }

        //get store cost
        public float GetStorecostPRofit()
        {

            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From profita ", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                store = Convert.ToSingle(dt["storeCost"]); ;
            }

            // Console.Write(quantity);
            con.Close();
            return store;
        }
        //get invest
        public float GetInvestPRofit()
        {

            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From profita ", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                invest = Convert.ToSingle(dt["totaI_Invest"]); ;
            }

            con.Close();
            return invest;
        }

        //get salarycost
        public float GetSalaryPRofit()
        {

            con.Open();
            
            SqlCommand s = new SqlCommand("SELECT * From profita ", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                salll = Convert.ToSingle(dt["salaryCost"]); ;
            }

            con.Close();
            return salll;
        }
        //get toatalsell for profit

        public float GetSellCostPRofit()
        {

            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From profita ", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                sold = Convert.ToSingle(dt["totalsell"]); ;
            }

            con.Close();
            return sold;
        }

        //get profit from per product

        public float GetProfitPerProduct(string a,string b)
        {

            con.Open();

            SqlCommand s = new SqlCommand("SELECT * From "+a+" where name='"+b+"' ", con);


            SqlDataReader dt = s.ExecuteReader();


            while (dt.Read())
            {
                profit = Convert.ToSingle(dt["profit"]); ;
            }

            con.Close();
            return profit;
        }
        //update Quantity
        public void UpdateQuantity(string a, string b,int c)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE "+a+" SET quantity={0} where name='{1}'",c,b);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {

            }
            else
            {

            }
            con.Close();
        }
        // update quantity in product details

        public void UpdateQuantityInDetails(string a, int c)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE productdetails SET quantity={0} where name='{1}'", c, a);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {

            }
            else
            {

            }
            con.Close();
        }
        //update orderdetails

        public int UpdateOrderDetailsForSalesman(string a,string b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE Orderdetails SET status='{2}' where OId IN ('{0}','{1}') Or CId IN ('{0}','{1}') ", a, a,b);
            SqlCommand s = new SqlCommand(sl, con);
           
            if (s.ExecuteNonQuery() == 1)
            {
                return 1;
               
            }
            else
            {
                return 0;
            }
            con.Close();
        }

        //update orderinfo1
        public int UpdateOrderInfoForSalesman(string a, string b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl1 = string.Format("UPDATE Orderinfo1 SET status='{2}' where OId IN ('{0}','{1}') Or CId IN ('{0}','{1}') ", a, a, b);

            SqlCommand s1 = new SqlCommand(sl1, con);
            
            if (s1.ExecuteNonQuery() == 1)
            {
                return 1;
             }
            else
            {
                return 0;
            }
            con.Close();
        }

        //Update Rank for customer

        public void UpdateRank(string a,int b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl1 = string.Format("UPDATE Customerinfo SET count={0} where userId='{1}' ",b,a);

            SqlCommand s1 = new SqlCommand(sl1, con);

            if (s1.ExecuteNonQuery() == 1)
            {
               
            }
            else
            {
            
            }
            con.Close();
        }

        // update Discount

        public int UpdateDiscount(string a, string b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl1 = string.Format("UPDATE Customerinfo SET discount='{0}' where userId='{1}' ", b, a);

            SqlCommand s1 = new SqlCommand(sl1, con);

            if (s1.ExecuteNonQuery() == 1)
            {
                return 1;

            }
            else
            {
                return 0;
            }
            con.Close();
        }

        public void DeleteSalesAndAdmin(string a,string b,string c,string d)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM "+a+" where "+b+"='{0}' Or name='{1}'" , c,d);

            SqlCommand s = new SqlCommand(sl, con);



            if (s.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Delete Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                MessageBox.Show("Unsuccessfully Deleted", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        //test delete
        public void DeleteProduct(string a,string b,string c)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM "+a+" WHERE name ='" + b + "' or name='"+c+"'");

            SqlCommand s = new SqlCommand(sl, con);



            if (s.ExecuteNonQuery() == 1)
            {

                //MessageBox.Show("Delete1 Successfully product", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
               // MessageBox.Show("Unsuccessfully Deleted product", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        //delete from details product
        public void DeleteProductDetails( string b, string c)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM productdetails WHERE name ='" + b + "' or name='" + c + "'");

            SqlCommand s = new SqlCommand(sl, con);



            if (s.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Delete1 Successfully product", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                MessageBox.Show("Unsuccessfully Deleted product", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
        //delete all for salesman bill
        public void DeleteSalesmanBill()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("DELETE FROM salesmanbill1");

            SqlCommand s = new SqlCommand(sl, con);



            if (s.ExecuteNonQuery() == 1)
            {

              //  MessageBox.Show("Delete1 Successfully product", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
              //  MessageBox.Show("Unsuccessfully Deleted product", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        //Update salesman info
        public void UpdateSalesman(string a, string b, string c, float d, string e,string f)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE Salesmaninfo SET mobileNo='{0}',email='{1}',address='{2}',salary={3},password='{5}' where SId='{4}'", a,b,c,d,e,f);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

        //update admin info
        public void UpdateAdmin(string a, string b, string c, string e, string f)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE Admininfo SET mobileNo='{0}',email='{1}',address='{2}',password='{4}' where AId='{3}'", a, b, c, e, f);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Admin Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("Admin Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //Update product 
        public void UpdateProduct(string a, string b, float c, float d, int e,string g)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE " + a + " SET sellingprice='{1}',buyingprice='{2}',quantity='{3}' where name='{0}' or name='{4}' ", b, c, d, e,g);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                //MessageBox.Show("product Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
              //  MessageBox.Show("product Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //update product details
        public void UpdateProductDe(string a, string b, float c, float d, int e,string g)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE " + a + " SET sellingprice='{1}',buyingprice='{2}',quantity={3} where name='{0}' or name='{4}'", b, c, d, e,g);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("product Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("product Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //salary update salesman
        public void UpdateSalary(string a, float b,float c,string d)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE Salesmaninfo SET salarystatus='"+"Paid"+"',salary={1},totalsalary={2},paiddate='{3}' where SId='{0}'", a, b, c,d);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

        //update profit

        public void UpdateProfit(float a, string b,float c)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE profita SET storeCost="+a+ ",updateDate='{0}',netIncome={1}",  b, c);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

        //profit fot invest

        public void UpdateProfitForInvest(string b, float c)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE profita SET updateDate='{0}', totaI_Invest={1}", b, c);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                //MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
               // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //whole profita contol umpadte
        public void UpdateWholeProfita(float b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE profita SET netIncome={0}", b);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
               // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
               // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //update salary for profit
       
        public void UpdateSalaryProfita(float b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE profita SET salaryCost={0}", b);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //update totalsell for profit

        public void UpdateTotalsellProfita(float b)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE profita SET totalsell={0}", b);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                // MessageBox.Show("Salesman Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }
        //customer edit
        public void UpdateCustomerInfo(string a,string b,string c,string d)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sl = string.Format("UPDATE Customerinfo SET mobileNo='{0}', email='{1}', Address='{2}' where userId='{3}'",a,b,c,d);
            SqlCommand s = new SqlCommand(sl, con);

            if (s.ExecuteNonQuery() == 1)
            {
                 MessageBox.Show("Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                 MessageBox.Show(" Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            con.Close();
        }

    }
}
