using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string filePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneratoreDeiNomi();

            textBox2.Text = File.ReadAllText("listaNomi.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lista = File.ReadAllLines("listaNomi.txt");
            File.WriteAllLines("nuovaLista.txt", ContaVocali(lista));

            textBox2.Text = File.ReadAllText("nuovaLista.txt");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        public void GeneratoreDeiNomi()
        {

            List<string> listaNomi = new List<string>();
                for (int i = 0; i< 100; i++)
                {
                    listaNomi.Add(Path.GetRandomFileName());
                }
            Stampa(listaNomi);
        }

        private void Stampa(List<string>nomiGenerati)
        {
            foreach(string d in nomiGenerati)
            {
                File.AppendAllLines("listaNomi.txt", nomiGenerati);
            }
        }

        private List<string>  ContaVocali(string[] listaNomi)
        {
            string vocali = "aeiou";
            List<string> listaAggiornata = new List<string>();

            foreach (string d in listaNomi)
            {
                int count = 0;

                for (int i = 0; i < d.Length; i++)
                {
                    if (vocali.Contains(d[i])) count++;
                }

                listaAggiornata.Add(d + " = " + count.ToString());
            }

            return listaAggiornata;
        }
    }
}
