

// 1.
// Возврат
// Task
// Task<T>
// void         :-(
// ValueTask<>
// IAsyncEnumerable<T>          // from .NET 7
// IAsyncEnumerator<T>          // from .NET 7

// 2.
// async / await

// 3. ....Async





// using System.Reflection.Metadata;
// using System.Runtime.CompilerServices;

//await 5;

//public class MyAwaiter : INotifyCompletion
//{
//    public bool IsCompleted => false;
//    public void OnCompleted(Action continuation)
//    {}
//    public void GetResult() { }
//}


//public static class ExtensionManager
//{
//    public static MyAwaiter GetAwaiter(this int u)
//    {
//        return new MyAwaiter();
//    }
//}





//async Task MethodAsync()
//{
//    Console.WriteLine("Before call");

//    Task t = Task.Delay(1000);

//    Console.WriteLine("After call");

//    await t;

//    Console.WriteLine("After await");

//    // bind Data
//    // hide Preloader();
//}


////
////
////

//// show Preloader
//_ = MethodAsync();










//async Task RenderAsync()
//{
//    await Task.Delay(1000);
//    Console.WriteLine("test");
//}

//Task t = RenderAsync();
////
////
////
//await t;






//async Task<int> Square(int n)
//{
//    //
//    //
//    await Task.Delay(1000);
//    return n * n;
//}

//int a = await Square(4);
//Console.WriteLine(a);





//async Task<int> Square(int n)
//{
//    //
//    //
//    await Task.Delay(1000);
//    return n * n;
//}

//async Task OperationAsync(int n)
//{
//    int result = await Square(n);

//    await Console.Out.WriteLineAsync(result.ToString());
//}

//_ = OperationAsync(5);


//Console.ReadLine();








//async Task RenderAsync(string message)
//{
//    await Task.Delay(1000);
//    Console.WriteLine(message);
//}

//Task t1 = RenderAsync("Vasia");
//Task t2 = RenderAsync("Petya");
//Task t3 = RenderAsync("Dima");

//// Task t = Task.WhenAll(t1, t2, t3);
//Task t = Task.WhenAny(t1, t2, t3);
//await t;







//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(1000);
//    return n * n;
//}

//Task<int> t1 = SquareAsync(2);
//Task<int> t2 = SquareAsync(3);
//Task<int> t3 = SquareAsync(5);

//int[] results = await Task.WhenAll(t1, t2, t3);

//foreach (var item in results)
//{
//    Console.WriteLine(item);
//}








async Task<bool> ValidateAsync(string str)
{
    await Task.Delay(500);

    if (str.Length < 5)
        throw new ArgumentException("Invalid string");

    return true;
}


try
{
    await ValidateAsync("vasiaaa");
    await ValidateAsync("vas");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

