using BuildHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            HouseProject project = new HouseProject();
            project.startBuilding();
        }
    }
}
