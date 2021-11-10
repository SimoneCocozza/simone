using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Model
{
    public class DeleteResult
    {
        public string Message { get; set; }
        public object RemovedObject { get; set; }

        public DeleteState State { get; set; }

        public enum DeleteState
        {
            Deleted,
            NotExisting,
            Error
        }
    }
}
