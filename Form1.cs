using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        private bool trystd;
        private bool trycont;
        private bool tryage;
        
        
        public frmRegistration()
        {
            
            InitializeComponent();
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                 "BS Information Technology",
                 "BS Computer Science",
                 "BS Information Systems",
                 "BS in Accountancy",
                 "BS in Hospitality Management",
                 "BS in Tourism Management"
             };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

        }
        public long StudentNumber(string studNum)
        {
            try{
                _StudentNo = long.Parse(studNum);
                trystd = true;
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Invalid Input in StudentNo." + ex.Message);
                trystd = false;
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                    trycont = true;
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException ec)
            {
                MessageBox.Show("Invalid Input ContactNo." + ec.Message);
                trycont = false;
            }                
            
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                _Age = Int32.Parse(age);
                tryage = true;

    }
            catch (FormatException ez)
            {
                MessageBox.Show("Invalid Input in Age" + ez.Message);
                tryage = false;
            }
            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            StudentInformationClass.SetFullName = FullName(txtLastName.Text,
            txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = Convert.ToInt64(StudentNumber(txtStudentNo.Text));
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = Convert.ToInt64(ContactNo(txtContactNo.Text));
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyyMM-dd");
            
            if((trystd == true)&&(trycont == true)&&(tryage == true))
            {
                frmConfirmation frm = new frmConfirmation();
                frm.Show();
            }
          
            
        }
    }
}
