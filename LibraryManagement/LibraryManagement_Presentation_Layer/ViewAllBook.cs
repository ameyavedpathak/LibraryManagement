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
    public partial class ViewAllBook : Form
    {
        public ViewAllBook()
        {
            InitializeComponent();
        }

        private void ViewAllBook_Load(object sender, EventArgs e)
        {
            try
            {
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                resultDataGridView.ColumnCount = 5;
                resultDataGridView.Columns[0].Name = "Book Number";
                resultDataGridView.Columns[1].Name = "Book Name";
                resultDataGridView.Columns[2].Name = "Author";
                resultDataGridView.Columns[3].Name = "Publication";
                resultDataGridView.Columns[4].Name = "Quantity";

                foreach (Book book in libraryBL.GetAllBooks())
                {
                    resultDataGridView.Rows.Add(book.Book_Number,book.Book_Name,book.Author,book.Publication,book.Quantity);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
