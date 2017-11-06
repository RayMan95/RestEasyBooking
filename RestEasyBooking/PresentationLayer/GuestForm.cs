using RestEasyBooking.BusinessLayer;
using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking.PresentationLayer
{
    public partial class GuestForm : Form
    {

        public enum FormStates
        {
            View = 0,
            Add = 1,
            Edit = 2,
            Delete = 3
        }

        GuestController guestController;
        private Guest guest;
        public bool guestFormClosed = false;
        private FormStates state;

        #region Properties

        #endregion


        public GuestForm(Guest g, GuestController controller, FormStates formState)
        {
            guest = g;
            guestController = controller;
            InitializeComponent();
            state = formState;
            SetBoxes();
            idTextBox.LostFocus += IdTextBox_LostFocus;
            accounttextBox.LostFocus += AccounttextBox_LostFocus;
            emailtextBox.LostFocus += EmailtextBox_LostFocus;
            phonenumbertextBox.LostFocus += PhonenumbertextBox_LostFocus;
        }

        private void PhonenumbertextBox_LostFocus(object sender, EventArgs e)
        {
            if (phonenumbertextBox.Text.Length > 9)
            {
                phoneValidLabel.ForeColor = Color.Green;
                phoneValidLabel.Text = "Valid";
            }

            else
            {
                phoneValidLabel.ForeColor = Color.Red;
                phoneValidLabel.Text = "Invalid";
            }

        }

        #region Textbox events
        private void AccounttextBox_LostFocus(object sender, EventArgs e)
        {
            if (accounttextBox.Text.Length < 2 || accounttextBox.Text[0] != 'G')
            {
                accountValidLabel.ForeColor = Color.Red;
                accountValidLabel.Text = "Invalid";
            }

            else
            {
                accountValidLabel.ForeColor = Color.Green;
                accountValidLabel.Text = "Valid";
            }
        }
        

        private void IdTextBox_LostFocus(object sender, EventArgs e)
        {
            int n;
            if (idTextBox.Text.Length > 0 && int.TryParse(idTextBox.Text, out n))
            {
                idValidLabel.Text = "Valid";
                idValidLabel.ForeColor = Color.Green;
            }
            else
            {
                idValidLabel.Text = "Invalid";
                idValidLabel.ForeColor = Color.Red;
            }
        }

        private void EmailtextBox_LostFocus(object sender, EventArgs e)
        {
            if (emailtextBox.Text.Length > 4)
            {
                try
                {
                    MailAddress mailAddress = new MailAddress(emailtextBox.Text);
                    emailValidLabel.Text = "Valid";
                    emailValidLabel.ForeColor = Color.Green;
                }
                catch (FormatException fme)
                {
                    emailValidLabel.Text = "Invalid";
                    emaillabel.ForeColor = Color.Red;
                }
                
            }
            else
            {
                emailValidLabel.Text = "Invalid";
                emailValidLabel.ForeColor = Color.Red;
            }
        }
        #endregion

        private void BookingForm_Load(object sender, EventArgs e)
        {

        }

        private void PopulateObject()
        {
            switch (state)
            {
                case FormStates.Add:
                    int id = Convert.ToInt32(idTextBox.Text);
                    string guestAccountNumber = accounttextBox.Text;
                    double balance = 0;
                    GuestAccount guestAccount = new GuestAccount(guestAccountNumber, balance);
                    string name = nametextBox.Text + surnametextBox.Text;
                    string phoneNum = phonenumbertextBox.Text;
                    string email = emailtextBox.Text;
                    string address = addresstextBox.Text;


                    int refid = guestController.CreateID();
                    string referenceNumber = "r" + guestController.CreateID() + "" + guestController.CreateID();
                    guest = new Guest(id, guestAccount, name, phoneNum, email, address)
                    {
                        MyReferenceNumberDetails = new Entity.ReferenceNumberDetails()
                        {
                            ID = refid,
                            ReferenceNumber = referenceNumber
                        }
                    };
                    break;

                case FormStates.Edit:
                    id = Convert.ToInt32(idTextBox.Text);
                    guest = guestController.FindByID(id);
                    guestAccount = new GuestAccount(guest.GuestAccountNumber, guest.Balance);
                    name = nametextBox.Text + " " + surnametextBox.Text;
                    phoneNum = phonenumbertextBox.Text;
                    email = emailtextBox.Text;
                    address = addresstextBox.Text;
                    Entity.ReferenceNumberDetails referenceNumberDetails = guest.MyReferenceNumberDetails;

                    guest = new Guest(id, guestAccount, name, phoneNum, email, address)
                    {
                        MyReferenceNumberDetails = referenceNumberDetails
                    };
                    break;
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (idValidLabel.Text != "Invalid" && accountValidLabel.Text != "Invalid" && 
                phoneValidLabel.Text != "Invalid" && emailValidLabel.Text != "Invalid")
            {
                PopulateObject();
                ClearAll();

                DB.DBOperation operation;
                if (state == FormStates.Add) operation = DB.DBOperation.Add;
                else operation = DB.DBOperation.Edit;

                guestController.DataMaintenance(guest, operation);
            }
            else
            {
                MessageBox.Show("Please provide valid data", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            guestFormClosed = true;
            ClearAll();
            this.Close();
        }

        private void SetBoxes()
        {
            switch (state)
            {
                case FormStates.Add:
                    ClearAll();
                    break;

                case FormStates.Edit:
                    addbutton.Text = "Update";
                    idTextBox.Text = guest.ID.ToString();
                    idTextBox.ReadOnly = true;
                    string[] names = guest.Name.Split(' ');
                    accounttextBox.Text = guest.GuestAccountNumber;
                    accounttextBox.ReadOnly = true;
                    nametextBox.Text = names[0];
                    nametextBox.ReadOnly = true;
                    surnametextBox.Text = names[1];
                    surnametextBox.ReadOnly = true;
                    phonenumbertextBox.Text = guest.PhoneNumber;
                    surnametextBox.ReadOnly = false;
                    emailtextBox.Text = guest.Email;
                    surnametextBox.ReadOnly = false;
                    addresstextBox.Text = guest.Address;
                    surnametextBox.ReadOnly = false;
                    break;

                case FormStates.View:
                    idTextBox.Text = guest.ID.ToString();
                    idTextBox.ReadOnly = true;
                    names = guest.Name.Split(' ');
                    accounttextBox.Text = guest.GuestAccountNumber;
                    accounttextBox.ReadOnly = true;
                    nametextBox.Text = names[0];
                    nametextBox.ReadOnly = true;
                    surnametextBox.Text = names[1];
                    surnametextBox.ReadOnly = true;
                    phonenumbertextBox.Text = guest.PhoneNumber;
                    phonenumbertextBox.ReadOnly = true;
                    emailtextBox.Text = guest.Email;
                    emailtextBox.ReadOnly = true;
                    addresstextBox.Text = guest.Address;
                    addresstextBox.ReadOnly = true;
                    break;
            }
        }

        private void ClearAll()
        {
            idTextBox.Text = "";
            accounttextBox.Text = "";
            nametextBox.Text = "";
            surnametextBox.Text = "";
            phonenumbertextBox.Text = "";
            emailtextBox.Text = "";
            addresstextBox.Text = "";
            phoneValidLabel.Text = "";
            emailValidLabel.Text = "";
            idValidLabel.Text = "";
            accountValidLabel.Text = "";

        }

        private void phoneValidLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
