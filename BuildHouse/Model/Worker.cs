using BuildHouse.Intarface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse.Model
{
    class Worker : IWorker
    {
        public Worker(Position position)
        {
            id = Guid.NewGuid();
            this.position = position;
        }
        public Guid id { get; private set; }
        public string fullName { get; set; }
        public double salary { get; set; }
        public Position position { get; private set; }

        public virtual double calcSalary(TimeSpan ts)
        {
            return ts.TotalHours*salary;
        }

        public void printInfo()
        {
            Console.WriteLine("---------------\n{0}\n{1}\nСтавка: {2}\nДолжность: {3}\n---------------",
                id, fullName, salary, position);
        }
    }
}
