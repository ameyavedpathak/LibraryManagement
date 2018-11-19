using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement_DataAccess_Layer;

namespace LibraryManagement_BusinessLogic_Layer
{
    public class LibraryBusinessLogic
    {

        public bool LoginAuth(string loginID, string password)
        {
            try
            {
                bool flag = false;
                LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
                flag = libraryDA.LoginAuth(loginID, password);

                return flag;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RegistrationAdd(AddRegistration signUp)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            Registration reg = new Registration();
            bool flag = false;

            reg.Student_Number = signUp.StudentNumber;
            reg.Name = signUp.StudentName;
            reg.E_mail_ID = signUp.EmailID;
            reg.Gender = signUp.Gender;
            reg.Address = signUp.Address;
            reg.Contact_Number = signUp.ContactNumber;

            flag= libraryDA.RegistrationAdd(reg,signUp.Password);

            return flag;
          
        }

        public bool DeleteBook(int bookNumber)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.DeleteBook(bookNumber);
        }

        public List<Book> GetAllBooks()
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.GetAllBooks();
        }

        public List<Book> SearchBooks(string searchData)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.SearchBooks(searchData);
        }


        public List<BookCategory> GetAllCategory()
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.GetAllCategory();
        }

        public bool AddNewBook(NewBook newBook)
        {
            bool flag = false;
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            Book book = new Book();
            book.Book_Number = newBook.BookNumber;
            book.Book_Name = newBook.BookName;
            book.Publication = newBook.Publication;
            book.Author = newBook.Author;
            book.Quantity = newBook.Quantity;
            book.Category_ID = newBook.CategoryID;

            flag = libraryDA.AddNewBook(book);
            return flag;

        }

        public bool UpdateBook(NewBook newBook)
        {
            bool flag = false;
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            Book book = new Book();
            book.Book_Number = newBook.BookNumber;
            book.Book_Name = newBook.BookName;
            book.Publication = newBook.Publication;
            book.Author = newBook.Author;
            book.Quantity = newBook.Quantity;
            book.Category_ID = newBook.CategoryID;

            flag = libraryDA.UpdateBook(book);
            return flag;

        }

        public bool NewBookIssue(BookIssue book)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();

            return libraryDA.NewBookIssue(book);
       }

        public bool ValidateID(int studentID)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.ValidateID(studentID);
        }

        public Book GetBookByID(int bookNumber)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.GetBookByID(bookNumber);

        }

        public List<BookIssue> GetDataByID(int studentID)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.GetDataByID(studentID);
        }

        public bool DeleteBookIssues(int studentID, int bookNumber)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.DeleteBookIssues(studentID,bookNumber);
        }

        public String GetCategory(int categoryID)
        {
            LibraryDataAccessLogic libraryDA = new LibraryDataAccessLogic();
            return libraryDA.GetCategory(categoryID);
        }
        
    }
}
