using System;

namespace Calculator.Shared
{
    /// <summary>
    /// Class holding a calculation that shall be evaluated on the server.
    /// </summary>
    public class Calculation
    {
        /// <summary>
        /// The first number for the calculation
        /// </summary>
        int _number1;
        /// <summary>
        /// The second number for the calculation
        /// </summary>
        int _number2;
        /// <summary>
        /// The atithmetic operation for the calculation
        /// </summary>
        Operation _operation;

        /// <summary>
        /// Creates a new calculation object
        /// </summary>
        /// <param name="number1">The first number for the new calculation</param>
        /// <param name="number2">The second number for the new calculation</param>
        /// <param name="operation">A character that determins the arithmetic operation</param>
        public Calculation(int number1, int number2, char operation) : this(number1, number2, (Operation)operation)
        {
        }

        /// <summary>
        /// Creates a new calculation object
        /// </summary>
        /// <param name="number1">The first number for the new calculation</param>
        /// <param name="number2">The second number for the new calculation</param>
        /// <param name="operation">The arithmetic operation for the new calculation</param>
        public Calculation(int number1, int number2, Operation operation)
        {
            _number1 = number1;
            _number2 = number2;
            _operation = operation;
        }

        /// <summary>
        /// Getter for the operation
        /// </summary>
        /// <returns>The operation of the calculation</returns>
        public Operation GetOperation()
        {
            return _operation;
        }

        /// <summary>
        /// Getter for the first number in the calculation
        /// </summary>
        /// <returns>The first number in the calculation</returns>
        public int GetNumber1()
        {
            return _number1;
        }

        /// <summary>
        /// Getter for the second number in the calculation
        /// </summary>
        /// <returns>The first second in the calculation</returns>
        public int GetNumber2()
        {
            return _number2;
        }

        /// <summary>
        /// Creates a textual representation of the calculation
        /// </summary>
        /// <returns>The textual representation of the calculation (e.g. "1+1")</returns>
        public override string ToString()
        {
            return string.Format($"{_number1} {(char)_operation} {_number2}");
        }

        internal string ToNetworkString()
        {
            return $"{_number1};{_number2};{(char)_operation}";
        }

        internal static Calculation FromNetworkString(string receivedString)
        {
            string[] splittedQuery = receivedString.Split(';');

            int number1 = Convert.ToInt32(splittedQuery[0]);
            int number2 = Convert.ToInt32(splittedQuery[1]);
            Operation operation = (Operation)Convert.ToChar(splittedQuery[2]);

            return new Calculation(number1, number2, operation);
        }

        public bool IsValid()
        {
            if(_number1 == 0 && _number2 == 0 && _operation == Operation.Divide)
			{
                return false;
			}

            return true;
        }
    }
}
