

#region Intro

Thread t = new Thread(ShowPlus);
t.Start();

Console.WriteLine(t.IsAlive);

for (int i = 0; i < 1000; ++i)
    Console.Write('0');


void ShowPlus()
{
    for (int i = 0; i < 1000; ++i)
        Console.Write('+');
}



#endregion

