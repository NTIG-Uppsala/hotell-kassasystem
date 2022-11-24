using System;
using System.Windows.Forms;
namespace kassasystem_test
{
    public class Tests
    {
        kassasystem.Form1 _form;

        [SetUp]
        public void Setup()
        {
            _form = new kassasystem.Form1();
        }

        [Test]
        public void test_clickpersonbutton()
        {
            _form.btn_person.PerformClick();

            Assert.That(!_form.listBox1.Items.Contains(_form.btn_person.Text), Is.True);
        }

        [Test]
        public void test_clickroombutton()
        {
            _form.btn_room.PerformClick();

            Assert.That(!_form.listBox1.Items.Contains(_form.btn_room.Text), Is.True);
        }

        [Test]
        public void test_clickclearbutton()
        {
            _form.btn_clear.PerformClick();

            Assert.That((_form.listBox1.Items.Count == 0), Is.True);
        }
    }
}