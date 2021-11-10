using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Es_Windows_Forms_FilippoMolinini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Creates a text file containing 100 random generated names.
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("listanomi.txt", "");                 //Creates a new empty text file.
                    
            for (int i = 0; i < 100; i++)
            {
                File.AppendAllText("listanomi.txt", Path.GetRandomFileName() + "\r\n");     //Creates a random name and writes it inside the previously created text file.
            }

            textBox1.Text = File.ReadAllText("listanomi.txt");      //Shows the previously written text file's contents on the screen.

        }


        //Creates a new text file based on the previous one showing the amount of vowels inside every name
        private void button2_Click(object sender, EventArgs e)
        {
            string[] nomigen;                                       //Creates a new list of string

            nomigen = File.ReadAllLines("listanomi.txt");           //Writes every name from the previously created text file inside every string item in the list

            string[] vocali = { "a", "e", "i", "o", "u" };          //Creates a new list containing every vowel

            int conta = 0;

            File.WriteAllText("listanomivocali.txt", "");           //Creates a new empty text file.

            for (int i = 0; i < 100; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    if (File.ReadAllLines("listanomi.txt")[i].Contains(vocali[j]))         //Checks if a vowel is present inside every name. 
                    {

                        conta++;                                    //Increases the counter by one.

                    }
                
                }

                File.AppendAllText("listanomivocali.txt", File.ReadAllLines("listanomi.txt")[i] + " = " + conta + "\r\n");      //Takes every line from the previously generated file, adds new info and writes them inside a new text file.

                textBox1.Text = File.ReadAllText("listanomivocali.txt");        //Shows the newly written text file's contents on the screen.

                conta = 0;                                          //Resets the counter to 0.

            }

        }
    
    }
}
