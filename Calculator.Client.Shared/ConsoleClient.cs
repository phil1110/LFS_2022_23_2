using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Client.Shared
{
    /// <summary>
    /// Client running in a console
    /// </summary>
    public class ConsoleClient : AbstractClient
    {
        /// <inheritdoc/>
        public ConsoleClient(IPEndPoint endpoint, string id) : base(endpoint, id)
        {
        }

        /// <inheritdoc/>
        protected override int InquireNumber()
        {
            Console.Write("Zahl eingeben: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <inheritdoc/>
        protected override Operation InquireOperation()
        {
            while (true)
            {
                Console.Write("Rechenart eingeben: ");
                char c = Console.ReadLine()[0];
                foreach (Operation op in Enum.GetValues(typeof(Operation)))
                {
                    if ((Operation)c == op)
                    {
                        return op;
                    }
                }
            }
        }

        /// <inheritdoc/>
        protected override void ShowResult(string result)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Ergebnis: {result}{Environment.NewLine}");
            Console.ForegroundColor = foregroundColor;
        }

        /// <inheritdoc/>
        protected override void ShowLog(string result)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Ergebnis: {result}{Environment.NewLine}");
            Console.ForegroundColor = foregroundColor;
        }
    }
}
