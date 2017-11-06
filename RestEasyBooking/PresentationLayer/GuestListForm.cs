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
        public bool listFormClosed = false;
        private GuestController guestController;
        private Collection<Guest> allGuests;

        public GuestListForm(GuestController gController)
        {
            InitializeComponent();
            guestController = gController;
            allGuests = guestController.AllGuests;
            this.Load += GuestListForm_Load;
            this.Activated += GuestListForm_Activated;
            this.FormClosed += GuestListForm_FormClosed;
            this.AutoSize = true;
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
            SetUpDataGridView();

        }

        public void SetUpDataGridView()
        {
            // Formatting
            guestDataGridView.RowsDefaultCellStyle.BackColor = Color.Bisque;
            guestDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            guestDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;

            guestDataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            guestDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            guestDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            guestDataGridView.AllowUserToResizeColumns = false;
            guestDataGridView.AutoSize = true;
            guestDataGridView.CellClick += GuestDataGridView_CellClick;

            // Columns
            guestDataGridView.ColumnCount = 7;
            guestDataGridView.Columns[0].Name = "ID";
            guestDataGridView.Columns[1].Name = "GuestAccountNumber";
            guestDataGridView.Columns[0].ReadOnly = true;
            guestDataGridView.Columns[1].ReadOnly = true;
            guestDataGridView.Columns[2].Name = "Balance";
            guestDataGridView.Columns[3].Name = "Name";
            guestDataGridView.Columns[4].Name = "Phone";
            guestDataGridView.Columns[5].Name = "Email";
            guestDataGridView.Columns[6].Name = "Address";
            // Button Columns
            DataGridViewButtonColumn editGridViewButtonColumn = new DataGridViewButtonColumn();
            guestDataGridView.Columns.Add(editGridViewButtonColumn);
            editGridViewButtonColumn.Text = "Edit";
            editGridViewButtonColumn.Name = "Edit";
            editGridViewButtonColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn deleteGridViewButtonColumn = new DataGridViewButtonColumn();
            guestDataGridView.Columns.Add(deleteGridViewButtonColumn);
            deleteGridViewButtonColumn.Text = "Delete";
            deleteGridViewButtonColumn.Name = "Delete";
            deleteGridViewButtonColumn.UseColumnTextForButtonValue = true;

            // Rows
            foreach (Guest g in allGuests)
            {
                guestDataGridView.Rows.Add(new string[] {g.ID.ToString(), g.GuestAccountNumber, g.Balance.ToString(), g.Name,
                    g.PhoneNumber, g.Email, g.Address});
            }
        }

        private void GuestDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) // Edit
            {
                Guest guestToEdit = allGuests[e.RowIndex];
                GuestForm guestForm = new GuestForm(guestToEdit, guestController, GuestForm.FormStates.Edit);
                //guestForm.TopLevel = false;
                guestForm.ShowDialog(this);
                //guestForm.Owner = this;

            }

            else if (e.ColumnIndex == 8) // Delete
            {
                Guest guestToDelete = allGuests[e.RowIndex];
                var confirmResult = MessageBox.Show("Are you sure to delete this Guest Account?",
                                     "Confirm Delete Guest Record",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        guestController.DataMaintenance(guestToDelete, DatabaseLayer.DB.DBOperation.Delete);
                        guestDataGridView.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Guest with account number: " + guestToDelete.GuestAccountNumber + " deleted",
                            "Guest Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch(Exception exception)
                    {

                    }
                }
                else
                {
                    // do nothing
                }
            }
        }
    }
}
