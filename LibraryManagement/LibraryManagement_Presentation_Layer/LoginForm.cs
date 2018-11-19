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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string loginID = loginIDTextBox.Text;
                string password = passwordTextBox.Text;
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();

                if (libraryBL.LoginAuth(loginID, password))
                {
                    Home home = new Home();
                    if (loginID.Equals("Admin123") && password.Equals("Admin123"))
                        home.SetData("Admin",loginID);
                    else
                        home.SetData("Student",loginID);

                    home.Show();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            
        }
    }
}
