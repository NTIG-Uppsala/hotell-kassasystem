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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kassasystem
{
    enum State
    {
        Default,
        Create,
        Edit
    }

    public partial class UserControlBooking : UserControl
    {
        private State state;
        private ListViewColumnSorter lvwColumnSorter;

        Booking newBooking = new Booking(); // FIXME spelling
        static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
        static string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
        Database databaseConnection = new Database(path, "database.db");
        Dictionary<Int64, Room> availableRoomsList = new Dictionary<Int64, Room>();
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

        public void updateUnpaidBookings()
        {
            unpaidBookings.Items.Clear();

            var unpaid = databaseConnection.GetUnpaidBookings();

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

                var bookingDates = databaseConnection.GetBookingDate(booking.Id);

                if (bookingDates == null) return;

                var item = new TypedListViewItem(booking.GuestFirstName,
                                                 booking.GuestLastName,
                                                 bookingDates[0],
                                                 bookingDates[1]);
                item.Tag = booking;
                unpaidBookings.Items.Add(item);
            }
        }

        public void updatePaidBookings()
        {
            paidBookings.Items.Clear();

            var paid = databaseConnection.GetPaidBookings();
          
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

                var bookingDates = databaseConnection.GetBookingDate(booking.Id);

                if (bookingDates == null) return;

                var item = new TypedListViewItem(booking.GuestFirstName,
                                                 booking.GuestLastName,
                                                 bookingDates[0],
                                                 bookingDates[1]);
                item.Tag = booking;
                paidBookings.Items.Add(item);
            }
        }

        private void AvailableRooms()
        {
            availableRooms.Items.Clear();
            MessageBox.Show("ran available rooms");
            var rooms = databaseConnection.GetAvailableRooms(convertDateToEpoch(dateTimePicker1.Value), convertDateToEpoch(dateTimePicker2.Value));
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
            state = State.Create;
            btnSave.Show();
            btnCancelBooking.Show();
            inputFirstName.Show();
            inputLastName.Show();
            label3.Show();
            label4.Show();
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

            if (state == State.Create)
            {
                databaseConnection.CreateNewBooking(roomData.Id,
                    inputFirstName.Text,
                    inputLastName.Text,
                    convertDateToEpoch(dateTimePicker2.Value),
                    convertDateToEpoch(dateTimePicker1.Value),
                    CalculateRoomPrice(roomData.Rate, CalculateNights(dateTimePicker2.Value, dateTimePicker1.Value)));
            }
            else if (state == State.Edit)
            {
                if (unpaidBookings.SelectedItems.Count == 0) return;
                var selectedBooking = (Booking)unpaidBookings.SelectedItems[0].Tag;
                databaseConnection.EditBooking(
                    inputFirstName.Text,
                    inputLastName.Text,
                    convertDateToEpoch(dateTimePicker2.Value),
                    convertDateToEpoch(dateTimePicker1.Value),
                    CalculateRoomPrice(roomData.Rate, CalculateNights(dateTimePicker2.Value, dateTimePicker1.Value)),
                    selectedBooking.Id);
            }
            
            state = State.Default;
            btnSave.Hide();
            btnCancelBooking.Hide();
            inputFirstName.Hide();
            inputLastName.Hide();
            label3.Hide();
            label4.Hide();
            availableRooms.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();

            updateUnpaidBookings();
            updatePaidBookings();
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

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the selected booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var selectedId = (Booking)unpaidBookings.SelectedItems[0].Tag;
                databaseConnection.RemoveBooking(selectedId.Id);
                updateUnpaidBookings();
                updatePaidBookings();
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            state = State.Default;
            btnSave.Hide();
            btnCancelBooking.Hide();

            label3.Hide();
            label4.Hide();

            inputFirstName.Hide();
            inputFirstName.Clear();

            inputLastName.Hide();
            inputLastName.Clear();

            availableRooms.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            state = State.Edit;
            if (unpaidBookings.SelectedItems.Count == 0) return;
           
            btnSave.Show();
            btnCancelBooking.Show();
            inputFirstName.Show();
            inputLastName.Show();
            label3.Show();
            label4.Show();
            availableRooms.Show();
            dateTimePicker1.Show();
            dateTimePicker2.Show();

            var selectedBooking = (Booking)unpaidBookings.SelectedItems[0].Tag;

            inputFirstName.Text = selectedBooking.GuestFirstName;
            inputLastName.Text = selectedBooking.GuestLastName;

            var bookingDates = databaseConnection.GetSelectedBookingDates(selectedBooking.Id);
            var val1 = bookingDates["dateFrom"];
            var val2 = bookingDates["dateTo"];

            string? dateFromStr = val1.ToString();
            string? dateToStr = val2.ToString();

            if (dateFromStr == null || dateToStr == null)
                return;

            long dateFrom2 = long.Parse(dateFromStr);
            long dateTo2 = long.Parse(dateToStr);

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(dateFrom2);
            DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeSeconds(dateTo2);
            dateTimePicker1.Value = dateTimeOffset2.DateTime;
            dateTimePicker2.Value = dateTimeOffset.DateTime;

            AvailableRooms();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updatePaidBookings(); // FIXME This is very very very slow :-)

            for (int i = paidBookings.Items.Count - 1; i >= 0; i--)
            {
                var item = paidBookings.Items[i];
                item.Selected = false;

                int subItemCount = item.SubItems.Count;

                for (int i2 = 0; i2 < subItemCount; i2++)
                {
                    if (item.SubItems[i2].Text.ToLower().Contains(searchPaidBookings.Text.ToLower()))
                    {
                        item.Selected = true;
                        continue;
                    }
                }
                if (item.Selected == false)
                {
                    paidBookings.Items.Remove(item);
                }
            }
        }

        private void searchUnpaidBookings_TextChanged(object sender, EventArgs e)
        {
            updateUnpaidBookings(); // FIXME This is very very very slow :-)

            for (int i = unpaidBookings.Items.Count - 1; i >= 0; i--)
            {
                var item = unpaidBookings.Items[i];
                item.Selected = false;

                int subItemCount = item.SubItems.Count;

                for (int i2 = 0; i2 < subItemCount; i2++)
                {
                    if (item.SubItems[i2].Text.ToLower().Contains(searchUnpaidBookings.Text.ToLower()))
                    {
                        item.Selected = true;
                        continue;
                    }
                }
                if (item.Selected == false)
                {
                    unpaidBookings.Items.Remove(item);
                }
            }
        }
    }

}
