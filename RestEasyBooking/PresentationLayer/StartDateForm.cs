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
    public partial class StartDateForm : Form
    {

        private RoomController roomController;
        private BookingForm bookForm;
        public bool startFormClosed = false;
        public StartDateForm()
        {
            InitializeComponent();
            roomController = new RoomController();
            bookForm = new BookingForm();
        }

        private void StartDateForm_Load(object sender, EventArgs e)
        {

        }

        private void startdateCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (BookingForm.last)
            {
                
                numberofroomslabel.Text = "" + roomController.RoomsAvailableThroughout(startdateCalendar.SelectionRange.Start, startdateCalendar.SelectionRange.Start).Count;
                bookForm.FirstDate = startdateCalendar.SelectionRange.Start;
                MessageBox.Show(bookForm.GetFirstDate +" firstDAte! "+ startdateCalendar.SelectionRange.Start);
            }
            else
            {

                numberofroomslabel.Text = "" + roomController.RoomsAvailableThroughout(bookForm.GetFirstDate, startdateCalendar.SelectionRange.Start).Count;
                bookForm.LastDate = startdateCalendar.SelectionRange.Start;
                MessageBox.Show(bookForm.GetLastDate + " End Date! "+ bookForm.GetFirstDate);
            }
        }


        private void confirmbutton_Click(object sender, EventArgs e)
        {
          
            startFormClosed = true;
            this.Close();
        }
    }
}
