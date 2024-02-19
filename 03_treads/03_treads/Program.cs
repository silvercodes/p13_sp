

#region Intro

//Thread t = new Thread(ShowPlus);
//t.Start();

//Console.WriteLine(t.IsAlive);

//for (int i = 0; i < 1000; ++i)
//    Console.Write('0');


//void ShowPlus()
//{
//    for (int i = 0; i < 1000; ++i)
//        Console.Write('+');
//}










//void Run()
//{
//    for(int i = 0; i < 5; i++)
//    {
//        Console.Write('0');
//    }
//}

//new Thread(Run).Start();
//Run();







//bool done = false;

//void Run()
//{
//    if (! done)
//    {
//        Console.WriteLine("*");
//        done = true;
//        Console.WriteLine("DONE");

//    }
//}

//new Thread(Run).Start();
//Run();









//bool done = false;
//object locker = new object();

//void Run()
//{
//    lock(locker)
//    {
//        if (!done)
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("DONE");
//            done = true;
//        }
//    }
//}

//new Thread(Run).Start();
//Run();










//void Run()
//{
//    for(int i = 0; i < 1000; i++)
//    {
//        Console.Write('*');
//        Thread.Sleep(1);
//        //Thread.Sleep(TimeSpan.FromSeconds(1));
//    }

//    Console.WriteLine();
//}

//Thread t = new Thread(Run);
//t.Start();
//t.Join(500);                     // Блокируем основной поток (ждём поток t)
//Console.WriteLine("Main finished");





#endregion


#region Create/Start

// ==== Простые способы


//void Run()
//{
//    Console.WriteLine("hello");
//}

//Thread t = new Thread(new ThreadStart(Run));
//t.Start();
//Run();





//Thread t = new Thread(() => Console.WriteLine("Vasia"));
//t.Start();


//string email = "vasia@mail.com";
//Thread t = new Thread(new ThreadStart(() => Console.WriteLine(email)));


//void Calc(int a, int b)
//{
//    Console.WriteLine($"Result = {a + b}");
//}
//int a = 5;
//int b = 6;
//Thread t = new Thread(() => Calc(a, b));
//t.Start();


//void Show(object? val)
//{
//    Console.WriteLine(val.ToString());
//}
//Thread t = new Thread(Show);
//t.Start("Petya");


//void RenderColoredMessage(string message, ConsoleColor color)
//{
//    Console.ForegroundColor = color;
//    Console.WriteLine(message);
//    Console.ResetColor();
//}

//string msg = "Hello";
//ConsoleColor color = ConsoleColor.Red;
//Thread t = new Thread(() => RenderColoredMessage(msg, color));
//t.Start();




// === Подводный камень с лямбдой

// :-(
//for (int i = 0; i < 10; i++)
//    new Thread(() => Console.WriteLine(i)).Start();

//for (int i = 0; i < 10; i++)
//{
//    int x = i;
//    new Thread(() => Console.WriteLine(x)).Start();
//}





//int i;
//List<Thread> threads = new List<Thread>();

//for (i = 0; i < 10; ++i)
//    threads.Add(new Thread(() => Console.WriteLine(i)));

//threads.ForEach(t => t.Start());






//void Run()
//{
//    Console.WriteLine($"Message from {Thread.CurrentThread.Name}");
//}

//Thread.CurrentThread.Name = "main";
//Thread t = new Thread(Run)
//{
//    Name = "worker",
//};

//t.Start();
//Run();

//Console.ReadLine();







//Thread t = new Thread(() => Console.ReadLine());

//if (args.Length > 0)
//    t.IsBackground = true;

//t.Start();




#endregion


#region try/catch

//void Run()
//{
//    throw new Exception("Test Exception");
//}

//try
//{
//    new Thread(Run).Start();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");

//}





//void Run()
//{
//    try
//    {
//        throw new Exception("Test Exception");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//}

//new Thread(Run).Start();


#endregion


#region Thread pooling, TPL (Task parallel library)


// TPL  Task, Task<TResult>, Parallel, ValueTask<> ....
// ThreadPool.QueueUserWorkItem
// async delegates                  // доступно только в .NET Framework !!!
// BackgroundWorker ....


//void Run()
//{
//    Console.WriteLine("Vasia");
//}

////Task task = Task.Factory.StartNew(Run);
////task.Wait();

//await Task.Factory.StartNew(Run);





using System.Net;

//string DownloadPage(string url)
//{
//    WebClient client = new WebClient();
//    return client.DownloadString(url);
//}

//// Console.WriteLine(DownloadPage(@"https://google.com"));

//string url = @"https://google.com";
//Task<string> task = Task.Factory.StartNew(() => DownloadPage(url));

//string result = task.Result;                    // BLOCKING!!!

//Console.WriteLine(result);







//ThreadPool.QueueUserWorkItem(Run, "Vasia");

//Console.ReadLine();

//void Run(object? val)
//{
//    Console.WriteLine($"FROM POOL: {val}");
//}









#endregion

