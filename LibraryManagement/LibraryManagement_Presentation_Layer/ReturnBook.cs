using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement_DataAccess_Layer;
using LibraryManagement_BusinessLogic_Layer;

namespace LibraryManagement_Presentation_Layer
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }


        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBook searchBook = new SearchBook();
            searchBook.Show();
        }

        private void addDeleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.Show();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook issue = new IssueBook();
            issue.Show();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook();
            returnBook.Show();
        }

        private void bookReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllBook book = new ViewAllBook();
            book.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentNumberTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                SetData();
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
                    foreach (DataGridViewRow row in resultDataGridView.SelectedRows)
                    {
                        DialogResult dialogResult = MessageBox.Show("Confirm the Task Performed", "Checking", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int studentID = int.Parse(row.Cells[2].Value.ToString());
                            int bookNumber = int.Parse(row.Cells[0].Value.ToString());
                            if (libraryBL.DeleteBookIssues(studentID, bookNumber))
                            {
                                MessageBox.Show("Book Returned");
                                SetData();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetData()
        {
            LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
            int studentID;
            if (!int.TryParse(studentNumberTextBox.Text, out studentID))
                throw new Exception("Please Enter numeric value only");

            resultDataGridView.Rows.Clear();
            resultDataGridView.ColumnCount = 6;
            resultDataGridView.Columns[0].Name = "Book Number";
            resultDataGridView.Columns[1].Name = "Book Name";
            resultDataGridView.Columns[2].Name = "Student Number";
            resultDataGridView.Columns[3].Name = "Date of Issue";
            resultDataGridView.Columns[4].Name = "Date of Return";
            resultDataGridView.Columns[5].Name = "Late fees";


            foreach (BookIssue book in libraryBL.GetDataByID(studentID))
            {
                Book data = libraryBL.GetBookByID(book.Book_Number);
                int numberOfDays = (int)(DateTime.Today - book.Return_Date).TotalDays;

                if (numberOfDays > 0)
                    resultDataGridView.Rows.Add(book.Book_Number, data.Book_Name, book.Student_Number, book.Issued_Date, book.Return_Date, 10 * numberOfDays);
                else
                    resultDataGridView.Rows.Add(book.Book_Number, data.Book_Name, book.Student_Number, book.Issued_Date, book.Return_Date, 0);
            }
        }
    }
}
