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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneraNomi();
            textBox1.Text = File.ReadAllText("listaNomi.txt");
           
        }

        

        private void GeneraNomi()
        {
            List<string> listaNomi = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                listaNomi.Add(Path.GetRandomFileName());
            }

            ScriviFile(listaNomi);
        }

        private void ScriviFile(List<string> nomi)
        {
            File.AppendAllLines("listaNomi.txt", nomi);            
            
        }
    }
}
