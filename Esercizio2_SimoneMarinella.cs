using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Esercizio2
{
    class Program
    {
        static void Main(string[] args)
        {
              List<string> mydates = new List<string>(); //creo e istanzio una lista vuota
              mydates.Add("01/01/1999"); //aggiungo 1 solo elemento alla lista
              mydates.Add("01/02/1999"); //aggiungo un altro elemento alla lista  
              mydates.Add("01/03/1999"); //aggiungo un altro elemento alla lista 
              
              foreach (string d in mydates) //inizializzazione for
              {
                var mese = d.Split("/"); //ritorna un array di stringhe
                var conversione = Convert.ToInt32(mese[1]); //si converte la porzione dell'arrey in numero
                
                Console.WriteLine(mese[1]);
                Console.WriteLine(conversione);

            try //Inizio dichiarazione dell'eccezione
            {
                if (conversione % 2 == 1) //verifica che il mese sia dispari 
                {
                    throw new Exception("Il mese " + conversione + "è dispari"); //dichiarazione dell'eccezione
                }
            }
            catch (Exception ex) //gestione dell'eccezione
            {
                File.AppendAllText("MesiDispari.txt", ex.Message);

            }

              }
            
        }
    }
}
