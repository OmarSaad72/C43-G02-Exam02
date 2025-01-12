using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    abstract class Utility
    {
        public static string StringsVAlidation()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.All(char.IsDigit) || input == "0")
                {
                    Console.WriteLine("Enter a Valid Input!");
                }
            }
            while (string.IsNullOrEmpty(input) || input.All(char.IsDigit));
            return input;
        }
    }
}
