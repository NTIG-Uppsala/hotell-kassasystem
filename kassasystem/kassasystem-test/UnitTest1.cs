using System;
using System.Windows.Forms;
using kassasystem;

namespace kassasystem_test
{
    public class Tests
    {
        hotelPaymentAndBookingSystem _form;
        int twoSingleBedsPrice = 1000;
        int oneDoubleBedPrice = 1000;
        int btnSingleBedPrice = 500;

        [SetUp]
        public void Setup()
        {
            _form = new hotelPaymentAndBookingSystem();
            _form.Show();
        }
        
        [Test]
        public void test_click_single_bed()
        {
            if (_form.btnSingleBed.Visible)
            {
                _form.btnSingleBed.PerformClick();

                Assert.That(_form.listBox1.Items.Contains($"{_form.btnSingleBed.Text} 1x 0 days {btnSingleBedPrice}kr"), Is.True);
                Assert.That(_form.lblTotal.Text, Is.EqualTo(String.Format("Total: {0}kr", btnSingleBedPrice)));
            }
            else
            {
                Assert.Fail("Person button is not visible");
            }
        }

        [Test]
        public void test_click_btn_two_single_beds()
        {

            if (_form.btnTwoSingleBeds.Visible)
            {
                _form.btnTwoSingleBeds.PerformClick();

                Assert.That(_form.listBox1.Items.Contains($"{_form.btnTwoSingleBeds.Text} 1x 0 days {twoSingleBedsPrice}kr"), Is.True);
                Assert.That(_form.lblTotal.Text, Is.EqualTo(String.Format("Total: {0}kr", twoSingleBedsPrice)));

            }
            else
            {
                Assert.Fail("Person button is not visible");
            }
        }

        [Test]
        public void test_click_two_single_beds()
        {
            if (_form.btnTwoSingleBeds.Visible)
            {
                _form.btnTwoSingleBeds.PerformClick();

                Assert.That(_form.listBox1.Items.Contains($"{_form.btnTwoSingleBeds.Text} 1x 0 days {oneDoubleBedPrice}kr"), Is.True);
                Assert.That(_form.lblTotal.Text, Is.EqualTo(String.Format("Total: {0}kr", oneDoubleBedPrice)));
            }
            else
            {
                Assert.Fail("Room button is not visible");
            }
        }

        [Test]
        public void test_click_clear_button()
        {
            if (_form.btnClear.Visible)
            {
                _form.btnDoubleBed.PerformClick();

                _form.btnClear.PerformClick();

                Assert.That((_form.listBox1.Items.Count == 0), Is.True);
                Assert.That(_form.lblTotal.Text, Is.EqualTo("Total: 0kr"));
            }
            else
            {
                Assert.Fail("Clear button not visible");
            }

        }

        [Test]
        public void test_remove_1x()
        {
            if (_form.BtnRemove1x.Visible)
            {
                _form.btnDoubleBed.PerformClick();
                _form.btnDoubleBed.PerformClick();

                _form.listBox1.SelectedItem = _form.listBox1.Items[0];

                _form.BtnRemove1x.PerformClick();

                Assert.That(_form.cartDictionary[_form.btnDoubleBed.Text], Is.EqualTo(1));
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
                _form.btnDoubleBed.PerformClick();
                _form.btnTwoSingleBeds.PerformClick();

                Assert.That(_form.cartDictionary[_form.btnDoubleBed.Text], Is.EqualTo(1));

                _form.listBox1.SelectedItem = _form.listBox1.Items[0];

                _form.BtnRemoveAll.PerformClick();

                Assert.That(_form.cartDictionary.ContainsKey(_form.btnDoubleBed.Text), Is.False);
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