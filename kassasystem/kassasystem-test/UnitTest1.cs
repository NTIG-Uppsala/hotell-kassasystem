using System;
using System.Windows.Forms;
using kassasystem;

namespace kassasystem_test
{
    public class Tests
    {
        Form1 _form;
        int two_single_beds_price = 1000;
        int one_double_bed_price = 1000;

        [SetUp]
        public void Setup()
        {
            _form = new Form1();
            _form.Show();
        }

        [Test]
        public void test_click_btn_two_single_beds()
        {

            if (_form.btn_two_single_beds.Visible)
            {
                _form.btn_two_single_beds.PerformClick();

                Assert.That(_form.listBox1.Items.Contains($"{_form.btn_two_single_beds.Text} 1x 0 days {two_single_beds_price}kr"), Is.True);
                Assert.That(_form.lbl_total.Text, Is.EqualTo(String.Format("Total: {0}kr", two_single_beds_price)));

            }
            else
            {
                Assert.Fail("Person button is not visible");
            }
        }

        [Test]
        public void test_click_two_single_beds()
        {
            if (_form.btn_two_single_beds.Visible)
            {
                _form.btn_two_single_beds.PerformClick();

                Assert.That(_form.listBox1.Items.Contains($"{_form.btn_two_single_beds.Text} 1x 0 days {one_double_bed_price}kr"), Is.True);
                Assert.That(_form.lbl_total.Text, Is.EqualTo(String.Format("Total: {0}kr", one_double_bed_price)));
            }
            else
            {
                Assert.Fail("Room button is not visible");
            }
        }

        [Test]
        public void test_click_clear_button()
        {
            if (_form.btn_clear.Visible)
            {
                _form.btn_double_bed.PerformClick();

                _form.btn_clear.PerformClick();

                Assert.That((_form.listBox1.Items.Count == 0), Is.True);
                Assert.That(_form.lbl_total.Text, Is.EqualTo("Total: 0kr"));
            }
            else
            {
                Assert.Fail("Clear button not visible");
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