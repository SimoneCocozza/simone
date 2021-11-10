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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lista = File.ReadAllLines("listaNomi.txt");
            File.WriteAllLines("nuovaLista.txt",SelezionaVocali(lista));

            textBox1.Text = File.ReadAllText("nuovaLista.txt");
        }

        private List<string> SelezionaVocali(string[] listaNomi)
        {
            string vocali = "aeiou";
            List<string> listaNuova = new List<string>();
            
            foreach(string n in listaNomi)
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

       
    }
}
