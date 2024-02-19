

// === Инструменты синхронизации

// 1. Простые методы блоировки (Thread.Sleep(...), Thread.Join(...), Task.Wait(...) .... )

// 2. Контроль критических секций (lock, Monitor, Mutex, SpinLock, Semaphore, SemaphoreSlim .... )

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





new Thread(ThreadUnsafe.Run).Start();
ThreadUnsafe.Run();


class ThreadUnsafe
{
    static int a = 10;
    static int b = 20;
    static object locker = new object();

    public static void Run()
    {
        int c = 0;

        Monitor.Enter(locker);              // Взятие блокировки (попытка)

        try
        {
            if (b != 0)
            {
                c = a / b;
            }

            b = 0;
        }
        finally
        {
            Monitor.Exit(locker);           // Освобождение блокировки
        }
    }
}







#endregion








