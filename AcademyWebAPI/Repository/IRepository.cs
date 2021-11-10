using AcademyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetElements();
        T GetElementById(int id);
        bool Exists(int id);
        int AddObject(T element);
        bool Update(int id, T element);
        bool Delete(int id);
    }
}
