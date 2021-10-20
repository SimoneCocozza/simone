using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> miedate = new List<string>();
           
            miedate.Add("01/01/2011");
            miedate.Add("01/02/1980");
            miedate.Add("01/03/1995");

            foreach (string d in miedate)
            {
                var mese = d.Split('/');
                var conversione = Convert.ToInt32(mese[1]);

                //Console.WriteLine(mese[1]);
                //Console.WriteLine(conversione);

                try
                {
                    if (conversione % 2 == 1)
                    {

                        throw new Exception("Mese " + conversione + " dispari\n");

                    }

                }

                catch (Exception ecc)
                {

                    File.AppendAllText("MesiD.txt", ecc.Message);
                
                }

            }

        }

    }

}
