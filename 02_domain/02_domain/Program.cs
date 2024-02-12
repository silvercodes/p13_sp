
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

ctx.Unloading += ctx => Console.WriteLine("AssemblyContext unloaded!!!!!!!!!!!");


Assembly assembly = ctx.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "MathLib.dll"));

domain = AppDomain.CurrentDomain;
Console.WriteLine("====== After loading:");
foreach (Assembly a in domain.GetAssemblies())
    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");

Type? type = assembly.GetType("MathLib.Calc");

// --- static call
//MethodInfo? staticMethod = type?.GetMethod("Factorial");
//int? factorial = (int?)staticMethod.Invoke(assembly, new object[] { 5 });
//Console.WriteLine($"Factorial: {factorial}");


// --- non-static call
MethodInfo? method = type?.GetMethod("Sum");
var calc = Activator.CreateInstance(type);
int? sum = (int?)method.Invoke(calc, new object[] { 4, 5 });
Console.WriteLine($"Sum = {sum}");


ctx.Unload();
GC.Collect();


domain = AppDomain.CurrentDomain;
Console.WriteLine("====== After unloading:");
foreach (Assembly a in domain.GetAssemblies())
    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");







