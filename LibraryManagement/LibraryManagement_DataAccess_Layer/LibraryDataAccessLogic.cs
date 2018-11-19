using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_DataAccess_Layer
{
    public class LibraryDataAccessLogic
    {
        public bool LoginAuth(string loginID, string password)
        {
            try
            {
                bool flag = false;
                LibraryManagementEntities context = new LibraryManagementEntities();

                var query = from data in context.Logins
                            where data.Login_ID == loginID && data.Password == password
                            select data;

                if (query.Any())
                     flag = true;                
                else
                    throw new Exception("Invalid Login ID and Password");
                    


                return flag;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RegistrationAdd(Registration reg,string password)
        {
            try
            {
                bool flag = false;
                LibraryManagementEntities context = new LibraryManagementEntities();

                var query = from data in context.Registrations
                            where data.Student_Number==reg.Student_Number
                            select data;

                if (query.Any())
                    throw new Exception("Record Already Exist");
                else
                {
                    Login login = new Login();
                    login.Login_ID = reg.Student_Number.ToString();
                    login.Password = password;
                    context.Registrations.Add(reg);
                    context.Logins.Add(login);
                    context.SaveChanges();
                    flag = true;
                }
                return flag;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                LibraryManagementEntities context = new LibraryManagementEntities();
                var query = from data in context.Books
                            select data;
                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading data from book. Please come back later");
            }
        }

        public List<Book> SearchBooks(string searchData)
        {
            try
            {
                LibraryManagementEntities context = new LibraryManagementEntities();
                int search=0;
                if (int.TryParse(searchData, out search)) ;
               
                var query = from data in context.Books
                            where data.Book_Number==search || data.Book_Name.Contains(searchData)
                            || data.Publication.Contains(searchData) || data.Author.Contains(searchData)
                            select data;
                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<BookCategory> GetAllCategory()
        {
            try
            {
                LibraryManagementEntities context = new LibraryManagementEntities();
                var query = from data in context.BookCategories
                            select data;
                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading data from book categories. Please come back later");
            }
        }

        public bool AddNewBook(Book book)
        {
            try
            {
                bool flag = false;
                LibraryManagementEntities context = new LibraryManagementEntities();

                var query = from data in context.Books
                            where data.Book_Number==book.Book_Number
                            select data;

                if (query.Any())
                    throw new Exception("Record Already Exist");
                else
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                    flag = true;
                }
                return flag;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                bool flag = false;
                LibraryManagementEntities context = new LibraryManagementEntities();

                var query = (from data in context.Books
                            where data.Book_Number == book.Book_Number
                            select data).FirstOrDefault();

                query.Book_Name = book.Book_Name;
                query.Author = book.Author;
                query.Publication = book.Publication;
                query.Quantity = book.Quantity;
                query.Category_ID = book.Category_ID;

                    context.SaveChanges();
                    flag = true;
                
                return flag;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool NewBookIssue(BookIssue book)
        {
            try
            {
                bool flag = false;
                LibraryManagementEntities context = new LibraryManagementEntities();

                var query = (from data in context.Books
                            where data.Book_Number == book.Book_Number
                            select data).FirstOrDefault();
                int quantity = query.Quantity;
                query.Quantity = quantity - 1;
                context.BookIssues.Add(book);
                context.SaveChanges();
                flag = true;
               
                return flag;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidateID(int studentID)
        {
            bool flag = false;
            LibraryManagementEntities context = new LibraryManagementEntities();

            var query = from data in context.Registrations
                         where data.Student_Number == studentID
                         select data;

            if (query.Any())
                flag = true;

            return flag;

        }

        public Book GetBookByID(int bookNumber)
        {
            LibraryManagementEntities context = new LibraryManagementEntities();

            var query = from data in context.Books
                        where data.Book_Number == bookNumber
                        select data;
            return query.FirstOrDefault();
           
        }

        public List<BookIssue> GetDataByID(int studentID)
        {
            LibraryManagementEntities context = new LibraryManagementEntities();

            var query = from data in context.BookIssues
                        where data.Student_Number == studentID
                        select data;
            return query.ToList();
        }

        public bool DeleteBookIssues(int studentID,int bookNumber)
        {
            LibraryManagementEntities context = new LibraryManagementEntities();
            bool flag = false;

            var query = (from data in context.Books
                         where data.Book_Number == bookNumber
                         select data).FirstOrDefault();
            int quantity = query.Quantity;
            query.Quantity = quantity + 1;

            var deleteQuery = (from data in context.BookIssues
                        where data.Student_Number == studentID && data.Book_Number== bookNumber
                        select data).FirstOrDefault();

            context.BookIssues.Remove(deleteQuery);
            context.SaveChanges();
            flag = true;

            return flag;
        }

        public bool DeleteBook(int bookNumber)
        {
            LibraryManagementEntities context = new LibraryManagementEntities();
            bool flag = false;

            var query = (from data in context.Books
                         where data.Book_Number == bookNumber
                         select data).FirstOrDefault();
            
            context.Books.Remove(query);
            context.SaveChanges();
            flag = true;

            return flag;
        }

        public String GetCategory(int categoryID)
        {
            LibraryManagementEntities context = new LibraryManagementEntities();

            var query = (from data in context.BookCategories
                        where data.Category_ID == categoryID
                        select data).FirstOrDefault();
            return query.Category_Name;
        }


    }
}
