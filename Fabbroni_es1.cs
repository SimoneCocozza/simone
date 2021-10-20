using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Mydates_Fabbroni
    {
        static void Main(string[] args)

        {
            //List<string> mydates1;
            List<string> mydates = new List<string>();
            mydates.Add("02/01/1999");
            mydates.Add("03/01/1999");
            mydates.Add("04/01/1999");
            mydates.Add("05/01/1999");
            mydates.Add("06/01/1999");
            mydates.Add("07/01/1999");
            mydates.Add("08/01/1999");
            mydates.Add("09/01/1999");
            mydates.Add("10/01/1999");
            mydates.Add("11/01/1999");
            mydates.Add("12/01/1999");
            mydates.Add("13/01/1999");

            for(int i = 0; i<mydates.Count; i++)
            {
                Console.Write(mydates[i] + " - ");

            }

            

        }
    }
}
