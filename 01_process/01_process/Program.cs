﻿

// Поток (Thread) (Размещение и выполнение кода)

// Процесс (Process)

// Адрессное пространство (memory scope)

// Сборка (assembly)

// Module

// System resources

// Приложение (application)



// ==== Process ====
// 1. Memory scope
// 2. Исполняемый код
// 3. Системные дискрипторы
// 4. Контекстом системы безопасности
// 5. Идентификатором
// 6. Переменные окружения
// 7. Приоритетом
// 8. Как минимум один поток выполнения



//using System.Diagnostics;

//Process[] processes = Process.GetProcesses();

//var proc = processes.OrderBy(p => p.Id);        // LINQ to objects

////var proc = from p in processes
////           orderby p.Id
////           select p;

//foreach(Process p in proc)
//    Console.WriteLine($"id: {p.Id} {p.ProcessName}");





using System.Diagnostics;

Run();

void Run()
{
    string? input;

    while(true)
    {
        Console.WriteLine("1. Show all processes");
        Console.WriteLine("2. Get process by id");
        Console.WriteLine("3. Show threads");
        Console.WriteLine("4. Show modules");
        Console.WriteLine("5. Start process");
        Console.WriteLine("6. Kill process");
        Console.WriteLine("7. Exit");

        input = Console.ReadLine();

        switch(input)
        {
            case "1":
                ShowAllProcesses();
                break;
            case "2":
                GetProcessById();
                break;
            case "3":
                ShowThreads();
                break;
            case "4":
                ShowModules();
                break;

        }
    }
}

void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}

void ShowAllProcesses()
{
    Process[] processes = Process.GetProcesses();

    var proc = processes.OrderBy(p => p.Id);

    foreach (Process p in proc)
        Console.WriteLine($"id: {p.Id} {p.ProcessName}");
}

void GetProcessById()
{
    Console.Write("Enter PID: ");
    string input = Console.ReadLine();

    try
    {
        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        Console.WriteLine($"{p.Id}\t{p.ProcessName}\t{p.BasePriority}\t{p.StartTime}");
    }
    catch (Exception ex)
    {
        ShowError(ex.Message);

    }
}

void ShowThreads()
{
    Console.Write("Enter PID: ");
    string input = Console.ReadLine();

    try
    {
        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        var threads = p.Threads;

        Console.WriteLine("Threads info:");
        foreach(ProcessThread t in threads)
            Console.WriteLine($"{t.Id}\t{t.StartTime.ToShortTimeString()}\t{t.PriorityLevel}");
    }
    catch (Exception ex)
    {
        ShowError(ex.Message);

    }

    Console.ReadLine();


}

void ShowModules()
{
    Console.Write("Enter PID: ");
    string input = Console.ReadLine();

    try
    {
        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        ProcessModuleCollection modules = p.Modules;

        foreach(ProcessModule m in modules)
            Console.WriteLine($"{m.ModuleName}\t{m.ModuleMemorySize}");
    }
    catch (Exception ex)
    {
        ShowError(ex.Message);

    }

    Console.ReadLine();
}

