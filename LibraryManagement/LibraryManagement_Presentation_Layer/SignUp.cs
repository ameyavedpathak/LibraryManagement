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

namespace LibraryManagement_Presentation_Layer
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddRegistration reg = new AddRegistration();
                LibraryBusinessLogic libraryBL = new LibraryBusinessLogic();
                string name = nameTextBox.Text;
                int number=0;
                if (!int.TryParse(universityNumberTextBox.Text, out number))
                    throw new Exception("University Number should be numeric only");
                string emailID = emailIDTextBox.Text;
                string gender = "";
                string password;

                if (maleRadioButton.Checked == true)
                    gender = "Male";

                if (femaleradioButton.Checked == true)
                    gender = "female";

                if (!passwordTextBox.Text.Equals(reEnterPasswordTextBox.Text))
                    throw new Exception("Both Password don't match");

                password=passwordTextBox.Text;

                string address = addressTextBox.Text;

                int contact=0;

                if (!int.TryParse(contactNumberTextBox.Text, out contact))
                    throw new Exception("Contact Number should be numeric only");

                reg.StudentNumber = number;
                reg.StudentName = name;
                reg.EmailID = emailID;
                reg.Gender = gender;
                reg.Address = address;
                reg.ContactNumber = contact;
                reg.Password = password;

                if (libraryBL.RegistrationAdd(reg))
                {
                    Home home = new Home();
                    home.SetData("Student", number.ToString());
                    home.Show();
                    this.Dispose();
                    ClearData();
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ClearData()
        {
            nameTextBox.Clear();
            universityNumberTextBox.Clear();
            emailIDTextBox.Clear();
            contactNumberTextBox.Clear();
            addressTextBox.Clear();
            maleRadioButton.Checked = false;
            femaleradioButton.Checked = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
