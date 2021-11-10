using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> date = new List<string>() { "12/03/1948", "28/09/1991", "15/12/2007", "11/11/2011" };

            // Stampa i mesi dispari su un file di testo
            foreach (string data in date)
            {
                try
                {
                    string[] splittedData = data.Split("/");
                    var mese = Convert.ToInt32(splittedData[1]);

                    if (mese % 2 != 0)
                        throw new ArithmeticException("Il mese " + mese + " è dispari.");
                }
                catch (Exception mese)
                {
                    using (StreamWriter writer = new StreamWriter("C:\\Users\\hp\\Documents\\log.txt", true))
                    {
                        writer.WriteLine("Eccezione: " + mese);
                    }
                }
            }
        }
    }
}
