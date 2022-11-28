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

        private void updateCartView()
        {
            listBox1.Items.Clear();
            foreach(KeyValuePair<string , int> product in cartDictionary) 
            {
                listBox1.Items.Add($"{product.Key} \t x{product.Value} \t {product.Value * priceList[product.Key]}kr");
            }
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
            updateCartView();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            AddToCart(buttonText);

            
            this.total_price += this.priceList[buttonText];
            this.lbl_total.Text = $"Total: {this.total_price}kr";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.total_price = 0;
            this.lbl_total.Text = $"Total: {this.total_price}kr";
            cartDictionary.Clear();
            listBox1.Items.Clear();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            this.total_price = 0;
            this.lbl_total.Text = $"Total: {this.total_price}kr";
            cartDictionary.Clear();
            listBox1.Items.Clear();
        }
    }
}