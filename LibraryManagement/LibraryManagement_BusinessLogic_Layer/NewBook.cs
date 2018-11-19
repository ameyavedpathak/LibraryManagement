using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_BusinessLogic_Layer
{
   public class NewBook
    {

       public event EventHandler checkStock;
        private int bookNumber;
        private string bookName;
        private string author;
        private string publication;
        private int categoryID;
        private int quantity;


        public int BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }
        public string BookName
        {
            get { return bookName; }
            set 
            {
                if (value.Equals(""))
                    throw new Exception("Please Enter BookName");
                else
                    bookName = value; 
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Please Enter Author");
                else
                    author = value;
            }
        }
        public string Publication   
        {
            get { return publication; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Please Enter Publication");
                else
                    publication = value;
            }
        }
        public int CategoryID  
        {
            get { return categoryID; }
            set
            {
                if (value.Equals("") || value < 0)
                    throw new Exception("Please Select Category");
                else
                    categoryID = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new Exception("Please Enter proper quantity");
                else
                    quantity = value;
            }
        }


        public virtual void OnStockCheck(EventArgs args)
        {
            EventHandler stock = checkStock;
            if (stock != null)
            {
                stock(this, args);
            }
        }

    }
}
