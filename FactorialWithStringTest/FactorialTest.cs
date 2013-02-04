//////////////////////////////////////////////////
// Factorial With String Test Project
// File: FactorialTest.cs
// Class is having test methods for testing Methods of Factorial class.
//////////////////////////////////////////////////

#region Namespaces
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactorialWithString; 
#endregion

namespace FactorialWithStringTest
{
    /// <summary>
    /// FactorialTest class contains test cases to test functionality of Factorial.cs file.
    /// </summary>
    [TestClass]
    public class FactorialTest
    {
        #region Test constants
        //  Constants used in test methods
        private const string InvalidNumberMessage = "Sorry, You have entered an invalid number";
        private const string InvalidNumber = "ads";
        private const string NegativeNumber = "-1";
        private const string ZeroNumber = "0";
        private const string OneNumber = "1";
        private const string FiveNumber = "5";
        private const string FactOfFive = "120";
        private const string Hundred = "100";
        private const string EmptyStringMessage = "Sorry u have entered nothing";
        private const string FactOfHundred =
            "93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000";

        #endregion

        #region Test cases
        /// <summary>
        /// Test case to test condition when user enters an invalid number like string.
        /// </summary>
        [TestMethod]
        public void FactorialOfInvalidNumberTest()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(InvalidNumber);
            Assert.AreEqual(InvalidNumberMessage, actual);
        }

        /// <summary>
        /// Test case to test condition when user enter nothing.
        /// </summary>
        [TestMethod]
        public void FactorialOfEmptyNumberTest()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(string.Empty);
            Assert.AreEqual(EmptyStringMessage, actual);
        }

        /// <summary>
        /// Test case to test condition when user enter negative number.
        /// </summary>
        [TestMethod]
        public void FactorialOfNegativeNumberTest()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(NegativeNumber);
            Assert.AreEqual(InvalidNumberMessage, actual);
        }

        /// <summary>
        /// Test case to test condition when user want to calculate factorial of zero
        /// </summary>
        [TestMethod]
        public void FactorialOfZero()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(ZeroNumber);
            Assert.AreEqual(OneNumber, actual);
        }

        /// <summary>
        ///  Test case to test condition when user want to calculate factorial of one
        /// </summary>
        [TestMethod]
        public void FactorialOfOne()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(OneNumber);
            Assert.AreEqual(OneNumber, actual);
        }

        /// <summary>
        /// Test case to test condition when user want to calculate factorial of five
        /// </summary>
        [TestMethod]
        public void FactorialOfFive()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(FiveNumber);
            Assert.AreEqual(FactOfFive, actual);
        }

        /// <summary>
        /// Test case to test condition when user want to calculate factorial of hundred
        /// </summary>
        [TestMethod]
        public void FactorialOfHundred()
        {
            Factorial objFactorial = new Factorial();
            string actual = objFactorial.CalculateFactorial(Hundred);
            Assert.AreEqual(FactOfHundred, actual);
        } 
        #endregion
    }
}
