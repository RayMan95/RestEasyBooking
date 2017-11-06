using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking.PresentationLayer
{
    public partial class GuestListForm : Form
    {
        public enum FormStates
        {
            View = 0,
            Add = 1,
            Edit = 2,
            Delete = 3
        }

        public bool listFormClosed = false;
        private GuestController guestController;
        private Guest guest;
        private Collection<Guest> allGuests;
        private FormStates state;

        public GuestListForm(GuestController gController)
        {
            InitializeComponent();
            guestController = gController;
            allGuests = guestController.AllGuests;
            this.Load += GuestListForm_Load;
            this.Activated += GuestListForm_Activated;
            this.FormClosed += GuestListForm_FormClosed;
            state = FormStates.View;
        }

        private void GuestListForm_Load(object sender, EventArgs e)
        {
            this.Text = "Guest List";
        }

        private void GuestListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void GuestListForm_Activated(object sender, EventArgs e)
        {
            guestListView.View = View.Details;
            setUpGuestListView();
            ShowAll(false);

        }

        public void setUpGuestListView()
        {
            guestListView.Columns.Insert(0, "ID", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(1, "GuestAccountNumber", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(2, "Balance", 100, HorizontalAlignment.Left);
            guestListView.Columns.Insert(3, "Name", 150, HorizontalAlignment.Left);
            guestListView.Columns.Insert(4, "Phone", 100, HorizontalAlignment.Left);
            guestListView.Columns.Insert(5, "Email", 100, HorizontalAlignment.Left);
            guestListView.Columns.Insert(6, "Address", 150, HorizontalAlignment.Left);


            ListViewItem guestDetails;

            foreach (Guest g in allGuests)
            {
                guestDetails = new ListViewItem
                {
                    Text = g.ID.ToString()
                };
                guestDetails.SubItems.Add(g.GuestAccountNumber);
                guestDetails.SubItems.Add(g.Balance.ToString());
                guestDetails.SubItems.Add(g.Name);
                guestDetails.SubItems.Add(g.PhoneNumber);
                guestDetails.SubItems.Add(g.Email);
                guestDetails.SubItems.Add(g.Address);

                guestListView.Items.Add(guestDetails);
            }

            guestListView.Refresh();
            guestListView.GridLines = true;

        }

        private void ShowAll(bool value)
        {
            

        }
    }
}
