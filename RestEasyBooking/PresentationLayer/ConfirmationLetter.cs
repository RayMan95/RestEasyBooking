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
        public ConfirmationLetter()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void emailbutton_Click(object sender, EventArgs e)
        {
            ClearAll();
            this.Close();
        }

        private void faxbutton_Click(object sender, EventArgs e)
        {
            ClearAll();
            this.Close()
        }

        private void postbutton_Click(object sender, EventArgs e)
        {
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
