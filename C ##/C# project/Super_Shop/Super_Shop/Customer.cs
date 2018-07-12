using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop
{
   public class Customer : User
    {
       private string cId;
       private string cP="C-1-";
       private int counter;
       private float discount;

       public Customer()
       {
           AutoCId();
       }
       public Customer(String Name, String password, String email,
          String mobileNo, String dateOfBirth, String gender, String address,String cId)
           : base(Name, password, email,mobileNo, dateOfBirth, gender, address)
       {
           AutoCId();

       }

       public void AutoCId()
       {
           SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
           con.Open();

           SqlCommand s = new SqlCommand("SELECT count(userid) From Customerinfo", con);

           int i = Convert.ToInt32(s.ExecuteScalar());
           con.Close();
           i++;
           this.cId = cP + i.ToString();


       }


       public String CId
       {
           set { this.cId = value; }
           get { return this.cId; }
       }

       public int Counter
       {
           set { this.counter = value; }
           get { return this.counter; }
       }

       public float Discount
       {
           set { this.discount = value; }
           get { return this.discount; }
       }





    }
}
