using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop
{
    class Order
    {
        Databasecon d = new Databasecon();

       private String oId;
       private String productName;
       private String cId;
       private int quantity;
       private float price;
       private float cost;
       private String status;
       private String mobileNo;

       public Order(String oId, String productName, String cId, int quantity, float price,
             float cost, String status, String mobileNo)
        {
            this.oId = d.AutoOId1();
            this.productName = productName;
            this.cId = oId;
            this.quantity = quantity;
            this.price = price;
            this.cost = cost;
            this.status = status;
            this.mobileNo = mobileNo;
            
        }

        public Order()
        {
            AutoOId();
        }


        public void AutoOId()
        {


            /* SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jahin\Documents\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
             con.Open();

             SqlCommand s = new SqlCommand("SELECT count(AId) From Admininfo ", con);

             int i = Convert.ToInt32(s.ExecuteScalar());
             con.Close();
             i++;*/
            this.oId = d.AutoOId1();


        }

        public String OId
        {
            set { this.oId = value; }
            get { return this.oId; }
        }

        public String ProductName
        {
            set { this.productName = value; }
            get { return this.productName; }
        }

        public String CId
        {
            set { this.cId = value; }
            get { return this.cId; }
        }

        public int Quantity
        {
            set { this.quantity = value; }
            get { return this.quantity; }
        }

        public float Price
        {
            set { this.price = value; }
            get { return this.price; }
        }


        public float Cost
        {
            set { this.cost = value; }
            get { return this.cost; }
        }

        public String Status
        {
            set { this.status = value; }
            get { return this.status; }
        }
        public String MobileNo
        {
            set { this.mobileNo = value; }
            get { return this.mobileNo; }
        }

    }
}
