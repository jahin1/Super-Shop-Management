using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop
{
    public class Admin : User
    {
       private string aId;
      // private string aP="A-1-";
        Databasecon d = new Databasecon();

       public Admin()
       {
           AutoAId();
       }
       public Admin(String Name, String password, String email,
          String mobileNo, String dateOfBirth, String gender, String address,String cId)
           : base(Name, password, email,mobileNo, dateOfBirth, gender, address)
       {
           this.aId = d.AutoAId1();


       }

       public void AutoAId()
       {
          

          /* SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jahin\Documents\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
           con.Open();

           SqlCommand s = new SqlCommand("SELECT count(AId) From Admininfo ", con);

           int i = Convert.ToInt32(s.ExecuteScalar());
           con.Close();
           i++;*/
           this.aId = d.AutoAId1();


       }


       public String AID
       {
           set { this.aId = value; }
           get { return this.aId; }

           
       }
        

    }
}
