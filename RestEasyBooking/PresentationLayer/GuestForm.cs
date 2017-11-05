using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking.PresentationLayer
{
    public partial class GuestForm : Form
    {

        private Guest guest;
        public bool guestFormClosed = false;
        public GuestForm()
        {
            InitializeComponent();
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {

        }

        private void PopulateObject()
        {

            guest.setValues(accounttextBox.Text, nametextBox.Text, phonenumbertextBox.Text ,emailtextBox.Text, addresstextBox.Text);

                          

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            ClearAll();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            guestFormClosed = true;
            ClearAll();
            this.Close();
        }

        private void ClearAll()
        {
            accounttextBox.Text = "";
            nametextBox.Text = "";
            phonenumbertextBox.Text = "";
            emailtextBox.Text = "";
            addresstextBox.Text = "";
            
        }
    }
}
