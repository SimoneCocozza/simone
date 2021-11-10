using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFile_2
{
   abstract class FileGenerico // in questa super classe astratta definisco
                               // le proprietà dell eventuale oggetto FileGenerico.
                               // Attenzione non posso implementare nulla perchè è una classe astratta!
                               // D'altra parte è stata creata astratta proprio perchè non mi serve
                               // implementare nulla qui, lo farò nelle classi figlie. 
    {

        public string FileName { get; private set; } //private set perchè lo istanzio qui 
                                                      // dalle altre classi richiamo solo
                                                      // il metodo che è public (vero?)
        public string FileExtention { get { return ".exe"; } } // che notazione è? 

        public abstract int VocalNumber { get; } // qui ho solo get perchè non setto
                                                 // mai manualmente questi ma li ottengo
                                                 // da metodi? 

        public abstract bool VocOrNot { get; }

        public FileGenerico(string filename)  // metodo che preso in input il nome del file
                                              // assegna filename alla proprietà FileName
                                              // dell'oggetto creato
                                     
        {
            this.FileName = filename;
        }

        public string GetFileInformation() //questo è effettivamente inutile
                                           //ma parte del suo esercizio
        {
            return FileName + FileExtention + "=" + VocalNumber.ToString();
        }
    }
}
