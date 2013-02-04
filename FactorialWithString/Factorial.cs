//////////////////////////////////////////////////
// Factorial With String Project
// File: Factorial.cs
// Class is having methods for calculating factorial for the given number.
//////////////////////////////////////////////////

#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; 
#endregion

namespace FactorialWithString
{
    /// <summary>
    /// Factorial Class is containing methods for calculating factorial of a given number
    /// </summary>
    public class Factorial
    {
        #region Constants
        private const string InvalidNumberMessage = "Sorry, You have entered an invalid number";
        private const string MinusSign = "-";
        private const string Zero = "0";
        private const string One = "1";
        private const string RegxNum = "^\\d+$";
        private const string Error = "Error:";
        private const string EmptyStringMessage = "Sorry u have entered nothing";
        #endregion

        #region Public methods
        /// <summary>
        /// Method to calculate the factorial of a number.
        /// </summary>
        /// <param name="number"> Number for which factorial will be calculated</param>
        /// <returns></returns>
        public string CalculateFactorial(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return EmptyStringMessage;
            }
            string result = string.Empty;
            char[] array = number.ToArray();
            try
            {
                if (number.Contains(MinusSign))
                {
                    return InvalidNumberMessage;
                }
                if (number.Length.Equals(1) && number.Equals(Zero))
                {
                    return One;
                }
                List<int> actualNumberList = new List<int>();
                foreach (char c in array)
                {
                    if (!Regex.IsMatch(c.ToString(), RegxNum))
                    {
                        return InvalidNumberMessage;
                    }
                    actualNumberList.Add(Convert.ToInt32(c.ToString()));
                }
                List<int> prevNumberList = Previous(actualNumberList);
                List<int> multiPlyResultList = actualNumberList;
                bool flag = prevNumberList.Any(lstItem => lstItem != 0);
                while (flag)
                {
                    multiPlyResultList = Multiply(multiPlyResultList, prevNumberList);
                    actualNumberList = prevNumberList;
                    prevNumberList = Previous(actualNumberList);
                    flag = prevNumberList.Any(lstItem => lstItem != 0);
                }

                return multiPlyResultList.Aggregate(result, (current, item) => current + item.ToString());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();
            }
            return result;
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Method to get the previous number as an integer list
        /// </summary>
        /// <param name="number"> User input</param>
        /// <returns> previous number list</returns>
        private List<int> Previous(List<int> number)
        {
            int length = number.Count;
            List<int> prevNumber = new List<int>();
            try
            {
                int i = GetPositionOfFirstNonZeroDigitFromRight(number);
                bool flag = false;
                for (int j = 0; j < length; j++)
                {
                    // check the condition when first non zero digit occurs from right hand side
                    // to minus
                    if (i == j)
                    {
                        prevNumber.Add(number[j] - 1);
                        flag = true;
                    }
                    // put all the right hand zero digits as 9 
                    else if (flag)
                    {
                        prevNumber.Add(9);
                    }
                    // put all other number as it is.
                    else
                    {
                        prevNumber.Add(number[j]);
                    }
                }

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();
            }
            return prevNumber;
        }

        /// <summary>
        /// Method to get position of non zero digit from right hand side.
        /// </summary>
        /// <param name="number"> Number for which factorial to be calculated</param>
        /// <returns> Position of non zero digit</returns>
// ReSharper disable MemberCanBeMadeStatic.Local
        private int GetPositionOfFirstNonZeroDigitFromRight(IList<int> number)
// ReSharper restore MemberCanBeMadeStatic.Local
        {
            int i = 0;
            try
            {
                // Get the position of first non zero digit from right hand side.
                for (i = number.Count - 1; i >= 0; i--)
                {
                    if (number[i] != 0)
                    {
                        break;
                    }
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();
            }
            return i;
        }

        /// <summary>
        /// Method to get multiplication of two lists of numbers 
        /// </summary>
        /// <param name="num1"> First number list</param>
        /// <param name="num2"> Second number list</param>
        /// <returns> list after calculating multiplication of two numbers list</returns>
        private List<int> Multiply(IList<int> num1, IList<int> num2)
        {
            List<int> result = new List<int>();
            try
            {
                List<string> numbersList = new List<string>();
                int counter = 0;
                for (int i = num2.Count - 1; i >= 0; i--)
                {
                    int carry = 0;
                    StringBuilder number = new StringBuilder();
                    // Loop for partial products of two numbers
                    for (int j = num1.Count - 1; j >= 0; j--)
                    {
                        int multiplication = num1[j] * num2[i] + carry;
                        int value = multiplication % 10;
                        number.Insert(0, value);
                        carry = multiplication / 10;
                    }
                    if (carry != 0)
                    {
                        number.Insert(0, carry);
                    }
                    // Get zeros to be added right hand side of a partial product
                    string zeros = GetZeros(counter);
                    number.Append(zeros);

                    // Added the partial product to the list
                    numbersList.Add(number.ToString());
                    counter++;
                }

                int length = GetLengthOfMaximumNumber(numbersList);
                // Get sum of all the partial product.
                GetAdditionOfPartialProduct(numbersList, length, result);
                // remove extra zeros from the left of final product.
                RemoveExtraZerosFromLeft(result);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();
            }
            return result;
        }

        /// <summary>
        /// Method to get length of maximum number 
        /// </summary>
        /// <param name="numbersList"> list of strings having numbers to be added after multiplication</param>
        /// <returns> length of largest number</returns>
// ReSharper disable MemberCanBeMadeStatic.Local
        private int GetLengthOfMaximumNumber(IEnumerable<string> numbersList)
// ReSharper restore MemberCanBeMadeStatic.Local
        {
            int length = 0;
            try
            {
                // ReSharper disable AccessToModifiedClosure
                foreach (string number in numbersList.Where(number => length < number.Length))
                // ReSharper restore AccessToModifiedClosure
                {
                    length = number.Length;
                }
            }
           
            catch(ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine(); 
            }
            return length;
        }

        /// <summary>
        /// Method to remove extra zeros from left from the resultant number
        /// </summary>
        /// <param name="result"> Number after multiplication</param>
        private static void RemoveExtraZerosFromLeft(IList<int> result)
        {

            try
            {
                for (int i = 0; i < result.Count; i++)
                {
                    int digit = result[i];
                    // Check the condition for first non zero digit occurs from left
                    if (digit != 0)
                    {
                        break;
                    }
                    result.RemoveAt(i);
                    i--;
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Method to get addition of multiplied rows.
        /// </summary>
        /// <param name="numbersList"> List of strings having numbers to be added after multiplication</param>
        /// <param name="length"> Maximum number length</param>
        /// <param name="result"></param>
        private void GetAdditionOfPartialProduct(IEnumerable<string> numbersList, int length, IList<int> result)
        {
            // Flag used to identify first iteration in numberList
            bool flag = true;
            try
            {
                foreach (string number in numbersList)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    // Append zeros if length of number is less then the maximum number length in the list.
                    if (number.Length < length)
                    {
                        string zeros = GetZeros(length - number.Length);
                        stringBuilder.Append(zeros);
                    }
                    // Append number with in the list
                    stringBuilder.Append(number);

                    // Convert string to an array of characters for iteration.
                    char[] numberArray = stringBuilder.ToString().ToArray();
                    for (int i = 0; i < numberArray.Length; i++)
                    {
                        int x = Convert.ToInt32(numberArray[i].ToString());
                        // if this is the first number then add all the digits in the list.
                        if (flag)
                        {
                            result.Add(x);
                        }
                        // otherwise add all the digits of number to the previously added digits.
                        else
                        {
                            result[i] = result[i] + x;
                        }
                    }
                    flag = false;
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Method to calculate zeros to append or pretend before a number.
        /// </summary>
        /// <param name="counter"> number of zeros</param>
        /// <returns> zero as a string</returns>
// ReSharper disable MemberCanBeMadeStatic.Local
        private string GetZeros(int counter)
// ReSharper restore MemberCanBeMadeStatic.Local
        {
            double power = Math.Pow(10, counter);
            return power.ToString().Replace(One, string.Empty);
        }
        #endregion
    }
}
