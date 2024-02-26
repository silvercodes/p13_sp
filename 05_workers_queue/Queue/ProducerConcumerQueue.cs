using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class ProducerConcumerQueue                          // TODO: make IDisposable
    {
        private Queue<IJob> jobs = new Queue<IJob>();
        private int workersCount;
        private List<Thread> threads = new List<Thread>();
        private EventWaitHandle wh = new AutoResetEvent(false);

        public ProducerConcumerQueue(int workersCount)
        {
            this.workersCount = workersCount;

            Init();
        }

        private void Init()
        {
            for (int i = 0; i < workersCount; i++)
            {
                Thread t = new Thread(Handle)
                {
                    Name = $"thread_{i}",
                };

                threads.Add(t);

                t.Start();

            }
        }

        public void EnqueuJob(IJob job)
        {
            lock(jobs)
                jobs.Enqueue(job);

            wh.Set();
        }

        private void Handle()
        {
            while(true)
            {
                IJob? job = null;

                lock(jobs)
                {
                    if (jobs.Count > 0)
                        job = jobs.Dequeue();
                }

                if (job is not null)
                {
                    job.Execute();
                    Console.WriteLine($"{Thread.CurrentThread.Name} HANDLES {job.GetInfo()}");
                }
                else
                {
                    wh.WaitOne();
                }
            }
        }






    }
}
