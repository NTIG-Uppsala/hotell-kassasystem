using Microsoft.Win32;

namespace kassasystem
{
    public partial class Form1 : Form
    {
        internal Dictionary<string, int> priceList = new Dictionary<string, int>();
        internal Dictionary<string, int> cartDictionary = new Dictionary<string, int>();
        PDFGenerator pdfGenerator = new PDFGenerator();

        public Double total_price = 0;
        public Form1()
        {
            InitializeComponent();
            this.priceList = new Dictionary<string, int>()
            {
                { "room 1 double bed", 1000 },
                { "room 2 single beds", 1000 },
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            //player.PlayLooping();
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
            this.total_price = 0;
            
            if( cartDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
                   
                    this.total_price += CalculateRoomPrice(product.Value, priceList[product.Key], GetDateDifference(CheckOutDayPicker.Value));
                }
            }

            this.lbl_total.Text = $"Total: {this.total_price}kr";
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

        private void btn_Click(object sender, EventArgs e)
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
        private void btn_clear_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            ResetValues();
            pdfGenerator.savePDF(listBox1);
        }

        private void CheckOutDayPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateCartView();
        }
    }
}