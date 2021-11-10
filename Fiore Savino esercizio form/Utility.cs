/**
* @author Savino Fiore
*
* @date - 23/10/2021 
*/

using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp21
{
    public class Utility
    {
        private int contatore = 100;
        private List<string> listaNomi;
        
        private List<char> listaVocali = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

        private List<string> listaNomiConVocali;

        //p.s. non ho lavorato sul pc aziendale, quindi ho dovuto inserire l'intero percorso
        private const string filePath = @"D:\OneDrive\OneDrive - Fincons Spa\Desktop\temp\WindowsFormsApp21\WindowsFormsApp21\TextFile.txt";

        public Utility()
        {
            listaNomi = new List<string>();
            listaNomiConVocali = new List<string>();
        }

        public void generaNomi() //genera i nomi e li aggiunge a una lista
        {

            for(int i = 0; i < contatore; i++)
            {
                string nomeCasuale = Path.GetRandomFileName();
                listaNomi.Add(nomeCasuale);
            }

        }



        public virtual void scriviFile() //scrive il file aggiungendo i nomi generati
        {
            if (File.Exists(filePath) == true )
            {
                File.Delete(filePath);
            }
            foreach (string nomeCasuale in listaNomi)
            {
                File.AppendAllLines(filePath, listaNomi);
            }
        }

        public void modififcaFile() //metodo che modifica il file aggiungendo il conto delle vocali
        {
            contaVocali();
            File.Delete(filePath);


            foreach (string nomeCasuale in listaNomiConVocali)
            {
                File.AppendAllLines(filePath, listaNomiConVocali);
            }
        }

        public string getPath()
        {
            return filePath;
        }

        private void contaVocali() //metodo che conta le vocali e genera una nuova lista
        {
            foreach(string nomeCasuale in listaNomi)
            {
 
                int contaVocali = 0;
                for (int i = 0; i < nomeCasuale.Length; i++)
                {
                    bool risultato = listaVocali.Contains(char.ToLower(nomeCasuale[i]));
                    if(risultato)
                        contaVocali++;
                }
                if (contaVocali>0)
                
                    listaNomiConVocali.Add(nomeCasuale + " Numero vocali: " + contaVocali);
                else
                    listaNomiConVocali.Add(nomeCasuale + " Nessuna vocale ");

            }

           
        }

    }
}