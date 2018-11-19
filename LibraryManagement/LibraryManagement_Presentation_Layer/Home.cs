using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement_Presentation_Layer
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

       public string userType = "";
       public string studentID = "";

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void SetData(string userType,string studentID)
        {
            this.userType = userType;
            this.studentID=studentID;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (userType.Equals("Admin"))
            {
                issuedBookToolStripMenuItem.Visible = false;
            }
            else
            {
                addDeleteBookToolStripMenuItem.Visible = false;
                issueBookToolStripMenuItem.Visible = false;
                bookReportToolStripMenuItem.Visible = false;
                returnBookToolStripMenuItem.Visible = false;
            }
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
            this.Dispose();
        }

        private void issuedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssuedForm issuedForm = new IssuedForm();
            issuedForm.SetData(studentID);
            issuedForm.Show();
        }
    }
}
