using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculate {
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_Add_Success()
        {
            Assert.AreEqual<int>(Calculator.Add(1,1),2);
        }

        [TestMethod]
        public void Calculator_Subtract_Success()
        {
            Assert.AreEqual<int>(Calculator.Subtract(3, 1), 2);
        }

        [TestMethod]
        public void Calculator_Multiply_Success()
        {
            Assert.AreEqual<int>(Calculator.Multiply(2, 1), 2);
        }

        [TestMethod]
        public void Calculator_Divide_Success()
        {
            Assert.AreEqual<int>(Calculator.Divide(4, 2), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculator_DivideByZero_Exception()
        {
            Assert.AreEqual<int>(Calculator.Divide(4, 0), 0);

        }
        [TestMethod]
        public void Calculator_TryCalculate_AddSuccess()
        {
            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate("2 + 2", out output);
            Assert.IsTrue(test);
            Assert.AreEqual<int>(4, output);
        }

        [TestMethod]
        public void Calculator_TryCalculate_SubtractSuccess()
        {
            Calculator_TryCalculate_Success("4 - 2", 2);
        }
        [TestMethod]
        public void Calculator_TryCalculate_MultiplySuccess()
        {
            Calculator_TryCalculate_Success("2 * 2", 4);
        }
        [TestMethod]
        public void Calculator_TryCalculate_DivideSuccess()
        {
            Calculator_TryCalculate_Success("4 / 2", 2);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculator_TryDivideByZero_Exception()
        {
            Calculator_TryCalculate_Success("4 / 0", 2);
        }

        private void Calculator_TryCalculate_Success(string input, int expectedResult)
        {
            int output;
            var calc = new Calculator();
            bool test = calc.TryCalculate(input, out output);
            Assert.IsTrue(test);
            Assert.AreEqual<int>(expectedResult, output);
        }

        [TestMethod]
        public void Calculator_TryCalculate_Fail()
        {
            int output;
            var calc = new Calculator();
            Assert.IsFalse(calc.TryCalculate("", out output)); // no input
            Assert.IsFalse(calc.TryCalculate("a + 2", out output)); // not integer
            Assert.IsFalse(calc.TryCalculate("4*2", out output)); // no spaces
            Assert.IsFalse(calc.TryCalculate("1 % 2", out output)); // invalid operator
            Assert.IsFalse(calc.TryCalculate("1 + 2 + 3", out output)); // multiple operators
        }
    }
}