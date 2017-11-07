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
    public partial class ConfirmationLetter : Form
    {
        private Guest guest;
        public ConfirmationLetter()
        {
            InitializeComponent();
            //namelabel.Text = guest._name;
            refnotextBox.Text = "";
            arrivaldatetextBox.Text = "";
            departuredatetextBox.Text = "";
            totalcosttextBox.Text = "";
            rateperdatetextBox.Text = "";

        }

      

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void emailbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show( " Email Sent! " );
            ClearAll();
            this.Close();
        }

        private void faxbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Letter Faxed! ");
            ClearAll();
            this.Close();
        }

        private void postbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Letter Sent by Post! ");
            ClearAll();
            this.Close();
        }
        private void ClearAll()
        {
            refnotextBox.Text = "";
            arrivaldatetextBox.Text = "";
            departuredatetextBox.Text = "";
            totalcosttextBox.Text = "";
            rateperdatetextBox.Text = "";

        }


    }
}
