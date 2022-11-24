using System;
using System.Windows.Forms;
using kassasystem;

namespace kassasystem_test
{
    public class Tests
    {
        Form1 _form;

        [SetUp]
        public void Setup()
        {
            _form = new Form1();
            _form.Show();
        }

        [Test]
        public void test_clickpersonbutton()
        {

            if (_form.btn_person.Visible)
            {
                _form.btn_person.PerformClick();

                Assert.That(_form.listBox1.Items.Contains(_form.btn_person.Text), Is.True);
            }
            else
            {
                Assert.Fail("Person button is not visible");
            }
        }

        [Test]
        public void test_clickroombutton()
        {
            if (_form.btn_room.Visible)
            {
                _form.btn_room.PerformClick();

                Assert.That(_form.listBox1.Items.Contains(_form.btn_room.Text), Is.True);
            }
            else
            {
                Assert.Fail("Room button is not visible");
            }
        }

        [Test]
        public void test_clickclearbutton()
        {
            if (_form.btn_clear.Visible)
            {
                _form.btn_clear.PerformClick();

                Assert.That((_form.listBox1.Items.Count == 0), Is.True);
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