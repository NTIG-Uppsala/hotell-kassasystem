using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kassasystem
{


    public partial class UserControlBooking : UserControl
    {
        Booking newbooking = new Booking(); // FIXME spelling
        static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
        static string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
        Database databaseConnection = new Database(path, "database.db");
        Dictionary<Int64, Room> avaliableRoomsList = new Dictionary<Int64, Room>(); // FIXME spelling
                                                                                    // REFACTOR
        public UserControlBooking()
        {
            InitializeComponent();

            unpaidBookings.DisplayMember = "displayName";
            unpaidBookings.ValueMember = "bookingObject";
            paidBookings.DisplayMember = "displayName";
            paidBookings.ValueMember = "bookingObject";
        }

        public void updateBookings()
        {
            unpaidBookings.Items.Clear();
            paidBookings.Items.Clear();

            var unpaid = databaseConnection.GetUnpaidBookings();
            var paid = databaseConnection.GetPaidBookings();

            foreach (Booking booking in unpaid)
            {
                unpaidBookings.Items.Add(new BookingItem
                {
                    displayName = Convert.ToString(booking.id) + ' ' + Convert.ToString(booking.guestFirstName) + ' ' + Convert.ToString(booking.guestLastName),
                    bookingObject = booking
                });
                
            }

            foreach (Booking booking in paid)
            {
                paidBookings.Items.Add(new BookingItem
                {
                    displayName = Convert.ToString(booking.id) + ' ' + Convert.ToString(booking.guestFirstName) + ' ' + Convert.ToString(booking.guestLastName),
                    bookingObject = booking
                });
            }
        }

        private void getAvaliableRooms()
        {

            availableRooms.Items.Clear();

            var rooms = databaseConnection.GetAvailableRooms(convertDateToEpoch(dateTimePicker1.Value), convertDateToEpoch(dateTimePicker2.Value));


            foreach (Room room in rooms)
            {
                availableRooms.Items.Add($"{room.id} {room.type} {room.rate} kr / night {room.recommendedPeople} people floor {room.floor} number {room.number}");
                // System.Diagnostics.Debug.WriteLine($"{room.id} {room.type} {room.rate} kr / night {room.recommendedPeople} people floor {room.floor} number {room.number}");

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

            if (inputFirstName.Text.Length <= 0 || inputLastName.Text.Length <= 0 || availableRooms.SelectedIndex == -1) return;

            // TODO error handling for date

            var selectedRoom = availableRooms.SelectedItem; // TODO null check  
                                                                                     // FIXME make selection persistant
            if (selectedRoom == null || selectedRoom.ToString() == null)
            {
                MessageBox.Show("selectedRoom is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            selectedRoom = selectedRoom.ToString().Split(' ')[0];
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

            updateBookings();


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
