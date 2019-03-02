using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse.Intarface
{
    public enum Position { manager, worker}
    public interface IWorker
    {
        Guid id { get; }
        string fullName { get; set; }
        double salary { get; set; }
        Position position { get; }            
        void printInfo();
        double calcSalary(TimeSpan ts);   
        
    }
}
