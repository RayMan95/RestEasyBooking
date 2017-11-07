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
    public partial class BookingForm : Form
    {

        public bool BookingFormClosed = false;
       // private GuestController guestController ;
        private Guest guest;
        private Booking booking;
        private RoomController roomController;
        private StartDateForm startDateForm;
        private DateTime startDate;
        private DateTime endDate;
        public static bool last;
        public BookingForm()
        {
            InitializeComponent();
            roomController = new RoomController();
        }

        private void startdatebutton_Click(object sender, EventArgs e)
        {
            last = true;
            if (startDateForm == null)
            {
                selectDate();
            }
            if (startDateForm.startFormClosed)
            {
                selectDate();
            }
            startDateForm.Show();
            

        }
        private void selectDate()
        {
            startDateForm = new StartDateForm();
            
            startDateForm.StartPosition = FormStartPosition.CenterParent;
            
        }

        private void addbookingbutton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            ClearAll();
            this.Close();
        }
        public DateTime FirstDate
        {
            set { startDate = value; }
        }
        public DateTime GetFirstDate
        {
            get { return startDate; }
        }
        public DateTime LastDate
        {
            set { endDate = value; }
        }
        public DateTime GetLastDate
        {
            get { return endDate ; }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            ClearAll();
            this.Close();
        }
        private void ClearAll()
        {
            pricelabel.Text = "0.00";
            guestaccounttextBox.Text = "";
        

        }

        private void PopulateObject()
        {

            int room_id = -1;
            Collection<Room> availableRooms = roomController.RoomsAvailableThroughout(startDate, endDate);
            if (availableRooms.Count > 0) room_id = availableRooms[0].ID;
            //for loop roomController.RoomsAvailableThroughout(startDate, endDate).count
             bool m = roomController.BookRoom(room_id, startDate, endDate);
            booking = new Booking(Int32.Parse(idtextBox.Text), startDate, endDate, room_id, roomController.GetCost(startDate, endDate), false);
           /* {
                MyReferenceNumberDetails = new Entity.ReferenceNumberDetails()
                {
                    ID = GuestController.CreateID(),
                    ReferenceNumber = "R" + GuestController.CreateID() + "" + GuestController.CreatID()
                }
            };*/

            if(m)
            {
                MessageBox.Show("Booking made");

            }

        }


        
        private void endDatebutton_Click(object sender, EventArgs e)
        {
            last = false;
            if (startDateForm == null)
            {
                selectDate();
            }
            if (startDateForm.startFormClosed)
            {
                selectDate();
            }
            
            startDateForm.Show();
           

        }

        private void guestaccounttextBox_TextChanged(object sender, EventArgs e)
        {
            if (guestaccounttextBox.Text.Length > 0)
            {
                if (guestaccounttextBox.Text[0] != 'G')
                {
                    validlabel.ForeColor = Color.Red;
                    validlabel.Text = "Invalid";
                }
                if (guestaccounttextBox.Text[0] == 'G')
                {
                    
                    validlabel.Text = "";
                }
                if (guestaccounttextBox.Text.Length == 10)
                {
                    validlabel.ForeColor = Color.Green;
                    validlabel.Text = "Valid";
                }
            }
        }

        /*
         * 
         */

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(startDate+" End Date! "+ endDate);
            pricelabel.Text = "" + roomController.GetCost(startDate, endDate);
           
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {

        }

        private void startdateCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            numberofroomslabel.Text = "" + roomController.RoomsAvailableThroughout(dateCalendar.SelectionRange.Start, dateCalendar.SelectionRange.Start).Count;
            FirstDate = dateCalendar.SelectionRange.Start;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            numberofroomslabel.Text = "" + roomController.RoomsAvailableThroughout(GetFirstDate, calender.SelectionRange.Start).Count;
            LastDate = calender.SelectionRange.Start;
        }
    }
}
