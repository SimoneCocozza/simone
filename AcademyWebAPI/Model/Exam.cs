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
        public IEnumerable<int> Students { get; set; } // IEnumerable perché vogliamo la lista degli ID
                                                       //  deistudenti che hanno sostenuto quell'esame
    }
}
