



// === Создание задач

//Task t1 = new Task(() => Console.WriteLine("Vasia"));
//t1.Start();

//Task t2 = Task.Factory.StartNew(() => Console.WriteLine("Petya"));

//Task t3 = Task.Run(() => Console.WriteLine("Dima"));


////
////
////

//t1.Wait();
//t2.Wait();
//t3.Wait();





// === Синхронное выполнение
//Task t = new Task(() =>
//{
//    Console.WriteLine("start");
//    Thread.Sleep(1000);
//    Console.WriteLine("end");
//});

//// t.Start();               // async call
//t.RunSynchronously();       // sync call





// === Состояние задач

//Task t = new Task(() =>
//{
//    Console.WriteLine("start");
//    Thread.Sleep(1000);
//    Console.WriteLine("end");
//});

//t.Start();

//Console.WriteLine(t.Id);
//Console.WriteLine(t.Status);
//Console.WriteLine(t.IsCompleted);

//t.Wait();







// === Вложенные(дочерние) задачи

//Task t1 = new Task(() =>
//{
//    Console.WriteLine("t1 started");

//    Task t2 = new Task(() =>
//    {
//        Console.WriteLine("t2 started");
//        Thread.Sleep(3000);
//        Console.WriteLine("t2 finished");
//    }, TaskCreationOptions.AttachedToParent);

//    t2.Start();

//    Console.WriteLine("t1 finished");
//});

//t1.Start();
//t1.Wait();

//Console.WriteLine("Main finished");






// === массив задач

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//List<Task> tasks = new List<Task>()
//{
//    new Task(() =>
//    {
//        Thread.Sleep(1000);
//        Console.WriteLine("Task 1000 finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(1200);
//        Console.WriteLine("Task 1200 finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(2000);
//        Console.WriteLine("Task 2000 finished");
//    }),
//};

//tasks.ForEach(t => t.Start());

//// Task.WaitAll(tasks.ToArray());
//Task.WaitAny(tasks.ToArray());

//Console.WriteLine($"Result time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");

//Console.WriteLine("Main finished");





// === Возврат результата


//Task<int> t = new Task<int>(() =>
//{
//    Thread.Sleep(1000);
//    return 10;
//});

//t.Start();
//int result = t.Result;              // BLOCKING
//Console.WriteLine(result);

//Console.WriteLine("Main finished");




//Task<int> t = new Task<int>(() => Sum(3, 4));
//t.Start();
//int Sum(int a, int b) => a + b;

//Console.WriteLine(t.Result);         // BLOCKING





//Task<Thread> t = new Task<Thread>(() =>
//{
//    Thread t = new Thread(() => Console.WriteLine("test"));

//    return t;
//});

//t.Start();






// === Цепочка тасков


//Task<int> t = new Task<int>(() =>
//{
//    Task<int> t1 = new Task<int>(() => 5);
//    t1.Start();
//    //
//    //
//    int r = t1.Result;

//    Task<int> t2 = new Task<int>(() => r * r);
//    t2.Start();

//    return t1.Result;
//});

//t.Start();
////
////
////

//Console.WriteLine(t.Result);





//Task t1 = new Task(() => Console.WriteLine("start task"));

//Task t2 = t1.ContinueWith(t =>
//{
//    Console.WriteLine(t.Id);
//    Console.WriteLine(Task.CurrentId);
//});

//t1.Start();
//t2.Wait();




//Task t1 = new Task(() => Console.WriteLine("start task"));

//Task chain = t1
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id));

//t1.Start();
////
////
//chain.Wait();





//Task<int> t1 = new Task<int>(() => Sum(3, 4));
//Task t2 = t1.ContinueWith(t =>
//{
//    Thread.Sleep(100);
//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine(t.Result);
//    Console.ResetColor();
//});

//t1.Start();
////
////
//Console.WriteLine("From Main");
//t2.Wait();


//int Sum(int a, int b) => a + b;







//=================== Parallel ==================

// --- Invoke()

//Parallel.Invoke(
//    TestPrint,
//    () => Console.WriteLine("test lambda"),
//    () => Sum(3, 4)
//);

//void TestPrint()
//{
//    Thread.Sleep(2000);
//    Console.WriteLine("Test print");
//}

//void Sum(int a, int b) => Console.WriteLine(a + b);




// --- For
//ThreadPool.SetMinThreads(20, 4);

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//Parallel.For(0, 20, i =>
//{
//    Console.WriteLine($"task_{Task.CurrentId}: {i}");
//    Thread.Sleep(1000);
//});

//Console.WriteLine($"Result time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");




// --- Foreach

//ThreadPool.SetMinThreads(20, 4);

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//List<int> nums = new List<int>() { 4, 1, 7, 3, 6, 9, 0 };

//Parallel.ForEach(nums, n =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine(n);
//});

//Console.WriteLine($"Result time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");






// --- Мягкое прерывание таска


//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken token = cts.Token;


//Task t = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            Console.WriteLine("Cancellation requested");
//            return;
//        }

//        Console.WriteLine(i);
//        Thread.Sleep(1000);
//    }
//}, token);

//t.Start();

//Console.ReadLine();
//cts.Cancel();               // token ---> IsCancellationRequested

//Thread.Sleep(1000);
//Console.WriteLine(t.Status);






// --- Жёсткое прерывание таска


CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;


Task t = new Task(() =>
{
    Task t1 = new Task(() =>
    {
        Thread.Sleep(5000);
        throw new ArgumentException("ha-ha");

    });
    t1.Start();

    Task t2 = new Task(() =>
    {
        Thread.Sleep(7000);
        throw new ArgumentException("ho-ho");

    });
    t2.Start();


    for (int i = 0; i < 10; i++)
    {
        if (token.IsCancellationRequested)
        {
            token.ThrowIfCancellationRequested();
            // throw new ArgumentException("ha-ha");
        }

        Console.WriteLine(i);
        Thread.Sleep(1000);
    }

}, token);


try
{
    t.Start();

    Console.ReadLine();
    cts.Cancel();               // token ---> IsCancellationRequested

    t.Wait();
}
catch (AggregateException aex)
{
    Console.WriteLine($"count = {aex.InnerExceptions.Count}");
    foreach (Exception ex in aex.InnerExceptions)
    {
        if (ex is TaskCanceledException)
            Console.WriteLine("Task cancelled...");
        else
            Console.WriteLine($"ERROR: {ex.Message}");
    }
}


Thread.Sleep(1000);
Console.WriteLine(t.Status);

Console.ReadLine();



