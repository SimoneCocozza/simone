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

            string dates = "";
            List<string> myDates = new List<string>();
            myDates.Add("11/12/1997");
            myDates.Add("11/12/1998");
            myDates.Add("11/12/1999");

            foreach (string d in myDates)
            {
                dates += d + " - ";
            }

            Console.WriteLine(dates);
        }
    }
}
