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
    public partial class BookingForm : Form
    {

        public bool BookingFormClosed = false;
       // private GuestController guestController ;
        private Guest guest;
        private StartDateForm startDateForm;
       
        public BookingForm()
        {
            InitializeComponent();
        }

        private void startdatebutton_Click(object sender, EventArgs e)
        {
            if (startDateForm == null)
            {
                selectDate();
            }
            startDateForm.Show();

        }
        private void selectDate()
        {
            startDateForm = new StartDateForm();
            startDateForm.MdiParent = this;        // Setting the MDI Parent
            startDateForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void addbookingbutton_Click(object sender, EventArgs e)
        {

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {

        }

        private void PopulateObject()
        {
            
        }
    }
}
