using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement_BusinessLogic_Layer;
using LibraryManagement_DataAccess_Layer;

namespace LibraryManagement_Presentation_Layer
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                int bookNumber;
                if (!int.TryParse(bookNumberTextBox.Text, out bookNumber))
                    throw new Exception("Book number should be numeric only");

                string name = bookTitleTextBox.Text;
                int category = categoryComboBox.SelectedIndex;
                string publication = publicationTextBox.Text;
                string author = authorTextBox.Text;
                int quantity;
                if (!int.TryParse(quantityTextBox.Text, out quantity))
                    throw new Exception("Quantity should be numeric");
                NewBook newBook = new NewBook();
                newBook.BookNumber = bookNumber;
                newBook.BookName = name;
                newBook.CategoryID = category;
                newBook.Publication = publication;
                newBook.Author = author;
                newBook.Quantity = quantity;
                newBook.checkStock += OnSetup;

                if (newBook.Quantity > 100)
                {
                    newBook.OnStockCheck(EventArgs.Empty);
                }
                if (bookNumberTextBox.Enabled == false)
                {
                    if (libraryBL.UpdateBook(newBook))
                    {
                        MessageBox.Show("Data Updated");
                        bookNumberTextBox.Clear();
                        bookTitleTextBox.Clear();
                        authorTextBox.Clear();
                        publicationTextBox.Clear();
                        quantityTextBox.Clear(); ;
                        categoryComboBox.SelectedIndex = 0;
                    }
                }
                else if (libraryBL.AddNewBook(newBook))
                {
                    MessageBox.Show("Data Inserted");
                    bookNumberTextBox.Clear();
                    bookTitleTextBox.Clear();
                    authorTextBox.Clear();
                    publicationTextBox.Clear();
                    quantityTextBox.Clear(); ;
                    categoryComboBox.SelectedIndex = 0;
                }
                SetData();
                bookNumberTextBox.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetData()
        {
            LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
            resultDataGridView.Rows.Clear();
            resultDataGridView.ColumnCount = 5;
            resultDataGridView.Columns[0].Name = "Book Number";
            resultDataGridView.Columns[1].Name = "Book Name";
            resultDataGridView.Columns[2].Name = "Author";
            resultDataGridView.Columns[3].Name = "Publication";
            resultDataGridView.Columns[4].Name = "Quantity";


            foreach (Book book in libraryBL.GetAllBooks())
            {
                resultDataGridView.Rows.Add(book.Book_Number, book.Book_Name, book.Author, book.Publication, book.Quantity);
            }
        }

        
        private void AddBook_Load_1(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                categoryComboBox.Items.Add("----Select Category-----");
                foreach (BookCategory category in libraryBL.GetAllCategory())
                {
                    categoryComboBox.Items.Add(category.Category_Name.Trim());
                }

                SetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void bookNumberTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                int bookNumber;
                if (!int.TryParse(bookNumberTextBox.Text, out bookNumber))
                    throw new Exception("Book number should be numeric only");

                Book book = libraryBL.GetBookByID(bookNumber);

                if (book != null)
                {
                    bookTitleTextBox.Text = book.Book_Name.Trim();
                    categoryComboBox.SelectedItem = libraryBL.GetCategory(book.Category_ID).Trim();
                    publicationTextBox.Text = book.Publication.Trim();
                    authorTextBox.Text = book.Author.Trim();
                    quantityTextBox.Text = book.Quantity.ToString();

                    bookNumberTextBox.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                
                if (bookNumberTextBox.Enabled==false)
                {
                    if (libraryBL.DeleteBook(int.Parse(bookNumberTextBox.Text)))
                    {
                        MessageBox.Show("Data Deleted");
                        bookNumberTextBox.Clear();
                        bookTitleTextBox.Clear();
                        authorTextBox.Clear();
                        publicationTextBox.Clear();
                        quantityTextBox.Clear(); ;
                        categoryComboBox.SelectedIndex = 0;

                        bookNumberTextBox.Enabled = true;
                        SetData();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void OnSetup(object sender, EventArgs e)
        {
            throw new Exception("Please check store sapce. This book has more than 100 quantity");
        }
    }
}
