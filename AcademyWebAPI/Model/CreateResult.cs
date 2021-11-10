using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Model
{
    public class CreateResult
    {
        public int ID { get; set; }
        public CreateState State { get; set; }
    }
    public enum CreateState//creo oggetto che mi rappresenta lo stato

    {
        AlreadyExisting,
        Created,
        Error
    }
}
