//////////////////////////////////////////////////
// Factorial With String Project
// File: Program.cs
// Class is having method from where execution will start &
//that method is for taking a number as an input and showing factorial for the same as an output.
//////////////////////////////////////////////////
#region Namespaces
using System; 
#endregion

namespace FactorialWithString
{
    /// <summary>
    /// Program class starts the execution of program.
    /// </summary>
    class Program
    {
        #region Constants
        private const string InputMessage = "Enter a number";
        private const string FactorialMessage = "Factorial of ";
        private const string Is = "is : ";
        private const string DisplayMessageOne = "Do you want to calculate factorial of another number.";
        private const string DisplayMessageTwo = "Enter y to continue or enter to exit";
        private const string Yes = "y";
        private const string Error = "Error : ";
        #endregion

        #region Main Method
        
        /// <summary>
        /// Entry point for program. 
        /// This method will take argument from user and call another method to calculate factorial of the given number.
        /// </summary>
        static void Main()
        {
            try
            {
                // Flag used to continue program execution based on the user inputs
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine(InputMessage);
                    string number = Console.ReadLine();
                    Factorial objFactorial = new Factorial();
                    string result = objFactorial.CalculateFactorial(number);
                    Console.WriteLine(string.Format("{0}{1}{2}{3}", FactorialMessage, number, Is, result));
                    Console.WriteLine(DisplayMessageOne);
                    Console.WriteLine(DisplayMessageTwo);
                    if (Yes != Console.ReadLine())
                    {
                        flag = false;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("{0}{1}", Error, exception.Message));
                Console.ReadLine();

            }
        }
        #endregion


    }
}
