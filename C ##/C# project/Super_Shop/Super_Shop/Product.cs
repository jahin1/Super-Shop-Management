using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop
{
    class Product
    {

        private string pId;
        Databasecon d = new Databasecon();
        private String productName;       
        private int quantity;
        private float buyingPrice;
        private float sellingPrice;
        private int totalSold;
        private float profit;
        private string details;



        public Product(String productName, int quantity, float buyingPrice, int totalSold,
            float sellingPrice, float profit, string details)
        {
            this.pId = d.AutoPId();
            this.productName = productName;
            this.quantity = quantity;
            this.buyingPrice = buyingPrice;
            this.sellingPrice = sellingPrice;
            this.totalSold = totalSold;
            this.profit = profit;
            this.details = details;
            
        }

        public Product()
        {
            this.pId = d.AutoPId();
        }

        public String ProductName
        {
            set { this.productName = value; }
            get { return this.productName; }
        }

        public int Quantity
        {
            set { this.quantity = value; }
            get { return this.quantity; }
        }

        public float BuyingPrice
        {
            set { this.buyingPrice = value; }
            get { return this.buyingPrice; }
        }

        public float SellingPrice
        {
            set { this.sellingPrice = value; }
            get { return this.sellingPrice; }
        }
        public int TotalSold
        {
            set { this.totalSold = value; }
            get { return this.totalSold; }
        }

        public float Profit
        {
            set { this.profit = value; }
            get { return this.profit; }
        }

        public String PID
        {
            set { this.pId = value; }
            get { return this.pId; }
        }
        public String Details
        {
            set { this.details = value; }
            get { return this.details; }
        }
          
    }
}
