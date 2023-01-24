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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == paymentPage)
            {
                userControlPayment1.Show();
                userControlPayment1.Refresh();
                userControlPayment1.BringToFront();
                userControlBooking1.Hide();
                userControlPayment1.updateUnpaidBookings();
            }
            else if (e.TabPage == bookingManagementPage)
            {
                userControlBooking1.Show();
                userControlBooking1.Refresh();
                userControlBooking1.BringToFront();
                userControlPayment1.Hide();
                userControlBooking1.updateUnpaidBookings();
                userControlBooking1.updatePaidBookings();
            }

        }
    }
}