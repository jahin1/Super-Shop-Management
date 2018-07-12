using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop
{
   public class Salesman : User
    {
       private string sId;
       private string sP="S-1000-";
      
       private float salary;
       private string salaryStatus;
       private string paidDate;
       private float totalsalary;

       public Salesman()
       {
           AutoSId();
       }
       public Salesman(String Name, String password, String email,
          String mobileNo, String dateOfBirth, String gender, String address,String cId)
           : base(Name, password, email,mobileNo, dateOfBirth, gender, address)
       {
           AutoSId();

       }

       public void AutoSId()
       {
           SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Lenovo\Desktop\project final\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
           con.Open();

           SqlCommand s = new SqlCommand("SELECT count(SId) From Salesmaninfo", con);

           int i = Convert.ToInt32(s.ExecuteScalar());
           con.Close();
           i++;
           this.sId = sP + i.ToString();


       }


       public String SId
       {
           set { this.sId = value; }
           get { return this.sId; }
       }

       public String SalaryStatus
       {
           set { this.salaryStatus = value; }
           get { return this.salaryStatus; }
       }

       public String PaidDate
       {
           set { this.paidDate = value; }
           get { return this.paidDate; }
       }


       public float Salary 
       {
           set { this.salary = value; }
           get { return this.salary; }
       }
       public float Totalsalary
       {
           set { this.totalsalary = value; }
           get { return this.totalsalary; }
       }

    }
}
