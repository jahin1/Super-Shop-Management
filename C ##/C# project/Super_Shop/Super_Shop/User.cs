using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop
{
   public class User
    {

        private String name;
        
       //private String userId;
        private String password;
        private String email;
        private String mobileNo;
        private String dateOfBirth;
        private String gender;
        private String address;




        public User(String name, String password, String email,
            String mobileNo, String dateOfBirth, String gender, String address)
        {
            this.name = name;
            
            // this.userId = userId;
            this.password = password;
            this.email = email;
            this.mobileNo = mobileNo;
            this.gender = gender;
            this.address = address;
        }

        public User()
        {
        }


        public String Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

       

        //public String UserId
        //{
        //    set { this.userId = value; }
        //    get { return this.userId; }
        //}

        public String Password
        {
            set { this.password = value; }
            get { return this.password; }
        }

        public String Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

        public String MobileNo
        {
            set { this.mobileNo = value; }
            get { return this.mobileNo; }
        }

        public String DateOfBirth
        {
            set { this.dateOfBirth = value; }
            get { return this.dateOfBirth; }
        }

        public String Gender
        {
            set { this.gender = value; }
            get { return this.gender; }
        }

        public String Address
        {
            set { this.address = value; }
            get { return this.address; }
        }

    }
}
