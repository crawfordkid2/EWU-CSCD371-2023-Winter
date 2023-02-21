using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Calculate {
    [TestClass]
    public class MyTestClass
    {

        [TestMethod]
        public void addSuccess()
        {
            Assert.AreEqual<int>(Calculator.Add(1,1),2);
        }

        [TestMethod]
        public void subSuccess()
        {
            Assert.AreEqual<int>(Calculator.Subtract(3, 1), 2);

        }

        [TestMethod]
        public void multiSuccess()
        {
            Assert.AreEqual<int>(Calculator.Multiply(2, 1), 2);

        }

        [TestMethod]
        public void divSuccess()
        {
            Assert.AreEqual<int>(Calculator.Divide(4, 2), 2);

        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void divByZero()
        {
            Assert.AreEqual<int>(Calculator.Divide(4, 0), 0);

        }
        [TestMethod]
        public void TryCalcAddTest()
        {
       
            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate("2 + 2",out output);
            Assert.IsTrue(test);
            Assert.AreEqual(4, output);
            
        }
        [TestMethod]
        public void TryCalcSubTest()
        {

            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate("4 - 2", out output);
            Assert.IsTrue(test);
            Assert.AreEqual(2, output);

        }
        [TestMethod]
        public void TryCalcMultiTest()
        {

            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate("2 * 2", out output);
            Assert.IsTrue(test);
            Assert.AreEqual(4, output);

        }
        [TestMethod]
        public void TryCalcDivTest()
        {

            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate("4 / 2", out output);
            Assert.IsTrue(test);
            Assert.AreEqual(2, output);

        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TryCalcDivByZeroTest()
        {

            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate("4 / 0", out output);
            Assert.IsTrue(test);
            Assert.AreEqual(2, output);

        }
        

    }


}