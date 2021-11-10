using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFile_2
{
    class WithVocals : FileGenerico //classe che eredita da FileGenerico,
                                    //dunque ho le proprietà definite la.
    {
        public override int VocalNumber  //quando istanzio un oggetto WithVocals
                                         //faccio l'override di VocalNumber nella
                                         //classe astratta padre. In pratica lo sto leggendo
                                         //e quando creo un oggetto cosi gli viene assegnato
                                         //il numero di vocali è assegnato attraverso il metodo
                                         //public WithVocals(int numberOfVocals, string filename)

        {
            get;
        }

        public override bool VocOrNot => true; // se creo un oggetto di questo tipo allora vuol
                                               // dire che vocornot è per forza true. Quindi ha
                                               // senso farlo a questo livello della programmazione
                                               // in quanto comune a tutti gli oggetti di questo tipo.





        // Lascio questo esempio come implementazione alternativa
        // Anche le proprietà dell'altro tipo di file possono essere fatte così
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

        public WithVocals(int numberOfVocals, string filename) // questo è un metodo che credo assegni
                                                               // il VocalNumber ad un oggetto WithVocals
                                                               // considerando l'associazione attraverso
                                                               // il filename. Inoltre sfruttando il metodo
                                                               // in FileGenerico assegna all'oggetto anche il nome.
                                                               // Però non so bene come funzioni
                                                               // il ": base(filename)"
            : base(filename) 
        {
            this.VocalNumber = numberOfVocals;
        }


    }

    class WithoutVocals : FileGenerico     //stesso concetto di sopra. 
    {
        public override int VocalNumber => 0;  // non ho bisogno di un metodo che mi ritorni il vocalnumber,
                                               // è ovviamente sempre 0. 
        public override bool VocOrNot => false; //stesso di sopra


        public WithoutVocals(string filename)  //qui non assegno il numero delle vocali
                                               //perchè è sempre zero però richiamo con quel
                                               //"base(filename)" il metodo nella superclasse che 
                                               //assegna il nome 
          : base(filename) { }
    }
}
