namespace kassasystem
{
    public partial class Form1 : Form
    {
        internal Dictionary<string, int> price_list;
        public int total_price = 0;
        public Form1()
        {
            InitializeComponent();
            this.price_list = new Dictionary<string, int>()
            {
                { "person", 500 },
                { "room", 1000 }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            player.PlayLooping();
        }

        private void btn_room_Click(object sender, EventArgs e)
        {
            this.total_price += this.price_list["room"];
            this.lbl_total.Text = $"Total: {this.total_price}kr";
            listBox1.Items.Add("room");
        }

        private void btn_person_Click(object sender, EventArgs e)
        {
            this.total_price += this.price_list["person"];
            this.lbl_total.Text = $"Total: {this.total_price}kr";
            listBox1.Items.Add("person");

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.total_price = 0;
            this.lbl_total.Text = $"Total: {this.total_price}kr";
            listBox1.Items.Clear();
        }

    }
}