using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Class1
    {

        public class FileGenerico
        {
            public string nome { get; set; }
            public string estensione { get; set; }
            public int numVocali { get; set; }

            public virtual bool? hasVocale { get { return null; } }

            public string GetNomeCompleto()
            {
                return nome + estensione + " = " + numVocali.ToString();
            }

            
            
        }

        public class FileConVocali : FileGenerico
        {
            public override bool? hasVocale { get { return true; } }
        }

        public class FileSenzaVocali : FileGenerico
        {
            public override bool? hasVocale { get { return false; } }
        }
    }
}
