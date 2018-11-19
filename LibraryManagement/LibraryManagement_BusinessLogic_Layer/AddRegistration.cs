using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_BusinessLogic_Layer
{
   public class AddRegistration: NewRegistration
    {
        private string studentName;
        private string emailID;
        private string address;
        private int contactNumber;
        private string gender;
       

        public string StudentName
        {
            get { return studentName; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Please Enter Name");
                else
                    studentName = value;
            }
        }
        public string EmailID
        {
            get { return emailID; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Please Enter email ID");
                else
                    emailID = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Please Enter Publication");
                else
                    address = value;
            }
        }
        public int ContactNumber
        {
            get { return contactNumber; }
            set 
            {
                int data = (int)Math.Floor(Math.Log10(value)) + 1;
                if (data != 10)
                    throw new Exception("Please Enter proper ContactNumber");
                else
                    contactNumber = value; 
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Please select Gender");
                else
                    gender = value;
            }
        }
        
    }
}
