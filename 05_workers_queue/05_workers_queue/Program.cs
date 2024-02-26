


using _05_workers_queue.Jobs;
using Queue;

ProducerConcumerQueue queue = new ProducerConcumerQueue(100);
for (int i = 0; i < 1000; ++i)
{
    queue.EnqueuJob(new SendEmailJob() { Email = $"user_{i}@mail.com" });
}


for (int i = 0; i < 10; ++i)
{
    Thread.Sleep(300);
    Console.WriteLine($"Main: {i}");
}