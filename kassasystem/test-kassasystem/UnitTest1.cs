namespace test_kassasystem
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Person_btn_test()
        {
            btn_person.PerformClick();
            Assert.IsTrue("person" in listBox1);
        }
    }
}