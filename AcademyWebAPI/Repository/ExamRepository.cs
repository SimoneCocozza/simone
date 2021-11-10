using AcademyWebAPI.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Repository
{
    public class ExamRepository : IRepository<Exam>
    {
        ConcurrentDictionary<int, Exam> Elements = new ConcurrentDictionary<int, Exam>();
        public ExamRepository()
        {
            Elements.TryAdd(1, new Exam
            {
                ID = 1,
                Name = "Fondamenti di Programmazione",
                ExamDate = DateTime.Now.AddDays(-100),
                Students = new List<int> // IEnumerable non può essere inserito perché è un'interfaccia
                {
                    1,2
                }

            });
            Elements.TryAdd(2, new Exam
            {
                ID = 2,
                Name = "Architetture degli Elaboratori",
                ExamDate = DateTime.Now.AddDays(-50),
                Students = new List<int>
                {
                    2,3
                }
            });
        }


        public int AddObject(Exam Exam)
        {
            if (Elements.TryAdd(Exam.ID, Exam))
                return Exam.ID;

            return 0;
        }

        public bool Delete(int id)
        {
            return Elements.TryRemove(id, out Exam Exam);
        }

        public bool Exists(int id)
        {
            return Elements.ContainsKey(id);
        }

        public Exam GetElementById(int id)
        {
            if (Elements.TryGetValue(id, out Exam Exam))
            {
                return Exam;
            }

            return null;
        }

        public IEnumerable<Exam> GetElements()
        {
            return Elements.Values.ToList();
        }

        public bool Update(int id, Exam Exam)
        {
            if (Elements.TryGetValue(id, out Exam value))
            {
                return Elements.TryUpdate(id, Exam, value);
            }
            return false;
        }

    }
}
