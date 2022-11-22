namespace kassasystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            player.PlayLooping();
        }

        private void btn_room_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("room");
        }

        private void btn_person_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("person");

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}