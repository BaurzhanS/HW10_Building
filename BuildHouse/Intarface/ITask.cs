using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse.Intarface
{
    public enum Status { process, comlite, create }

    public interface ITask
    {
        int id { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        Status status { get; set; }
        IPart part { get; set; }
        Guid idWorker { get; set; }
    }
}
