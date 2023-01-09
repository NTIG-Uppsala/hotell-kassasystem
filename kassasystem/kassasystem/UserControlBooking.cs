using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kassasystem
{


    public partial class UserControlBooking : UserControl
    {
        Booking newbooking = new Booking(); // FIXME spelling
        Database databaseConnection = new Database();
        Dictionary<Int64, Room> avaliableRoomsList = new Dictionary<Int64, Room>(); // FIXME spelling
                                                                                    // REFACTOR
        public UserControlBooking()
        {
            InitializeComponent();
            
        }

        private void getAvaliableRooms()
        {

            availableRooms.Items.Clear();

            var rooms = databaseConnection.GetAvailableRooms(convertDateToEpoch(dateTimePicker1.Value), convertDateToEpoch(dateTimePicker2.Value));


            foreach (Room room in rooms)
            {
                availableRooms.Items.Add($"{room.id} {room.type} {room.rate} kr / night {room.recommendedPeople} people floor {room.floor} number {room.number}");
                System.Diagnostics.Debug.WriteLine($"{room.id} {room.type} {room.rate} kr / night {room.recommendedPeople} people floor {room.floor} number {room.number}");

                if (!avaliableRoomsList.ContainsKey(room.id)) { avaliableRoomsList.Add(room.id, room); }

            }

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

            getAvaliableRooms();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // REFACTOR
            btnSave.Hide();
            inputFirstName.Hide();
            inputLastName.Hide();
            availableRooms.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();

            // REFACTOR
            if (inputFirstName.Text.Length <= 0) return;
            if (inputLastName.Text.Length <= 0) return;
            if (availableRooms.SelectedIndex == -1) return;

            //TODO error handling for date

            var selectedRoom = availableRooms.SelectedItem.ToString().Split(' ')[0]; // TODO null check  
                                                                                     // FIXME make selection persistant
            foreach (KeyValuePair<Int64, Room> room in avaliableRoomsList)
            {
                if (selectedRoom == Convert.ToString(room.Value.id))
                {
                    databaseConnection.CreateNewBooking(room.Value.id,
                            inputFirstName.Text,
                            inputLastName.Text,
                            convertDateToEpoch(dateTimePicker2.Value),
                            convertDateToEpoch(dateTimePicker1.Value),
                            CalculateRoomPrice(room.Value.rate, CalculateNights(dateTimePicker2.Value, dateTimePicker1.Value))
                        );
                }

            }

        }

        private Decimal CalculateRoomPrice(Decimal roomPrice, int nights)
        {
            Decimal formula = roomPrice + (roomPrice * nights); // TODO check price with PO
            return formula;
        }

        private int CalculateNights(DateTime startDate, DateTime endDate)
        {
            TimeSpan t = endDate - startDate;
            int currentTimePeriod = (int)t.TotalDays;
            return currentTimePeriod;
        }

        private int convertDateToEpoch(DateTime date)
        {
            TimeSpan t = date - new DateTime(1970, 1, 1); // Time in seconds since january 1 1970
                                                          // REFACTOR static/readonly
            int currentTimePeriod = (int)t.TotalSeconds;
            return currentTimePeriod;
        }

        // REFACTOR combine dateTimePicker2- and dateTimePicker1_ValueChanged
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            getAvaliableRooms();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getAvaliableRooms();
        }
    }

}
