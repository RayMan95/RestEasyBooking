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
        public StartDateForm()
        {
            InitializeComponent();
            roomController = new RoomController();
        }

        private void StartDateForm_Load(object sender, EventArgs e)
        {

        }

        private void startdateCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            numberofroomslabel.Text =""+ roomController.RoomsAvailableThroughout(startdateCalendar.SelectionRange.Start, startdateCalendar.SelectionRange.Start).Count;
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
