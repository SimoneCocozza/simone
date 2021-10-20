using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> mydates = new List<string>() {"01/12/1994", "28/03/1932", "14/02/2022"};

            foreach(string d in mydates)
            {
                var c = d.Split("/");
                var i = Convert.ToInt32(c[1]);
                if(i % 2 == 1) 
                {
                    throw new MyException("Mese dispari!");
                }
            }
            catch( MyException ex){
                File.WriteAllLines("C:\Users\Public\Nuova\errore.txt", "Errore rilevato: Mese dispari!");
                Console.WriteLine("Errore rilevato: Mese dispari");
            }
            
        }
    }

    
}

/* substring //estrae una stringa Substring(int StartIndex, int Lenght)
            split //splitta in diversi punti a seconda di cosa faccio: var b = data.Split("/") con string data = "10/10/2021", b diventa un array a 3 stringhe 10, 10, 2021. 
                // a questo punto potrei fare var i = Convert.ToInt32(b[1]);
*/