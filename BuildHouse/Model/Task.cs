using BuildHouse.Intarface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse.Model
{
    public class Task : ITask
    {
        public Task()
        {
            status = Status.create;
            //startDate = DateTime.Now;
        }

        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Status status { get; set; }
        public IPart part { get; set; }
        public Guid idWorker { get; set; }
    }
}
