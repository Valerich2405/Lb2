using System;
using System.Collections.Generic;

namespace Creation_of_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>()
            {
                "Hello World :)",
                "Goodbye World :("
            };

            Func<string, int> stringLengthDelegate = s => s.Length;

            foreach (string line in lines)
            {
                int length = stringLengthDelegate(line);
                Console.WriteLine(line);
                Console.WriteLine($"Довжина рядка: {length}.");
                Console.WriteLine();
            }
        }
    }
}
