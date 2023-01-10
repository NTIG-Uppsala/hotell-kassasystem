using System;
using System.Transactions;
using System.Windows.Forms;
using System.Data.SQLite;
using kassasystem;
using System.Data.Common;

namespace kassasystem_test
{
    public class Tests
    {
        hotelPaymentAndBookingSystem _form;

        private void QueryExecutor(string[] commands)
        {

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
            string filePath = string.Format(@"{0}{1}", path, "database.db");

            var db = new SQLiteConnection($"Data Source={filePath};");
            db.Open();
            using (DbCommand cmd = db.CreateCommand())
            {
                foreach (string query in commands)
                {
                    cmd.CommandText += query;
                    
                }
                cmd.ExecuteReader();
            }
            db.Close();
        }

        [SetUp]
        public void Setup()
        {
            _form = new hotelPaymentAndBookingSystem();
            _form.Show();
        }

        [Test]
        public void testBookAndRemoveBooking()
        {
            _form.BtnBooking.PerformClick();
            _form.userControlBooking1.btnNewBooking.PerformClick();

            string firstName = "bertil";
            string secondName = "karlsson";
            _form.userControlBooking1.inputFirstName.Text = firstName;
            _form.userControlBooking1.inputLastName.Text = secondName;

            Random random = new Random();
            int index = random.Next(0, _form.userControlBooking1.availableRooms.Items.Count);
            _form.userControlBooking1.availableRooms.SelectedIndex = index;

            _form.userControlBooking1.btnSave.PerformClick();

            _form.btnPayment.PerformClick();
            _form.userControlPayment1.bookingsList.SelectedIndex = _form.userControlPayment1.bookingsList.Items.Count - 1;
            _form.userControlPayment1.button1.PerformClick();

            string[] commands =
            {
                "DELETE FROM guests WHERE guestID = (SELECT MAX(guestID) FROM guests);"
            };

            QueryExecutor(commands);
        }

        [Test]
        public void testBookAndPayBooking()
        {
            _form.BtnBooking.PerformClick();
            _form.userControlBooking1.btnNewBooking.PerformClick();

            string firstName = "bertil";
            string secondName = "karlsson";
            _form.userControlBooking1.inputFirstName.Text = firstName;
            _form.userControlBooking1.inputLastName.Text = secondName;

            Random random = new Random();
            int index = random.Next(0, _form.userControlBooking1.availableRooms.Items.Count);
            _form.userControlBooking1.availableRooms.SelectedIndex = index;

            _form.userControlBooking1.btnSave.PerformClick();

            _form.btnPayment.PerformClick();
            _form.userControlPayment1.bookingsList.SelectedIndex = _form.userControlPayment1.bookingsList.Items.Count - 1;
            _form.userControlPayment1.btnSendToPaymentList.PerformClick();
            _form.userControlPayment1.btnPay.PerformClick();

            string[] commands =
            {
                "DELETE FROM roomsBooked WHERE roomsBookedID = (SELECT MAX(roomsBookedID) From roomsBooked);",
                "DELETE FROM bookings WHERE guestID = (SELECT MAX(guestID) FROM bookings);",
                "DELETE FROM guests ORDER BY guestID DESC limit 1"
            };

            QueryExecutor(commands);
        }
        
        //[Test]
        //public void testClickClearButton()
        //{

        //    _form.btnTest.PerformClick();

        //    _form.btnClear.PerformClick();

        //    Assert.That((_form.listBox1.Items.Count == 0), Is.True);
        //    Assert.That(_form.lblTotal.Text, Is.EqualTo("Total: 0kr"));
        //}

        //[Test]
        //public void test_remove_1x()
        //{
        //    if (_form.BtnRemove1x.Visible)
        //    {
        //        _form.btnTest.PerformClick();
        //        _form.btnTest.PerformClick();

        //        _form.listBox1.SelectedItem = _form.listBox1.Items[0];

        //        _form.BtnRemove1x.PerformClick();

        //        Assert.That(_form.cartDictionary[_form.btnTest.Text], Is.EqualTo(1));
        //    }
        //    else
        //    {
        //        Assert.Fail("Remove 1x not visible");
        //    }
        //}

        //[Test]
        //public void test_remove_all()
        //{
        //    if (_form.BtnRemoveAll.Visible)
        //    {
        //        _form.btnTest.PerformClick();
        //        _form.btnTest.PerformClick();

        //        Assert.That(_form.cartDictionary[_form.btnTest.Text], Is.EqualTo(2));

        //        _form.listBox1.SelectedItem = _form.listBox1.Items[0];

        //        _form.BtnRemoveAll.PerformClick();

        //        Assert.That(_form.cartDictionary.ContainsKey(_form.btnTest.Text), Is.False);
        //    }
        //    else
        //    {
        //        Assert.Fail("Remove all not visible");
        //    }
        //}

        //[Test]
        //public void addition()
        //{
        //    int firstValue = 1;
        //    int secondValue = 1;

        //    Assert.That(firstValue + secondValue, Is.EqualTo(2));
        //}
    }
}