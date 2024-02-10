
using System.Reflection;
using System.Runtime.Loader;

//AppDomain domain = AppDomain.CurrentDomain;

//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//foreach(Assembly a in domain.GetAssemblies())
//    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");





// Статическая загрузка сборки (информация о сборке MathLib.dll ---> метаданные)
//using MathLib;

//AppDomain domain = AppDomain.CurrentDomain;

//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//foreach (Assembly a in domain.GetAssemblies())
//    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");

//Calc calc = new Calc();
//Console.WriteLine(calc.Sum(3, 4));




// Динамическая загрузка сборки
AppDomain domain = AppDomain.CurrentDomain;
Console.WriteLine("====== Before loading:");
foreach (Assembly a in domain.GetAssemblies())
    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");


var ctx = new AssemblyLoadContext("lib_ctx", true);


Assembly assembly = ctx.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "MathLib.dll"));

domain = AppDomain.CurrentDomain;
Console.WriteLine("====== After loading:");
foreach (Assembly a in domain.GetAssemblies())
    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");








