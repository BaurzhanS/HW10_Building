using BuildHouse.Intarface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomUser;

namespace BuildHouse.Model
{
    public class Team
    {
        public List<IWorker> team = new List<IWorker>();

        Random rnd = new Random();

        public void createTeam()
        {
            var user = GenerateUser.GetUser();

            TeamLeader tl = new TeamLeader();
            tl.fullName= string.Format("{0} {1}",user.name.title, user.name.first);
            tl.salary= rnd.Next(1000, 5000);
            team.Add(tl);

            for (int i = 0; i < rnd.Next(4,10); i++)
            {
                user = GenerateUser.GetUser();

                Worker worker = new Worker(Position.worker);
                worker.fullName = string.Format("{0} {1}", user.name.title, user.name.first);
                worker.salary = rnd.Next(1000, 5000);

                team.Add(worker);
            }
        }

        public IWorker getWorker()
        {
            return team[rnd.Next(0, team.Count-1)];
        }
    }
}
