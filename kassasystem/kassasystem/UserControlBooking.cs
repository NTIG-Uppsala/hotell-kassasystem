using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kassasystem
{
    public partial class UserControlBooking : UserControl
    {
        public UserControlBooking()
        {
            InitializeComponent();
        }
        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            btnSave.Show();
            inputFirstName.Show();
            inputLastName.Show();
            availableRooms.Show();
            dateTimePicker1.Show();
            dateTimePicker2.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Hide();
            inputFirstName.Hide();
            inputLastName.Hide();
            availableRooms.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
        }
    }
}
