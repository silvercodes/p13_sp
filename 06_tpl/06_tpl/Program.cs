



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


