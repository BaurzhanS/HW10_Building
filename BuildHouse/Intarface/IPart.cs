using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse.Intarface
{
    public interface IPart
    {
        string name { get; set; }
        double price { get; set; }
        int count { get; set; }
        int order { get; set; }
        ITask task { get; set; }
        string getInfo(); 
    }
}
