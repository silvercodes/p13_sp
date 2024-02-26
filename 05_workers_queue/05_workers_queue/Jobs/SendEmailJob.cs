using Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_workers_queue.Jobs
{
    internal class SendEmailJob : IJob
    {
        public Random random { get; init; }
        public required string Email { get; set; }

        public SendEmailJob()
        {
            random = new Random();
        }

        public void Execute()
        {
            Thread.Sleep(random.Next(50, 200));
            Console.WriteLine($"Email to {Email} was sended...");
        }

        public string GetInfo()
        {
            return $"Email = {Email}";
        }
    }
}
