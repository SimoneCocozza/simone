using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> dates = new List<string> { "11/10/2021", "15/12/2001", "03/10/1965" };
            
            StringBuilder dateord = new StringBuilder();
            
            foreach (string date in dates)
            {
                dateord.Append(date);
                dateord.Append(" - ");
            }

            Console.WriteLine("-- Stampa delle date salvate --");

            Console.WriteLine(dates);
        }
        
    }   
}
