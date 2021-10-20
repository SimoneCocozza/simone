using System;
using System.Collections.Generic;

public class Program
{
	
	public static void Main()
	{
		List<string> dates = new List<string>();
   
    		for(int i=0;i<20;i++)
        		dates.Add((i+1)+"/1/2021");

		for(int i=0;i<dates.Count;i++)Console.Write(dates[i] + (i==dates.Count-1 ? "" : "-"));
	}
} 
