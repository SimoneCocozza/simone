using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*1) Implementare una classe base (Es: FileGenerico) che rappresenti un generico FILE.
    Questa classe dovrà avere quattro proprietà ed un metodo.

Le proprietà dovranno fornire:
-Solo il nome del file
- Solo l'estensione del file
- Il numero di vocali contenute nel nome
- Presenza di vocali nel nome (true/false)

Il metodo deve ritornare il nome completo del file,
incluso il conteggio delle vocali nella forma: 5eap4ynd.zlo = 3

2) Successivamente implementare due classi derivate dalla prima 
   (Es: FileConVocali, FileSenzaVocali) che rappresentino rispettivamente:
-un file avente numero di vocali > 0
- un file avente nome senza vocali

3) Realizzare una funzionalità che sulla base della discriminante vocali > 0 o vocali = 0 
    istanzi la classe relativa ed inserisca queste istanze in una collection idonea a contenerle

4) Realizzare quindi una funzionalità che legga la collection precedentemente popolata
    e visualizzi a video in due TextBox differenti l'elenco dei nomi file senza vocali
    e quelli con vocali separatamente*/

namespace MyFile_2
{
    public partial class Form1 : Form
    {
        public Form1()             // generato automaticamente
        {
            InitializeComponent();
        }

        public void GeneraFile() //genero un file di nomi casuali  (questo metodo non da ritorno 'void' genera e basta)
        {

            var FileGenerato = new List<string>(); // inizializzo stringa vuota

            for (var i = 0; i < 100; i++)
            {
                FileGenerato.Add(Path.GetRandomFileName()); // sfruttando il metodo GetRandomFileName()
                                                            // aggiungo alla mia lista FileGenerato
                                                            // 100 nomi casuali
            }

            foreach (var d in FileGenerato)
            {
                File.AppendAllLines("FileGenerato.txt", FileGenerato); // creo un file con tutti questi nomi 
            }

        }

        public Risultato GestisciFile(string[] FileGenerato) //metodo che mi ritorna un oggetto Risultato,
                                                             //prende in input un array di stringhe che
                                                             // abbiamo chiamato come la var nel metodo sopra
                                                             // ma non è quella!

        {

            var FileGestitoConVocali = new List<string>(); //creo stringa vuota
            var FileGestitoSenzaVocali = new List<string>(); //creo stringa vuota
            const string vocali = "aeiou"; //creo stringa specifica, non bastava string?
                                           //perchè devo sottolineare sia costante?
            foreach (string d in FileGenerato)
            {
                int n = 0;

                for (int i = 0; i < d.Length; i++)
                {
                    if (vocali.Contains(d[i]))    //conto le vocali 
                        n++;
                }
                if (n > 0)
                {
                    FileGestitoConVocali.Add(d + " = " + n.ToString()); // se ha vocali lo aggiungo alla lista
                                                                        // con vocali
                    var filegen1 = new WithVocals(n, d);         //creo un ogetto WithVocals 
                }
                else
                {
                    FileGestitoSenzaVocali.Add(d + " = " + n.ToString()); //se non ha vocali lo aggiungo alla
                                                                          //lista senza vocali 
                    var filegen2 = new WithoutVocals(d);      // creo un oggetto WithOutVocals
                }
            }
            return new Risultato(FileGestitoSenzaVocali, FileGestitoConVocali);



        }


        private void button1_Click(object sender, EventArgs e)
        //cliccando button1 dal Form genero i file e li gestisco in maniera da avere 
        //la lista di nomi con vocali in una textbox e quella senza vocali nell'altra. 
        {
            GeneraFile();  //faccio generare i nomi di cui ho bisogno

            string[] lista = File.ReadAllLines("FileGenerato.txt"); //trasformo il file generato in Generafile()
                                                                    //in un array di stringhe cosi lo posso passare
                                                                    //a GestisciFile 

            //creo i file sfruttando  il Risultato di GestisciFile. le due proprietà sono FileConVocali
            //e FileSenzaVocali. Le richiamo così perchè Risultato.FileConVocali che è la prima entrata
            //di  Risultato(FileGestitoSenzaVocali, FileGestitoConVocali) come ho specificato nel
            //costruttore della classe.
            File.WriteAllLines("FileGestitoConVocali.txt", GestisciFile(lista).FileConVocali);
            File.WriteAllLines("FileGestitoSenzaVocali.txt", GestisciFile(lista).FileSenzaVocali);

            textBox1.Text = File.ReadAllText("FileGestitoConVocali.txt");  //li metto nelle rispettive textbox
            textBox2.Text = File.ReadAllText("FileGestitoSenzaVocali.txt");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}


