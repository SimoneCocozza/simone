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

//* TASK : To Build a Windows Forms application that generates a text file containing a list of 100 random file names and display it inside a TextBox. 
//         Then, realize a functionality that reads the file and adds in correspondence of every name the number of vowels contained in. 
namespace EsForm_SimoneMarinella
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        //The first button called CreateFiles once clicked allows you to display 
        //the contents of 100 random names of a text file. 
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Lista_nomi.txt", ""); //It creates a new file, writes its contents and then closes it. 
            for (int i = 0; i < 100; i++)
            {
                File.AppendAllText("Lista_nomi.txt", Path.GetRandomFileName() + "\r\n"); //Inside the for cicle, it appends the specified string (random one) to the file. 
            }

            textBox1.Text = File.ReadAllText("Lista_nomi.txt"); //It opens a text file, reads all of its text in a string, and then closes it.
        }

        //The second bottom called ElaborateFiles one clicked allow you to to view 
        //the sum of the vowels present in each line of the text file. 
        private void button2_Click(object sender, EventArgs e)
        {
            string[] nomi; //It creats nomi, a list of string. 

            nomi = File.ReadAllLines("Lista_nomi.txt");

            string[] vocali = { "a", "e", "i", "o", "u" }; //It creates vocali, a list of string, consisting of the 5 vowels. 

            int count = 0;
            File.WriteAllText("Lista_nomivoc.txt", ""); 

            for (int i = 0; i < 100; i++) //This for cicle allow to reads into a string array all lines of the file that Returns a value  
            {                             //indicating whether the specified substring (vowels) is present.
                for (int j = 0; j < 5; j++)
                {
                    if (File.ReadAllLines("Lista_nomi.txt")[i].Contains(vocali[j]))
                    {
                        count++;
                    }
                }

                File.AppendAllText("Lista_nomivoc.txt", File.ReadAllLines("Lista_nomi.txt")[i] + " = " + count + "\r\n"); //It attaches the specified string to the file. 
                textBox1.Text = File.ReadAllText("Lista_nomivoc.txt"); //It open the text file with the count of the vowels for each row. 
                count = 0;
            }
        }

    }
}

