using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Program
    {
        static void Main(string[] args)
        {


            List<string> mydates = new List<string>() { "31/01/1998", "01/03/1998", "02/02/1998" };
            string dates = null;
            

            // Case 1

            foreach (string d in mydates)
            {
                dates += d + "-";                
            }
            dates = dates.Remove(dates.Length - 1);
            var splitDate = dates.Split('-');

            foreach(string d in splitDate)
            {
                var splitMonth = d.Split('/');
                var m = splitMonth.ElementAt(1);
                try
                {                    
                    if (Int32.Parse(m) % 2 != 0)
                    {
                        throw new Exception("Il mese " + m + " è dispari \n");
                    }
                }
                catch(Exception ex)
                {                                      
                    File.AppendAllText("MonthExs.txt",ex.Message);
                }
            }
            
                        
        }
    }
}
