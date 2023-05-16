using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service.Shared
{
    /// <summary>
    /// Class the does the calculations on the server
    /// </summary>
    class Calculator
    {
        private static Func<Calculation, int> aAdd = Add;
        private static Func<Calculation, int> aSub = Sub;
        private static Func<Calculation, int> aMult = Mult;
        private static Func<Calculation, int> aDiv = Div;

        /// <summary>
        /// Does the calculation
        /// </summary>
        /// <param name="calculation">The calculcation to be done</param>
        /// <returns></returns>
        public static int Calculate(Calculation calculation)
        {
            int result = 0;

            switch (calculation.GetOperation())
            {
                case Operation.Plus:
                    result = aAdd.Invoke(calculation);
                    break;
                case Operation.Minus:
                    result = aSub.Invoke(calculation);
                    break;
                case Operation.Times:
                    result = aMult.Invoke(calculation);
                    break;
                case Operation.Divide:
                    result = aDiv.Invoke(calculation);
                    break;
                default:
                    break;
            }

            return result;
        }

        static private int Add(Calculation calculation)
        {
            return calculation.GetNumber1() + calculation.GetNumber2();
        }

        static private int Sub(Calculation calculation)
        {
            return calculation.GetNumber1() - calculation.GetNumber2();
        }

        static private int Mult(Calculation calculation)
        {
            return calculation.GetNumber1() * calculation.GetNumber2();
        }

        static private int Div(Calculation calculation)
        {
            return calculation.GetNumber1() / calculation.GetNumber2();
        }
    }
}
