/*
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
*/

for(int i = 0; i < 10; i++)
{
    int taskNum = i;
    ThreadPool.QueueUserWorkItem(Task, taskNum);
}

Thread.Sleep(1000);


static void Task(object number)
{
    Console.WriteLine($"Number: {number} Thread: {Thread.CurrentThread.ManagedThreadId}");
}