using Microsoft.Win32;

namespace kassasystem
{
    public partial class Form1 : Form
    {
        internal Dictionary<string, int> priceList = new Dictionary<string, int>();
        internal Dictionary<string, int> cartDictionary = new Dictionary<string, int>();
        public int total_price = 0;
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
            foreach(KeyValuePair<string , int> product in cartDictionary) 
            {
                listBox1.Items.Add($"{product.Key} \t x{product.Value} \t {product.Value * priceList[product.Key]}kr");
            }
        }

        private void UpdateTotal()
        {
            this.total_price = 0;
            
            if( cartDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, int> product in cartDictionary)
                {
                    this.total_price += product.Value * priceList[product.Key];
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

        private void GetDateDifference()
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(CheckOutDayPicker.Value.ToString().Split()[0]);
            var difference = (theDate - today).TotalDays;
            System.Diagnostics.Debug.WriteLine(difference);
            System.Diagnostics.Debug.WriteLine(today, theDate.ToString());
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
            UpdateTotal();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            cartDictionary.Clear();
            listBox1.Items.Clear();
            UpdateTotal();
        }
    }
}