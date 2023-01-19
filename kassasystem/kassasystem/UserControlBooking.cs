using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kassasystem
{


    public partial class UserControlBooking : UserControl
    {
        private ListViewColumnSorter lvwColumnSorter;

        Booking newbooking = new Booking(); // FIXME spelling
        static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
        static string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
        Database databaseConnection = new Database(path, "database.db");
        Dictionary<Int64, Room> avaliableRoomsList = new Dictionary<Int64, Room>(); // FIXME spelling
                                                                                    // REFACTOR
        public UserControlBooking()
        {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.availableRooms.ListViewItemSorter = lvwColumnSorter;
            this.unpaidBookings.ListViewItemSorter = lvwColumnSorter;
            this.paidBookings.ListViewItemSorter = lvwColumnSorter;
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

                if (booking.GuestLastName == null)
                {
                    MessageBox.Show("GuestLastName is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var item = new TypedListViewItem(booking.Id,
                                                 booking.GuestFirstName,
                                                 booking.GuestLastName);
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

                if (booking.GuestLastName == null)
                {
                    MessageBox.Show("GuestLastName is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var item = new TypedListViewItem(booking.Id,
                                                 booking.GuestFirstName,
                                                 booking.GuestLastName);
                item.Tag = booking;
                paidBookings.Items.Add(item);
            }
        }

        private void AvailableRooms()
        {
            availableRooms.Items.Clear();

            var rooms = databaseConnection.GetAvailableRooms(convertDateToEpoch(dateTimePicker1.Value), convertDateToEpoch(dateTimePicker2.Value));
            var culture = new CultureInfo("en-US");
            foreach (Room room in rooms)
            {
                if (room.Type == null)
                {
                    MessageBox.Show($"Room {room.Number} type is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var item = new TypedListViewItem(room.Number,
                                 room.Type,
                                 room.RecommendedPeople,
                                 room.Floor,
                                 room.Rate,
                                 room.Id);
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
            if (availableRooms.SelectedItems.Count == 0) return;
            var selectedRoom = availableRooms.SelectedItems[0];

            if (selectedRoom == null)
            {
                MessageBox.Show("selectedRoom is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var roomData = (Room) selectedRoom.Tag;

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

        private void availableRooms_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.availableRooms.Sort();
        }

        private void unpaidBookings_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.unpaidBookings.Sort();
        }

        private void paidBookings_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.paidBookings.Sort();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (unpaidBookings.SelectedItems.Count == 0) return;

            var selectedId = (Booking)unpaidBookings.SelectedItems[0].Tag;
            databaseConnection.RemoveBooking(selectedId.Id);
            updateBookings();
        }
    }

}
