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
        }

        public void updateBookings()
        {
            paidBookings.Items.Clear();
            unpaidBookings.Items.Clear();

            var unpaid = databaseConnection.GetUnpaidBookings();
            var paid = databaseConnection.GetPaidBookings();

            // Listview test
            foreach (Booking booking in unpaid)
            {
                if (booking.GuestFirstName == null)
                {
                    MessageBox.Show("GuestFirstName is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] displayArray =
                {
                    Convert.ToString(booking.Id),
                    Convert.ToString(booking.GuestFirstName)
                };

                ListViewItem item = new ListViewItem(displayArray);
                item.Tag = booking;
                unpaidBookings.Items.Add(item);
            }

            foreach (Booking booking in paid)
            {
                if (booking.GuestFirstName == null)
                {
                    MessageBox.Show("GuestFirstName is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] displayArray =
                {
                    Convert.ToString(booking.Id),
                    Convert.ToString(booking.GuestFirstName)
                };

                ListViewItem item = new ListViewItem(displayArray);
                item.Tag = booking;
                paidBookings.Items.Add(item);
            }
        }

        private void AvailableRooms()
        {
            availableRooms.Items.Clear();

            var rooms = databaseConnection.GetAvailableRooms(convertDateToEpoch(dateTimePicker1.Value), convertDateToEpoch(dateTimePicker2.Value));

            foreach (Room room in rooms)
            {
                if (room.Type == null)
                {
                    MessageBox.Show($"Room {room.Number} type is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] displayArray =
                {                 
                    Convert.ToString(room.Number),
                    Convert.ToString(room.Type),
                    Convert.ToString(room.RecommendedPeople),
                    Convert.ToString(room.Floor),
                    Convert.ToString(room.Rate),
                    Convert.ToString(room.Id)
                };

                ListViewItem item = new ListViewItem(displayArray);
                item.Tag = room;
                availableRooms.Items.Add(item);
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

            AvailableRooms();
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

            if (inputFirstName.Text.Length <= 0 || inputLastName.Text.Length <= 0) {
                MessageBox.Show("Firstname input is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }


            if (inputLastName.Text.Length <= 0)
            {
                MessageBox.Show("Lastname input is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO error handling for date
            // FIXME make selection persistant

            var selectedRoom = availableRooms.SelectedItems[0];

            if (selectedRoom == null)
            {
                MessageBox.Show("selectedRoom is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var roomData = (Room) selectedRoom.Tag;
            MessageBox.Show(roomData.ToString(), "Test", MessageBoxButtons.OK, MessageBoxIcon.None);

            databaseConnection.CreateNewBooking(roomData.Id,
                inputFirstName.Text,
                inputLastName.Text,
                convertDateToEpoch(dateTimePicker2.Value),
                convertDateToEpoch(dateTimePicker1.Value),
                CalculateRoomPrice(roomData.Rate, CalculateNights(dateTimePicker2.Value, dateTimePicker1.Value))
            );

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
            AvailableRooms();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AvailableRooms();
        }

        private void btnRemoveBooking_Click(object sender, EventArgs e)
        {

        }
    }

}
