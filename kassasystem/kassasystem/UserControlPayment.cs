using System.Globalization;

namespace kassasystem
{

    public partial class UserControlPayment : UserControl
    {   
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
        }

        private void Form1Load(object sender, EventArgs e)
        {

        }

        // Calculates price of room
        private Decimal CalculateRoomPrice(Decimal roomPrice, int nights)
        {
            Decimal formula = roomPrice + (roomPrice * nights);
            return formula;
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

        // Adds to the of amount of products in list box when product is already present
        //private void AddToCart(string productName)
        //{
        //    cartDictionary.Add(productName, 1);
        //    UpdateCartView();
        //}

        // Checks differnce between current date and checkout date
        private int GetDateDifference(DateTime dateCheck)
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(dateCheck.ToString().Split()[0]);
            int difference = (int)(theDate - today).TotalDays;
            return difference;
        }

        // Adds correct product to listbox according to the pressed button
        //private void BtnClick(object sender, EventArgs e)
        //{
        //    var button = sender as Button;
        //    if (button == null)
        //    {
        //        MessageBox.Show("Button text is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    string buttonText = button.Text;
        //    AddToCart(buttonText);

        //}

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

        // Keeps amount of days up to date
        private void CheckOutDayPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateCartView();
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

        //private void bookingsList_SelectedIndexChanged(object sender, EventArgs e) 
        //{
        //    if (bookingsList.SelectedItems.Count == 1) // REFACTOR invert
        //    {
        //        System.Diagnostics.Debug.WriteLine($"INDEX SELECTED FROM BOOKING LIST {bookingsList.SelectedIndex.ToString()}");
        //        cartDictionary.Clear();
        //        if (bookingsList.SelectedItem == null) return;
        //        var bookingItem = (BookingItem)bookingsList.SelectedItem;
        //        if (bookingItem == null) return;
        //        Booking? selectedBooking = bookingItem.BookingObject;
        //        //System.Diagnostics.Debug.WriteLine($"ITEM SELECTED {selectedBooking.ToString()}");

        //        if (selectedBooking != null) // REFACTOR invert
        //        {
        //            this.selectedBooking = selectedBooking;
        //        }
        //        else
        //        {
        //            //
        //        }
        //    };
        //}

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

        private void btnRmBooking_click(object sender, EventArgs e)
        {
            if (selectedBooking == null) return;

            db.RemoveBooking(selectedBooking.Id);
            updateUnpaidBookings();
            ResetValues();
        }

    }
}
