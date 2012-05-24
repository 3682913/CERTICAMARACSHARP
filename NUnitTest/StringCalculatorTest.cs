using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NUnitTest
{
    [TestClass()]
    public class StringCalculatorTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void empty_string()
        {
            string cad = string.Empty;
            int expected = 0; 
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void one_number()
        {
            string cad = "999";
            int expected = 999;
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void two_numbers()
        {
            string cad = "74,799";
            int expected = 873;
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void un_known_amount_of_numbers()//Suma los numeros del 1 al 100 (el resultado es 5050)
        {
            string cad = "";
            int expected = 0;
            for (int i = 1; i <= 100; i++)
            {
                cad += i + ",";
                expected += i;
            }
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void new_lines_between_numbers()
        {
            string cad = "15\n30,120";
            int expected = 165;
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void support_different_delimiters()
        {
            string cad = "//;\n100;200";
            int expected = 300;
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void negatives_not_allowed ()
        {
            String cad = "78,8,9,-20,-41,-899,89";
            String expected = "negatives not allowed: -20 -41 -899 ";
            try
            {
                StringCalculator.add(cad);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(expected,ex.Message);
            }

        }   
        [TestMethod()]
        public void no_more_than_1000()
        {
            string cad = "//;\n100;500;600;1200;2400";
            int expected = 1200;
            int actual = StringCalculator.add(cad);
            Assert.AreEqual(expected, actual);
        }
    }
}
