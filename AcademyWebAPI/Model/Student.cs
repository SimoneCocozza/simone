using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Model
{
    public class Student
    {
        private int TEST = 1;
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Matricola { get; set; }
        public int Age { get; set; }
        public DateTime DataNascita { get; set; }
        public DateTime DataIscrizione { get; set; }

    }
}
