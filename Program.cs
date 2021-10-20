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


            List<string> mydates = new List<string>() { "31/01/1998", "01/02/1998", "02/02/1998" };
            StringBuilder sb = new StringBuilder();
            string dates = "";

            // Case 1

            foreach (string d in mydates)
            {
                dates += d + "-";
            }
            Console.WriteLine(dates);


            // Case 2

            foreach (string date in mydates)
            {
                sb.Append(date);
                sb.Append("-");
            }

            dates = sb.ToString();
            Console.WriteLine(dates);

           
        }
    }
}
