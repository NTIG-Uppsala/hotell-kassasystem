using Microsoft.Win32;
using System.Data;
using System.Data.SQLite;

namespace kassasystem
{
    public partial class hotelPaymentAndBookingSystem : Form
    {

        public hotelPaymentAndBookingSystem()
        {
 
            InitializeComponent();

        }

        private void Form1Load(object sender, EventArgs e)
        {   
            // Plays motivating music
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            // player.PlayLooping();
            // Gets current date
            // CheckOutDayPicker.Value = DateTime.Now; 
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            userControlPayment1.Show();
            userControlPayment1.BringToFront();
            userControlBooking1.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            userControlBooking1.Show();
            userControlBooking1.BringToFront();
            userControlPayment1.Hide();
        }
    }
}