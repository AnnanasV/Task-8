var thread1 = new Thread(() =>
{
    for(int i = 0; i < 10; i++)
    {
        Console.WriteLine(Thread.CurrentThread.Name + "\t" + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(500);
    }
});

var thread2 = new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(Thread.CurrentThread.Name + "\t" + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(500);
    }
});

thread1.Name = "thread 1";
thread2.Name = "thread 2";

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();