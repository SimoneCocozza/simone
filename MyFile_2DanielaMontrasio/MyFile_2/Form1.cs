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

namespace MyFile_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class FileGenerico   // creo la classe FileGenerico con le 4 proprietà e il metodo
        {
           public string FileName{ get; set; }
           public string FileExtention { get; set; }

           public int VocalNumber;

           public bool VocOrNot;

         public string GetFileInformation ()
         {
            return FileName + FileExtention + "=" + VocalNumber.ToString();
         }
        }

        public class WithVocals : FileGenerico
        { //creo la sottoclasse WithVocals senza istanziarla
        }

        public class WithOutVocals:FileGenerico
        { // creo la sottoclasse WithoutVocals senza istanziarla 
        
        }


        public void GetTheClass(FileGenerico filegen) 
        { //volevo creare un metodo che istanziasse filgen come un oggetto WithVocals se 
          // Il nome di filegen ha vocali, altrimenti lo istanzio come WithoutVocals


        public void GeneraFile()
        {

            List<string> FileGenerato = new List<string>();

            for (int i = 0; i < 100; i++)
            {

                FileGenerato.Add(Path.GetRandomFileName());

            }

            foreach (string d in FileGenerato)
            {
                File.AppendAllLines("FileGenerato.txt", FileGenerato);

            }

        }

        public List<string>[] GestisciFile(string[] FileGenerato)
            {

            List<string> FileGestitoConVocali = new List<string>();
            List<string> FileGestitoSenzaVocali = new List<string>();
            string vocali = "aeiou";
                foreach (string d in FileGenerato)
                {
                    int n = 0;

                    for (int i = 0; i < d.Length; i++)
                    {
                        if (vocali.Contains(d[i])) n++;
                    }
                if (n > 0)
                {
                    FileGestitoConVocali.Add(d + " = " + n.ToString()); // se ha vocali lo aggiungo alla lista xon vocali
                    WithVocals filegen1 = new WithVocals();         //creo un ogetto WithVocals 
                    filegen1.FileName = d;
                    filegen1.FileExtention = ".exe";
                    filegen1.VocalNumber = n;
                    filegen1.VocOrNot = true;
                }
                else {
                    FileGestitoSenzaVocali.Add(d + " = " + n.ToString()); //se non ha vocali lo aggiungo alla lista senza vocali 
                    WithOutVocals filegen2 = new WithOutVocals();      // creo un oggetto WithOutVocals
                    filegen2.FileName = d;
                    filegen2.FileExtention = ".exe";
                    filegen2.VocalNumber = 0;
                    filegen2.VocOrNot = false;
                    
                }
              
               
                }

            List<string>[] ArrayList = new List<string>[2];
            ArrayList[0] = FileGestitoConVocali;
            ArrayList[1] = FileGestitoSenzaVocali;
            return ArrayList;
            
            }

            private void button1_Click(object sender, EventArgs e)
        {  
            GeneraFile(); 
        
            string[] lista = File.ReadAllLines("FileGenerato.txt");

            File.WriteAllLines("FileGestitoConVocali.txt", GestisciFile(lista)[0]);
            File.WriteAllLines("FileGestitoSenzaVocali.txt", GestisciFile(lista)[1]);

            textBox1.Text = File.ReadAllText("FileGestitoConVocali.txt");
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
