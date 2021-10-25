using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    public class File
    {
        public string nome { get; protected set; }
        public string estensione { get; protected set; }
        public int numeroVocali { get; protected set; }
        public bool contieneVocali;

        // Lista contenente tutte le vocali
        List<Char> vocali = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        public List<String> nomiCasuali = new List<String>();

        public File()
        {

        }
        public File(string nome, string estensione)
        {
            this.nome = nome;
            this.estensione = estensione;
        }

        public virtual void generaNomiCasuali(int nNomi)
        {
            // Genera x nomi casuali
            for (int i = 0; i < nNomi; i++)
                nomiCasuali.Add(Path.GetRandomFileName());
        }
        public void generaFile()
        {
            // Salva in un file di testo i nomi che sono stati generati
            System.IO.File.WriteAllLines(nome + estensione, nomiCasuali);
        }


        public void contaVocali()
        {
            // Legge il file di testo precedentemente generato, conta il numero di vocali e le aggiunge alla fine di ogni riga
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\hp\Documents\.Net\Test\" + nome + estensione);

                for (int i = 0; i < lines.Length; i++)
                {
                    int contatoreVocali = 0;

                    foreach (char chr in vocali)
                    {
                        if (lines[i].Contains(chr))
                        {
                            contatoreVocali++;
                        }
                    }

                    lines[i] = lines[i] + " = " + contatoreVocali;

                    // contieneVocali = (contatoreVocali > 0) ? true : false;
                }

                System.IO.File.WriteAllLines(this.nome + this.estensione, lines);
            }
            catch
            {
                Console.WriteLine("Errore nell'aggiungere il numero di vocali nel file indicato.");
            }
        }
    }

    public class FileConVocali : File
    {

        public override void generaNomiCasuali(int nNomi)
        {
            // Genera nomi casuali con Vocali
        }
    }

    public class FileSenzaVocali : File
    {
        public override void generaNomiCasuali(int nNomi)
        {
            // Genera nomi casuali Senza Vocali
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            File uno = new File("Prova", ".txt");

            uno.generaNomiCasuali(100);
            uno.generaFile();
            uno.contaVocali();
        }
    }
}
