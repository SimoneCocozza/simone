using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFile_2
{
    class Risultato //creo questo oggetto Risultato per essere
                    //in grado di avere questo tipo di ritorno in MyFile2
                    //nel metodo gestisci file. 
                   // Rispetto a come avevo fatto io più coerente con
                   // la programmazione ad oggetti.
           
    {

        public IList<string> FileConVocali { get; } // inizializzo la lista,
                                                    // anche questa non ha bisogno di set
                                                    // perchè ritorna da metodo

        public IList<string> FileSenzaVocali { get; }  // inizializzo la lista

        public Risultato(IList<string> fileSenzaVocali, IList<string> fileConVocali) //costruttore della classe
        {
            this.FileConVocali = fileConVocali;
            this.FileSenzaVocali = fileSenzaVocali;
        }
    }
}
