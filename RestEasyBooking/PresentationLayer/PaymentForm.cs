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

    
    public partial class PaymentForm : Form
    {

        private Guest guest;
        private ConfirmationLetter confirmLetter;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void generateConfirmationLetter()
        {
            confirmLetter = new ConfirmationLetter();
            confirmLetter.MdiParent = this;        // Setting the MDI Parent
            confirmLetter.StartPosition = FormStartPosition.CenterParent;
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if (confirmLetter == null)
            {
                generateConfirmationLetter();
            }
            confirmLetter.Show();
        }
    }
}
