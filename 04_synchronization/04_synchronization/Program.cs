

// === Инструменты синхронизации

// 1. Простые методы блоировки (Thread.Sleep(...), Thread.Join(...), Task.Wait(...) .... )

// 2. Контроль критических секций (lock, Monitor{20 нс}, Mutex{1000 нс}, SpinLock, Semaphore{1000 нс}, SemaphoreSlim .... )

// 3. Инструменты сигнализации (Monitor.Pulse()...PulseAll(), .Wait(), AutoResetEvent, ManualResetEvent, ContDownResetEvent... )

// 4. Неблокирующие инструменты (Thread.MemoryBarrier, Thread.VolatileRead, Interlocked ...)




#region Блокировка lock / Monitor (эксклюзивная блокировка)

//Thread t = Thread.CurrentThread;
//bool isBlocked = (t.ThreadState & ThreadState.WaitSleepJoin) != 0;  // :-)
//Console.WriteLine(isBlocked);



// Разблокировка
// 1. Выполнение условий блокировки
// 2. Таймаут
// 3. Thread.Interrupt()
// 4. Threas.Abort()




//new Thread(ThreadUnsafe.Run).Start();
//ThreadUnsafe.Run();


//class ThreadUnsafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;

//        // FIFO
//        lock (locker)
//        {
//            if (b != 0)
//            {
//                c = a / b;
//            }

//            b = 0;
//        }
//    }
//}





//new Thread(ThreadUnsafe.Run).Start();
//ThreadUnsafe.Run();


//class ThreadUnsafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;

//        bool flag = false;


//        try
//        {
//            Monitor.Enter(locker, ref flag);              // Взятие блокировки (попытка)

//            if (b != 0)
//            {
//                c = a / b;
//            }

//            b = 0;
//        }
//        catch(Exception ex)
//        {
//            Console.WriteLine($"Error: {ex.Message}");
//        }
//        finally
//        {
//            if (flag)
//                Monitor.Exit(locker);           // Освобождение блокировки
//        }
//    }
//}








//object locker = new object();
//int val = 0;


//void Run()
//{
//    bool flag = false;

//    try
//	{
//        flag = Monitor.TryEnter(locker, 500);

//        if (flag)
//        {
//            for(int i = 0; i < 10; ++i)
//            {
//                Console.WriteLine($"{Thread.CurrentThread.Name}: {val++}");
//                Thread.Sleep(200);
//            }
//        }

//        Console.WriteLine($"{Thread.CurrentThread.Name} is looser");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error: {ex.Message}");
//    }

//    finally
//    {
//        if (flag)
//            Monitor.Exit(locker);
//	}
//}

//for (int i = 0; i < 3; ++i)
//{
//    Thread t = new Thread(Run)
//    {
//        Name = $"thread_{i}",
//    };
//    t.Start();
//}








//class TSafe
//{
//    private List<string> Emails { get; set; } = new List<string>();
//    //
//    //

//    public void Run()
//    {
//        //
//        //
//        lock(Emails)
//        {
//            Emails.Add("vasia@mail.com");
//            //
//        }

//        //
//        //
//    }
//}








// ==== deadlock

//object locker1 = new object();
//object locker2 = new object();

//new Thread(() =>
//{
//    lock(locker1)
//    {
//        Thread.Sleep(1000);

//        lock(locker2)
//        {
//            //
//            //
//        }
//    }
//}).Start();


//lock(locker2)
//{
//    Thread.Sleep(1000);

//    lock (locker1)
//    {
//        //
//        //
//    }
//}






#endregion


#region Mutex (эксклюзивная блокировка)

//int count = 0;
//Mutex mutex = new Mutex();


//void UseResource()
//{
//    if (mutex.WaitOne(500))
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} take the mutex");

//        Thread.Sleep(200);
//        count++;

//        Console.WriteLine($"{Thread.CurrentThread.Name} done the work");

//        Console.WriteLine($"{Thread.CurrentThread.Name} release mutex");

//        mutex.ReleaseMutex();
//    }
//    else
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} is looser");
//    }
//}

//void StartThreads()
//{
//    for (int i = 0; i < 5; ++i)
//    {
//        Thread t = new Thread(UseResource)
//        {
//            Name = $"thread_{i}",
//        };

//        t.Start();
//    }
//}

//StartThreads();




#endregion


#region Semaphore (НЕэксклюзивная блокировка)


Semaphore semaphore = new Semaphore(0, 3);
int executionTime = 0;
object locker = new object();

void Run(int id)
{
    Console.WriteLine($"Thread {id} started");

    semaphore.WaitOne();                                    // попытка взять блокировку (пройти за семафор)

    Console.WriteLine($"Thread {id} passed semaphore");

    int time;
    lock (locker)
    {
        executionTime += 200;
        time = executionTime;
    }

    Thread.Sleep(time + 2000);

    Console.WriteLine($"Thread {id} relesed semaphore");
    
    semaphore.Release();                                    // освобождает 1 место
}

for (int i = 1; i <= 5; ++i)
{
    int x = i;
    Thread t = new Thread(() => Run(x));
    t.Start();
}

Thread.Sleep(3000);
semaphore.Release(3);                                       // // освобождает 3 места




#endregion








