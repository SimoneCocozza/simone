using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Model
{
    public class Professor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cognome { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}
