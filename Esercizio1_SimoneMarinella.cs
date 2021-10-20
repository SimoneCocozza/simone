using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mydates = new List<string>(); //creo e istanzio una lista vuota
            mydates.Add("01/01/1999");
            mydates.Add("01/02/1999"); //aggiungo 1 solo elemento alla lista  
            mydates.Add("01/03/1999");
            string dates = "";

            // Metodo 1 

            foreach (string d in mydates)
            {
                dates += d + "-";
            }

            Console.WriteLine(dates);

            // Metodo 2 
            StringBuilder sb = new StringBuilder();
            foreach (string date in mydates)
            {
                sb.Append(date);
                sb.Append("-");
            }

            dates = sb.ToString();
            Console.WriteLine(dates);
            Console.ReadLine();
        }
    }
}
