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
    public partial class IssuedForm : Form
    {
        public IssuedForm()
        {
            InitializeComponent();
        }
        public string studentID;

        private void IssuedForm_Load(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();

                resultDataGridView.ColumnCount = 5;
                resultDataGridView.Columns[0].Name = "Book Number";
                resultDataGridView.Columns[1].Name = "Book Name";
                resultDataGridView.Columns[2].Name = "Book Author";
                resultDataGridView.Columns[3].Name = "Issue date";
                resultDataGridView.Columns[4].Name = "Return Date";

                foreach(BookIssue data in libraryBL.GetDataByID(int.Parse(studentID)))
                {
                    Book book=libraryBL.GetBookByID(data.Book_Number);

                    resultDataGridView.Rows.Add(data.Book_Number,book.Book_Name,book.Author,data.Issued_Date,data.Return_Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetData(string studentID)
        {
            this.studentID = studentID;
        }
    }
}
