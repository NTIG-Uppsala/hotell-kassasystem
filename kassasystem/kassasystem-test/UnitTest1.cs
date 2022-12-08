using System;
using System.Windows.Forms;
using kassasystem;

namespace kassasystem_test
{
    public class Tests
    {
        hotelPaymentAndBookingSystem _form;
        int roomPrice = 2000;

        [SetUp]
        public void Setup()
        {
            _form = new hotelPaymentAndBookingSystem();
            _form.btnTest.Visible = true;
            _form.Show();
            _form.priceList.Add(_form.btnTest.Text, 2000);
        }
        
        [Test]
        public void testRoomButton()
        {
            _form.btnTest.PerformClick();

            Assert.That(_form.listBox1.Items.Contains($"{_form.btnTest.Text} 1x 0 days {roomPrice}kr"), Is.True);
            Assert.That(_form.lblTotal.Text, Is.EqualTo(String.Format("Total: {0}kr", roomPrice)));
        }
        
        [Test]
        public void testClickClearButton()
        {

            _form.btnTest.PerformClick();

            _form.btnClear.PerformClick();

            Assert.That((_form.listBox1.Items.Count == 0), Is.True);
            Assert.That(_form.lblTotal.Text, Is.EqualTo("Total: 0kr"));
        }

        [Test]
        public void test_remove_1x()
        {
            if (_form.BtnRemove1x.Visible)
            {
                _form.btnTest.PerformClick();
                _form.btnTest.PerformClick();

                _form.listBox1.SelectedItem = _form.listBox1.Items[0];

                _form.BtnRemove1x.PerformClick();

                Assert.That(_form.cartDictionary[_form.btnTest.Text], Is.EqualTo(1));
            }
            else
            {
                Assert.Fail("Remove 1x not visible");
            }
        }

        [Test]
        public void test_remove_all()
        {
            if (_form.BtnRemoveAll.Visible)
            {
                _form.btnTest.PerformClick();
                _form.btnTest.PerformClick();

                Assert.That(_form.cartDictionary[_form.btnTest.Text], Is.EqualTo(2));

                _form.listBox1.SelectedItem = _form.listBox1.Items[0];

                _form.BtnRemoveAll.PerformClick();

                Assert.That(_form.cartDictionary.ContainsKey(_form.btnTest.Text), Is.False);
            }
            else
            {
                Assert.Fail("Remove all not visible");
            }
        }

        [Test]
        public void addition()
        {
            int firstValue = 1;
            int secondValue = 1;

            Assert.That(firstValue + secondValue, Is.EqualTo(2));
        }
    }
}