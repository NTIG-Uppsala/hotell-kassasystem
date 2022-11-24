using System;
using System.Windows.Forms;
namespace kassasystem_test
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test_clickpersonbutton()
        {
            kassasystem.Form1 _form = new kassasystem.Form1();

            _form.btn_person.PerformClick();

            Assert.That(_form.listBox1.Items.Contains(_form.btn_person.Text), Is.True);
        }
    }
}