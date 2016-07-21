using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz
{
    class Workflow
    {
        public Clock WorkClock { get { return _clock; } }

        private Clock _clock;
        private List<Task> _tasks;
        private List<Worker> _workers;

        public Workflow(Clock clock, Task[] tasks, Worker[] workers)
        {
            _clock = clock;
            _tasks = new List<Task>(tasks);
            _workers = new List<Worker>(workers);
        }

        public Workflow(Task[] tasks, Worker[] workers) : this(new Clock(false), tasks, workers)
        {

        }

        public void AddTasks(params Task[] tasks)
        {
            foreach (Task task in tasks)
            {
                _tasks.Add(task);
                AssignTask(task);
            }
        }

        public void AddWorkers(params Worker[] workers)
        {
            foreach (Worker worker in workers)
            {
                _workers.Add(worker);
            }
        }

        public void AssignTasks()
        {
            foreach(Task task in _tasks)
            {
                AssignTask(task);
            }
        }

        private void Execute()
        {
            _clock.Start();
            foreach (Worker worker in _workers)
            {
                worker.ExecuteTask();
            }
            _clock.Stop();
        }


        private void AssignTask(Task task)
        {
            int workerIndex = 0;
            // Somehow decide which worker to choose by setting workerIndex.
            _workers[workerIndex].GiveTask(task);
        }

    }
}
