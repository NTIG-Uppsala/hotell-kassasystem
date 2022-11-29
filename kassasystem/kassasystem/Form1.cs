using Microsoft.Win32;

namespace kassasystem
{
    public partial class Form1 : Form
    {
        internal Dictionary<string, int> priceList = new Dictionary<string, int>();
        internal Dictionary<string, int> cartDictionary = new Dictionary<string, int>();
        private Double bookedDays = 0;
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

        private void UpdateCartView()
        {
            listBox1.Items.Clear();
            string dayFormat;
            foreach(KeyValuePair<string , int> product in cartDictionary) 
            {
                if (bookedDays == 1)
                {
                    dayFormat = "day";
                } else
                {
                    dayFormat = "days";
                }
                listBox1.Items.Add($"{product.Value}x {product.Key} {bookedDays} {dayFormat} {product.Value * priceList[product.Key] + bookedDays * 500.0f}kr");
            }
        }

        private void UpdateTotal()
        {
            this.total_price = 0;
            
            if( cartDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
                    this.total_price += product.Value * priceList[product.Key] + bookedDays * 500.0f;
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

        private Double GetDateDifference(DateTime dateCheck)
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(dateCheck.ToString().Split()[0]);
            Double difference = (theDate - today).TotalDays;
            return difference;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            AddToCart(buttonText);
            UpdateTotal();
            
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
            UpdateTotal();

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
            UpdateTotal();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            cartDictionary.Clear();
            listBox1.Items.Clear();
            bookedDays = 0;
            UpdateTotal();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            cartDictionary.Clear();
            listBox1.Items.Clear();
            bookedDays = 0;
            UpdateTotal();
        }

        private void CheckOutDayPicker_ValueChanged(object sender, EventArgs e)
        {
            Double nogontingvadsomhelst = GetDateDifference(CheckOutDayPicker.Value);
            bookedDays = nogontingvadsomhelst;
            if (bookedDays >= 1) 
            { 
                btn_two_single_beds.Enabled = true;
                btn_double_bed.Enabled = true;
            } else
            {
                btn_two_single_beds.Enabled = false;
                btn_double_bed.Enabled = false;
            }
        }
    }
}