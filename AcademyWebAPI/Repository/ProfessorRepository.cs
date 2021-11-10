using AcademyWebAPI.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Repository
{
    public class ProfessorRepository : IRepository<Professor>
    {
        ConcurrentDictionary<int, Professor> Elements = new ConcurrentDictionary<int, Professor>();
        public ProfessorRepository()
        {
            Elements.TryAdd(1, new Professor()
            {
                ID = 1,
                Name = "Dario",
                Cognome = "Vanneschi"
            });
            Elements.TryAdd(2, new Professor
            {
                ID = 2,
                Name = "Paolo",
                Cognome = "Ferragina"
            });
        }

        public int AddObject(Professor Professor)
        {
            if (Elements.TryAdd(Professor.ID, Professor))
                return Professor.ID;

            return 0;
        }

        public bool Delete(int id)
        {
            return Elements.TryRemove(id, out Professor Professor);
        }

        public bool Exists(int id)
        {
            return Elements.ContainsKey(id);
        }

        public Professor GetElementById(int id)
        {
            if (Elements.TryGetValue(id, out Professor Professor))
            {
                return Professor;
            }

            return null;
        }

        public IEnumerable<Professor> GetElements()
        {
            return Elements.Values.ToList();
        }

        public bool Update(int id, Professor Professor)
        {
            if (Elements.TryGetValue(id, out Professor value))
            {
                return Elements.TryUpdate(id, Professor, value);
            }
            return false;
        }
    }
}
