using AcademyWebAPI.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        ConcurrentDictionary<int, Student> Elements = new ConcurrentDictionary<int, Student>();
        public StudentRepository()
        {
            Elements.TryAdd(1, new Student()
            {
                ID = 1,
                Nome = "Gianmarco",
                Cognome = "Maruca",
                Age = 20,
                DataIscrizione = DateTime.Now
            });
            Elements.TryAdd(2, new Student
            {
                ID = 2,
                Nome = "Simone",
                Cognome = "Annechiarico",
                Age = 22,
                DataIscrizione = DateTime.UtcNow
            });
            Elements.TryAdd(3, new PHD
            {
                ID = 3,
                Nome = "Daniela",
                Cognome = "Montrasio",
                Age = 22,
                DataIscrizione = DateTime.UtcNow,
                DegreeMark = 110
            }) ;
        }

        public int AddObject(Student student)
        {
            if(Elements.TryAdd(student.ID, student))
                return student.ID;

            return 0;
        }

        public bool Delete(int id)
        {
            return Elements.TryRemove(id, out Student student);
        }

        public bool Exists(int id)
        {
            return Elements.ContainsKey(id);
        }

        public Student GetElementById(int id)
        {
            if (Elements.TryGetValue(id, out Student student))
            {
                return student;
            }

            return null;
        }

        public IEnumerable<Student> GetElements()
        {
            return Elements.Values.ToList();
        }

        public bool Update(int id, Student student)
        {
            if (Elements.TryGetValue(id, out Student value))
            {
                return Elements.TryUpdate(id, student, value);
            }
            return false;
        }


    }
}
