using BuildHouse.Intarface;
using BuildHouse.Model.PartOfHause;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildHouse.Model
{
    public class HouseProject
    {
        public HouseProject()
        {
            createProject();
            team.createTeam();
            createTasks();
        }

        public Team team = new Team();

        public List<IPart> parts = new List<IPart>();
        public List<ITask> tasks = new List<ITask>();
        public List<IWorker> teamEngaged = new List<IWorker>();
        TimeSpan totalTime=new TimeSpan();
        private Random rnd = new Random();

        public void startBuilding()
        {
            ITask newTask = nonCompleateTask();
            while (newTask != null)
            {
                IWorker worker = team.getWorker();
                
                if (worker.position == Position.manager)
                {
                    getConstructInfo();
                    worker.salary = 5000;
                    worker.salary = worker.calcSalary(totalTime);
                    teamEngaged.Add(worker);
                }
                else
                {
                    tasks[newTask.id].startDate = DateTime.Now;
                    tasks[newTask.id].endDate =
                        tasks[newTask.id].startDate
                                         .AddDays(rnd.Next(2, 30));
                    tasks[newTask.id].status = Status.comlite;
                    tasks[newTask.id].idWorker = worker.id;

                    double diffDay = (tasks[newTask.id].endDate - tasks[newTask.id].startDate).TotalDays;

                    Console.WriteLine("Работа - {0} над {1} началась {2}",
                        worker.fullName, tasks[newTask.id].part.name,
                        tasks[newTask.id].startDate);

                    for (int i = 0; i < diffDay; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(50);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Работы завершены: {0}", tasks[newTask.id].endDate);
                    Console.WriteLine("");

                    TimeSpan ts = tasks[newTask.id].endDate - tasks[newTask.id].startDate;
                    worker.salary = 1000;
                    worker.salary = worker.calcSalary(ts);
                    teamEngaged.Add(worker);
                    totalTime = totalTime + ts;
                }

                newTask = nonCompleateTask();
            }

            Console.WriteLine("Строительство завершено за {0} дней!",totalTime.Days);
            getWorkersSalary();

        }
        private ITask nonCompleateTask()
        {
            return tasks.FirstOrDefault(w => w.status == Status.create);
        }

        public void createProject()
        {
            IPart pBasment = new Basement()
            {
                name = "Basement",
                price = rnd.Next(0,10000),
                count = 1,
                order = 1
            };
            IPart pWall = new Wall()
            {
                name = "Wall",
                price = rnd.Next(0, 10000),
                count = 4,
                order = 2
            };
            IPart pWindow = new Window()
            {
                name = "Window",
                price = rnd.Next(0, 10000),
                count = 4,
                order = 3
            };
            IPart pDoor = new Door()
            {
                name = "Door",
                price = rnd.Next(0, 10000),
                count = 1,
                order = 4
            };
            IPart pRoof = new Roof()
            {
                name = "Roof",
                price = rnd.Next(0, 10000),
                count = 1,
                order = 5
            };
            parts.Add(pBasment);
            parts.Add(pWall);
            parts.Add(pDoor);
            parts.Add(pRoof);
            parts.Add(pWindow);
        }

        public void createTasks()
        {
            int k = 0;
            foreach (IPart part in parts.OrderBy(o => o.order))
            {
                for (int i = 0; i < part.count; i++)
                {
                    ITask task = new Task()
                    {
                        id= k++,
                        part = part
                    };
                    tasks.Add(task);
                }
            }
        }

        public void getConstructInfo()
        {
            Console.WriteLine("Информация о процессе строительства дома: ");
            int cnt = 0;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].status.Equals(Status.comlite))
                {
                    cnt++;
                    Console.WriteLine("Строительство {0} завершилось в {1}", tasks[i].part.name, tasks[i].endDate);
                }
            }
            Console.WriteLine("Завершено {0}% строительства\n", (cnt * 100) / tasks.Count);
        }

        public void getWorkersSalary()
        {
            foreach (var worker in teamEngaged)
            {
                if(worker.position==Position.worker)
                    Console.WriteLine("Заработная плата рабочего: {0}",worker.salary);
                else
                    Console.WriteLine("Заработная плата бригадира: {0}", worker.salary);
            }
        }
    }
}
