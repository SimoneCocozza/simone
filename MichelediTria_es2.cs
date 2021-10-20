using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichelediTria_Es2
{
    class Program : InsertFile
    {
        public static void Main(string[] args)
        {
                List<string> myDates = new List<string>();
                for(int i=1; i<=12; i++)
                {
                    myDates.Add("11/"+i+"/1997");
                }
           
                foreach (string d in myDates)
                {
                    InsertFile.insert(d);
                }        
        }
    }
    class InsertFile
    {
        public static void insert(string d)
        {
            string path = "../../file.txt";

            try
            {
                string[] month = d.Split('/');
                if (((Convert.ToInt32(month[1])) % 2) != 0)
                {
                    throw new Exception("il mese " + month[1] + " è dispari" + "\n");
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(path, e.Message);
            }
        }
        
    }
}
