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
    public partial class HomeMDIParent : Form
    {
        private int childFormNumber = 0;

        private BookingForm bookingForm;
        private GuestForm guestForm;
        private StartDateForm startDateForm;
        private GuestForm employeeListForm;
        private PaymentForm paymentForm;
       // private GuestController guestController;

        public HomeMDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingForm == null)
            {
                CreateNewBookingForm();
            }
            bookingForm.Show();

        }

        private void CreateNewBookingForm()
        {
            bookingForm = new BookingForm();
            bookingForm.MdiParent = this;        // Setting the MDI Parent
            bookingForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guestForm == null)
            {
                CreateNewGuestForm();
            }
            guestForm.Show();
        }
        private void CreateNewGuestForm()
        {
            guestForm = new GuestForm();
            guestForm.MdiParent = this;        // Setting the MDI Parent
            guestForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void makePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(paymentForm == null)
            {
                MakePaymentForm();
            }
            paymentForm.Show();

        }

        private void MakePaymentForm()
        {
            paymentForm = new PaymentForm();
            paymentForm.MdiParent = this;        // Setting the MDI Parent
            paymentForm.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
