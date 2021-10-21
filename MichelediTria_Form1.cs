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

namespace MichelediTria_Form1
{
    public partial class Form1 : Form
    {
        const  int MAX = 100;
        string path = "file.txt";
        char[] vocals = { 'a', 'e', 'i', 'o', 'u' };
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateName()
        {
            int i = 0;
            string[] names = new string[MAX];
            while(i < MAX){         
                names[i] = Path.GetRandomFileName();
                i++;
            }
            File.WriteAllLines(path, names);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateName();
            textBox1.Text = File.ReadAllText(path);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string[] lista = File.ReadAllLines(path);
            Elabora(lista);
            textBox1.Text = File.ReadAllText(path);
        }

        private void Elabora(string[] riga)
        {
            string[] lista = new string[MAX];
            int i = 0;
            foreach(string r in riga)
            {   
                lista[i] = r + " = " + getVocals(r);
                i++;
            }
            
            File.WriteAllLines(path, lista);
        }

        private string getVocals(string riga)
        {
           return "" + riga.Count(c => vocals.Contains(char.ToLower(c)));
        }
    }
}
