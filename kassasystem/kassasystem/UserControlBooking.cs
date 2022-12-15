using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kassasystem
{
    internal class Booking
    {
        public string BookerFirstName { get; set;}
        public string BookerLastName { get; set; }
        public int roomID { get; set; }
        public int checkinDate { get; set; }
        public int checkoutDate { get; set; }

    }

    public partial class UserControlBooking : UserControl
    {
        Booking newbooking = new Booking();
        Database databaseConnection = new Database();

        public UserControlBooking()
        {
            InitializeComponent();
            

        }
        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            btnSave.Show();
            inputFirstName.Show();
            inputLastName.Show();
            availableRooms.Show();
            dateTimePicker1.Show();
            dateTimePicker2.Show();

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;

            var rooms = databaseConnection.GetAvailableRooms(convertDateToEpoch(dateTimePicker1.Value), convertDateToEpoch(dateTimePicker2.Value));

            
            foreach (Room room in rooms)
            {
                availableRooms.Items.Add("");                
                System.Diagnostics.Debug.WriteLine($"{room.rate} {room.floor} {room.recommendedPeople} {room.number} {room.type}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            btnSave.Hide();
            inputFirstName.Hide();
            inputLastName.Hide();
            availableRooms.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            
        }

        private int convertDateToEpoch(DateTime date)
        {
            TimeSpan t = date - new DateTime(1970, 1, 1); // Time in seconds since january 1 1970
            int currentTimePeriod = ((int)t.TotalSeconds);
            return currentTimePeriod;
        }
    }
}
