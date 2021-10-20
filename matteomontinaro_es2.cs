using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class ThrowOddMonthException
    {
        static void Main(string[] args)
        {
            Exception e = new Exception("Exception: Odd month found within list. Month found: ");

            List<Date> myDates = new List<Date>() {
                new Date("11", "10", "2021"),
                new Date("12", "09", "2021"),
                new Date("13", "10", "2021"),
                new Date("14", "10", "2021"),
                new Date("15", "10", "2021") };

            StringBuilder sDates = new StringBuilder();

            foreach (Date date in myDates)
            {
                try
                {
                    //retreive the month from each date
                    int month = Int32.Parse(date.month);
                    Console.WriteLine((month % 2 != 0) ? month + " is a problem" : month + " isn't");

                    //check if the month is odd
                    if (month % 2 != 0)
                    {
                        Console.WriteLine(e.Message + month);
                        throw new Exception(e.Message + month);
                    }
                    sDates.Append(date.GetDate() + "\n");
                }
                catch (Exception execption)
                {
                    File.WriteAllText("exceptionText.txt", execption.Message);
                }
            }
        }
            
    }

    public class Date {
        string day;
        public string month;
        string year;

        public Date(string d, string m, string y)
        {
            this.day = d;
            this.month = m;
            this.year = y;
        }

        public string GetDate()
        {
            return day + "/" + month + "/" + year;
        }
    }
   
}
