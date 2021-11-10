using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> date = new List<string>() { "12/11/1948", "28/09/1991", "15/12/2007", "11/11/2011" };

            StringBuilder dateConcatenate = new StringBuilder();

            // Concatena tutte le date
            foreach (string data in date)
            {
                dateConcatenate.Append(data + " - ");
            }

            Console.WriteLine(dateConcatenate);
        }
    }
}
