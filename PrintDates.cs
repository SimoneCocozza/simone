using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author: Matteo Montinaro
 */
namespace ConsoleApp1
{
    class PrintDates
    {
        static void Main(string[] args)
        {
            List<String> myDates = new List<string>() { "11/10/2021", "12/10/2021", "13/10/2021", "14/10/2021", "15/10/2021" };
        
            StringBuilder sDates = new StringBuilder();

            foreach(String date in myDates)
            {
                sDates.Append(date + "\n");
            }

            Console.WriteLine("\nAll Dates in List:\n" + sDates);
        }
    }
}
