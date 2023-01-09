using System;
using System.Transactions;
using System.Windows.Forms;
using System.Data.SQLite;
using kassasystem;

namespace kassasystem_test
{
    public class Tests
    {
        hotelPaymentAndBookingSystem _form;
        UserControlBooking _formBooking;

        public SQLiteConnection con { get; set; }

        private TransactionScope scope;

        [SetUp]
        public void Setup()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
            string filePath = string.Format(@"C:\Users\{0}\Documents\hotel_database\database.db", userName);

            var db = new SQLiteConnection($"Data Source={filePath};");
            this.con = db;

            scope = new TransactionScope();

            _form = new hotelPaymentAndBookingSystem();
            _form.Show();

            _formBooking = new UserControlBooking();
            _formBooking.Show();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }

        [Test]
        public void testBookRoom()
        {
            // your test code here
            this.con.Open();
            _form.BtnBooking.PerformClick();
            _formBooking.btnNewBooking.PerformClick();

            string firstName = "bertil";
            _formBooking.inputFirstName.Text = firstName;

            string secondName = "karlsson";
            _formBooking.inputLastName.Text = secondName;

            Random random = new Random();
            int index = random.Next(0, _formBooking.availableRooms.Items.Count);
            _formBooking.availableRooms.SelectedIndex = index;

            _formBooking.btnSave.PerformClick();
            this.con.Close();
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