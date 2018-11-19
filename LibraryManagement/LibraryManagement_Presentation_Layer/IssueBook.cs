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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                resultDataGridView.Rows.Clear();
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                resultDataGridView.ColumnCount = 5;
                resultDataGridView.Columns[0].Name = "Book Number";
                resultDataGridView.Columns[1].Name = "Book Name";
                resultDataGridView.Columns[2].Name = "Author";
                resultDataGridView.Columns[3].Name = "Publication";
                resultDataGridView.Columns[4].Name = "Quantity";

                if (searchTextBox.Text != "")
                {
                    foreach (Book book in libraryBL.SearchBooks(searchTextBox.Text))
                    {
                        if (book.Quantity > 0)
                            resultDataGridView.Rows.Add(book.Book_Number, book.Book_Name, book.Author, book.Publication, book.Quantity);
                        else
                            resultDataGridView.Rows.Add(book.Book_Number, book.Book_Name, book.Author, book.Publication, book.Quantity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                if (resultDataGridView.SelectedRows.Count > 0)
                {
                    int studentNumber;
                    if (!int.TryParse(studentNumberTextBox.Text, out studentNumber))
                        throw new Exception("Student Number should be numeric only");

                    if (libraryBL.ValidateID(studentNumber))
                    {
                        foreach (DataGridViewRow row in resultDataGridView.SelectedRows)
                        {
                            BookIssue bookIssue = new BookIssue();
                            bookIssue.Book_Number = int.Parse(row.Cells[0].Value.ToString());
                            bookIssue.Student_Number = studentNumber;
                            MessageBox.Show(row.Cells[0].Value.ToString());
                            bookIssue.Issued_Date = issueDateTimePicker.Value;
                            bookIssue.Return_Date = returnDateTimePicker.Value;
                            int quantity = int.Parse(row.Cells[4].Value.ToString());
                            //MessageBox.Show("Hello");
                            if (quantity > 0)
                            {
                                if (libraryBL.NewBookIssue(bookIssue))
                                {
                                    MessageBox.Show("Book Issued");
                                    searchTextBox.Clear();
                                    studentNumberTextBox.Clear();
                                }
                            }
                            else
                                throw new Exception("Cannot issue book because it is not available right now ");
                        }
                    }
                    else
                        throw new Exception("Invalid Student Number");
 
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {

        }



    }
}
