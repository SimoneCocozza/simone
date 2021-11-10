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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeFiles();
            
        }

        private void InitializeFiles()
        {
            List<Class1.FileSenzaVocali> listaSenzaVoc = new List<Class1.FileSenzaVocali>();
            List<Class1.FileConVocali> listaConVoc = new List<Class1.FileConVocali>();
            List<string> nomi = GeneraNomi();
            List<string> nomiCompleti = SelezionaVocali(nomi);

            foreach (string n in nomiCompleti)
            {
               
                switch (Int32.Parse(n.Substring(n.Length-1)))
                {
                    case 0:
                        listaSenzaVoc.Add(new Class1.FileSenzaVocali { nome = n.Substring(0,8), estensione = n.Substring(8,4), numVocali = 0 });                        
                        break;

                    default:
                        listaConVoc.Add(new Class1.FileConVocali { nome = n.Substring(0, 8), estensione = n.Substring(8,4), numVocali = Int32.Parse(n.Substring(n.Length-1))});
                        break;
                }
            }

            foreach(Class1.FileConVocali f in listaConVoc)
            {
                textBox1.AppendText(f.GetNomeCompleto() + "\r\n");
            }

            foreach (Class1.FileSenzaVocali f in listaSenzaVoc)
            {
                textBox2.AppendText(f.GetNomeCompleto() + "\r\n");
            }

        }

        private List<string> GeneraNomi()
        {
            List<string> listaNomi = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                listaNomi.Add(Path.GetRandomFileName());
            }
            
            return listaNomi;
        }

        private List<string> SelezionaVocali(List<string> listaNomi)
        {
            string vocali = "aeiou";
            List<string> listaNuova = new List<string>();

            foreach (string n in listaNomi)
            {
                int count = 0;

                for (int i = 0; i < n.Length; i++)
                {
                    if (vocali.Contains(n[i])) count++;
                }

                listaNuova.Add(n + " = " + count.ToString());
            }

            return listaNuova;
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
