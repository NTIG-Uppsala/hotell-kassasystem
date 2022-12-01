using Microsoft.Win32;

namespace kassasystem
{
    public partial class hotelPaymentAndBookingSystem : Form
    {
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
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            //player.PlayLooping();
            CheckOutDayPicker.Value = DateTime.Now; 
        }

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
                listBox1.Items.Add($"{product.Key} {product.Value}x {Convert.ToInt64(bookingDays)} {dayFormat} {CalculateRoomPrice(product.Value, priceList[product.Key], bookingDays)}kr");
            }
            UpdateTotal();
        }

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

        private int GetDateDifference(DateTime dateCheck)
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(dateCheck.ToString().Split()[0]);
            int difference = (int)(theDate - today).TotalDays;
            return difference;
        }

        private void BtnClick(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            AddToCart(buttonText);
            
        }

        private void BtnRemove1xClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                string input = listBox1.SelectedItem.ToString();
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
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

        private void BtnRemoveClick(object sender, EventArgs e)
        {
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
        private void ResetValues()
        {
            cartDictionary.Clear();
            listBox1.Items.Clear();
            CheckOutDayPicker.Value = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            UpdateTotal();
        }
        private void BtnClearClick(object sender, EventArgs e)
        {
            ResetValues();
        }

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

        private void CheckOutDayPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateCartView();
        }
    }
}