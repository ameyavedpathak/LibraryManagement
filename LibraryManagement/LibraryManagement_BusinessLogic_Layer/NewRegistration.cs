using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_BusinessLogic_Layer
{
   public class NewRegistration
    {
       private int studentNumber;
       private string password;

       public int StudentNumber
       {
           get { return studentNumber; }
           set { studentNumber = value; }
       }

       public string Password
       {
           get { return password; }
           set
           {
               if (value.Equals(""))
                   throw new Exception("Please Enter Password");
               else
                   password = value;
           }
       }
    }
}
