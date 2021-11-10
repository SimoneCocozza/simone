using System;

namespace accademy
{
    public class RandomFile
    {
        public string FileName { protected set; get; }
        public string Extension { protected set; get; }
        public int VocalNumber { protected set; get; }

        public bool hasVocal { get => this.VocalNumber > 0; }


        public RandomFile(string format)
        {
            List<string> elements = format.Split(" = ")[0].
                    Split(".").ToList();

            this.FileName = elements[0];
            this.Extension = elements[1];


        }

        public RandomFile() { }

        //TODO make constant
        char[] vocals = new char[] { 'a', 'e', 'i', 'o', 'u' };

        public override string ToString() =>
            this.FileName + "." + this.Extension;
        

        public string getVocalCouter()
        {
            this.VocalNumber = this.ToString().Count(c => vocals.Contains(char.ToLower(c)));
            return this.ToString() + " = " + this.VocalNumber;
        }


        public static RandomFile getRandomFile()
        {
            RandomFile file = new RandomFile();
            file.FileName = RandomStringGenerator.getIstance().getRandomString();
            file.Extension = RandomStringGenerator.getIstance().getRandomStringFixedLength(3);

            return file;
        }
    }


    public class RandomFileWithVocal : RandomFile
    {
        public RandomFileWithVocal(string rappresentation) : base(rappresentation)
        {
            if (this.VocalNumber > 0)
                throw new ArgumentException();
        }

    }



    public class RandomFileWithoutVocal : RandomFile
    {
        public RandomFileWithoutVocal(string rappresentation) : base(rappresentation)
        {
        if (this.VocalNumber == 0)
            throw new ArgumentException();
        }
    }

    public class RandomStringGenerator
    {
        private static RandomStringGenerator Istance = null;
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private RandomStringGenerator() { }

        public static RandomStringGenerator getIstance()
        {
            if (Istance == null)
                Istance = new RandomStringGenerator();
            return Istance;
        }

        private string getRandomString(uint length)
        {
            //todo 
            int maxLen = (int)( length%20);
            Random random = new Random();
            string toRet = "";
            for (int i = 0; i < maxLen; i++)
                toRet += chars[random.Next(chars.Length)];
            return toRet;
        }

        public string getRandomStringFixedLength(int length) => this.getRandomString((uint)length);
        public string getRandomString() => this.getRandomString(((uint)new Random().NextInt64()));


    }


    public class Program
    {
        public static void Main(string[] args)
        {

            string outputFile = "names.txt";
            //punto 1
            string names = "";
            for (int i = 0; i < 100; i++)
                names += RandomFile.getRandomFile().ToString() + ((i == 99) ? "" : "\n");

            Console.WriteLine(names);
            File.WriteAllText(outputFile, names);

            //punto 2
            Console.WriteLine("\n\nSecond step\n\n");

            names = "";
            foreach(string line in File.ReadLines(outputFile))
            {
                names += new RandomFile(line).getVocalCouter() + "\n";
            }

            Console.WriteLine(names);

            File.WriteAllText(outputFile,names);

            //punto 3
            Console.WriteLine("\n\nWith vocal writes\n\n");
            List<RandomFileWithoutVocal> withoutVocals = new List<RandomFileWithoutVocal>();
            List<RandomFileWithVocal> withVocals = new List<RandomFileWithVocal>();
            foreach (string line in File.ReadLines(outputFile))
            {
                try
                {
                    RandomFileWithoutVocal wv = new RandomFileWithoutVocal(line);
                    withoutVocals.Add(wv);
                }catch(ArgumentException e)
                {
                    withVocals.Add(new RandomFileWithVocal(line));
                    Console.WriteLine(line);
                }
            }

        }
    }

}

