using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Model
{
    public class UpdateResult
    {
        public UpdateState State { get; set; }
    }
    public enum UpdateState
    {
        Updated,
        NotExisting,
        Error
    }
}
