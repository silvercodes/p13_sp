

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





int i;
List<Thread> threads = new List<Thread>();

for (i = 0; i < 10; ++i)
    threads.Add(new Thread(() => Console.WriteLine(i)));

threads.ForEach(t => t.Start());

    















#endregion

