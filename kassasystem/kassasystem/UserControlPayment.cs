using System.Globalization;

namespace kassasystem
{

    public partial class UserControlPayment : UserControl
    {
        private ListViewColumnSorter lvwColumnSorter;

        // Dictionaries for prices and products
        public Dictionary<string, int> priceList = new Dictionary<string, int>();
        public Dictionary<string, Booking> cartDictionary = new Dictionary<string, Booking>();
        PDFGenerator pdfGenerator = new PDFGenerator();

        static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
        static string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
        public Database db = new Database(path, "database.db");

        Booking? selectedBooking;

        public Decimal totalPrice = 0;
        public UserControlPayment()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.bookingsList.ListViewItemSorter = lvwColumnSorter;
        }

        private void UpdateCartView()
        {
            if (selectedBooking == null) return;
            
            var culture = new CultureInfo("en-US");

            listView1.Items.Clear();

            foreach (KeyValuePair<string, Booking> product in cartDictionary)
            {
                Booking booking = product.Value;

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

                db.GetBookingDate(booking.Id);

                string[] displayArray =
                {
                    Convert.ToString(booking.Id),
                    Convert.ToString(booking.GuestFirstName),
                    Convert.ToString(booking.GuestLastName),
                    Convert.ToString(booking.AmountDue),

                };
                ListViewItem item = new ListViewItem(displayArray);
                item.Tag = booking;
                // Adds products in formated order to list box
                listView1.Items.Add(item);
            }
            UpdateTotal();
        }

        // Keeps the total price up to date
        private void UpdateTotal()
        {
            var culture = new CultureInfo("en-US");

            if (selectedBooking == null) return;

            totalPrice = 0.00M;

            if (cartDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, Booking> product in cartDictionary)
                {
                    decimal price = product.Value.AmountDue;
                    
                    totalPrice += price;
                }
            }
            lblTotal.Text = $"Total: {totalPrice.ToString("0.00", culture)} SEK";
        }

        // Checks differnce between current date and checkout date
        private int GetDateDifference(DateTime dateCheck)
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(dateCheck.ToString().Split()[0]);
            int difference = (int)(theDate - today).TotalDays;
            return difference;
        }

        // Resets the entire list box
        private void ResetValues()
        {
            cartDictionary.Clear();
            listView1.Items.Clear();
            //CheckOutDayPicker.Value = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            UpdateTotal();
        }

        // Calls reset function
        private void BtnClearClick(object sender, EventArgs e)
        {
            ResetValues();
        }

        // Makes PDF reciept when button is pressed, then calls reset function
        private void BtnPayClick(object sender, EventArgs e)
        {
            if (selectedBooking == null)
            {
                MessageBox.Show("The cart is empty!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listView1.Items.Count > 0) // REFACTOR invert
            {
                db.SaveReceiptData(selectedBooking.Id, totalPrice);
                db.SetBookingPaid(selectedBooking.PaymentId);

                pdfGenerator.savePDF(selectedBooking);

                ResetValues();
                updateUnpaidBookings();
            }
        }

        private void btnSendToPaymentList_Click(object sender, EventArgs e)
        {

            if (bookingsList.SelectedItems.Count == 1) // REFACTOR invert
            {
                cartDictionary.Clear();

                var data = (Booking)bookingsList.SelectedItems[0].Tag;

                if (bookingsList.SelectedItems[0] == null) return;
                Booking? selectedBooking = data;

                if (selectedBooking == null) return; // REFACTOR invert
                
                cartDictionary.Add(Convert.ToString(data.Id), data);
                this.selectedBooking = selectedBooking;
                UpdateCartView();


            };

        }

        public void updateUnpaidBookings()
        {
            bookingsList.Items.Clear();

            var data = db.GetUnpaidBookings();

            foreach (Booking booking in data)
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

                string[] dateData = db.GetBookingDate(booking.Id);

                string[] displayArray =
                {
                    Convert.ToString(booking.Id),
                    Convert.ToString(booking.GuestFirstName),
                    Convert.ToString(booking.GuestLastName),
                    dateData[0],
                    dateData[1]
                };

                ListViewItem item = new ListViewItem(displayArray);
                item.Tag = booking;
                bookingsList.Items.Add(item);
            }
        }

        private void UserControlPayment_Load(object sender, EventArgs e)
        {
            updateUnpaidBookings();
        }

        private void bookingsList_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.bookingsList.Sort();
        }
    }
}
