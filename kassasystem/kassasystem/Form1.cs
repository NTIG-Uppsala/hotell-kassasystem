using Microsoft.Win32;

namespace kassasystem
{
    public partial class hotelPaymentAndBookingSystem : Form
    {
        // Dictionaries for prices and products
        public Dictionary<string, int> priceList = new Dictionary<string, int>();
        public Dictionary<string, int> cartDictionary = new Dictionary<string, int>();
        PDFGenerator pdfGenerator = new PDFGenerator();

        public Double totalPrice = 0;
        public hotelPaymentAndBookingSystem()
        {
            InitializeComponent();
            this.priceList = new Dictionary<string, int>()
            {
                { "Standard Single", 500 },
                { "Standard Double", 1000 },
                { "Standard Double Single", 1000 }
            };
        }

        private void Form1Load(object sender, EventArgs e)
        {   
            // Plays motivating music
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            player.PlayLooping();
            // Gets current date
            CheckOutDayPicker.Value = DateTime.Now; 
        }

        // Calculates price of room
        private Double CalculateRoomPrice(int roomAmount, int roomPrice, int days)
        {
            int pricePerNight = 200;
            var formula = (roomPrice * roomAmount) + (days * roomAmount * pricePerNight);
            return (int)Math.Round((decimal)formula);
        }

        private void UpdateCartView()
        {
            int bookingDays = GetDateDifference(CheckOutDayPicker.Value);

            listBox1.Items.Clear();
            string dayFormat;
            foreach(KeyValuePair<string , int> product in cartDictionary) 
            {
                if (bookingDays == 1)
                {
                    dayFormat = "day";
                } else
                {
                    dayFormat = "days";
                }
                // Adds products in formated order to list box
                listBox1.Items.Add($"{product.Key} {product.Value}x {Convert.ToInt64(bookingDays)} {dayFormat} {CalculateRoomPrice(product.Value, priceList[product.Key], bookingDays)}kr");
            }
            UpdateTotal();
        }

        // Keeps the total price up to date
        private void UpdateTotal()
        {
            this.totalPrice = 0;
            
            if( cartDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
                   
                    this.totalPrice += CalculateRoomPrice(product.Value, priceList[product.Key], GetDateDifference(CheckOutDayPicker.Value));
                }
            }

            this.lblTotal.Text = $"Total: {this.totalPrice}kr";
        }

        // Adds to the of amount of products in list box when product is already present
        private void AddToCart(string productName)
        {
            if (cartDictionary.ContainsKey(productName))
            {
                cartDictionary[productName]++;
            } else
            {
                cartDictionary.Add(productName, 1);
            }
            UpdateCartView();
        }

        // Checks differnce between current date and checkout date
        private int GetDateDifference(DateTime dateCheck)
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(dateCheck.ToString().Split()[0]);
            int difference = (int)(theDate - today).TotalDays;
            return difference;
        }

        // Adds correct product to listbox according to the pressed button
        private void BtnClick(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            AddToCart(buttonText);
            
        }

        // Removes one instance of selected product amount
        private void BtnRemove1xClick(object sender, EventArgs e)
        {
            // Button only functions if one product is selected
            if (listBox1.SelectedItems.Count == 1)
            {
                string input = listBox1.SelectedItem.ToString();
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
                    // Removes one instance, and clears the product if the amount reults as zero
                    if(input.Contains(product.Key))
                    {
                        int currentValue = product.Value;
                        cartDictionary[product.Key] = currentValue - 1;

                        if (cartDictionary[product.Key] == 0)
                        {
                            cartDictionary.Remove(product.Key);
                        }
                    }
                }
            }
            UpdateCartView();

        }

        // Removes every instance of selected product
        private void BtnRemoveClick(object sender, EventArgs e)
        {
            // Button only functions if one product is selected
            if (listBox1.SelectedItems.Count == 1)
            {
                string input = listBox1.SelectedItem.ToString();
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
                    if (input.Contains(product.Key))
                    {
                        cartDictionary.Remove(product.Key);
                    }
                }
            }
            UpdateCartView();
        }

        // Resets the entire list box
        private void ResetValues()
        {
            cartDictionary.Clear();
            listBox1.Items.Clear();
            CheckOutDayPicker.Value = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
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
            if (listBox1.Items.Count > 0)
            {
                pdfGenerator.savePDF(listBox1, totalPrice);
                ResetValues();
            } else
            {
                // TODO: show message cart empty

            }
        }

        // Keeps amount of days up to date
        private void CheckOutDayPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateCartView();
        }
    }
}