using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Model
{
    public class Exam
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ExamDate { get; set; }

        public IEnumerable<int> Students { get; set; }//lista di ID di studenti
    }
}
