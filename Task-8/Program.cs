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

/*
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
*/

/*
object lockedObj = new object();
int number = 0;

Thread thread1 = new Thread(IncrementNumber);
Thread thread2 = new Thread(IncrementNumber);

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();

Console.WriteLine($"number = {number}");

void IncrementNumber()
{
    for (int i = 0; i < 1000; i++)
    {
        lock (lockedObj)
        {
            number++;
        }
    }
    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ended its work");
}
*/
class Program
{
    private static Semaphore semaphore = new Semaphore(2, 2);
    static int number = 0;

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Increment);
        Thread thread2 = new Thread(Increment);
        Thread thread3 = new Thread(Increment);
        Thread thread4 = new Thread(Increment);
        Thread thread5 = new Thread(Increment);

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
        thread5.Join();
    }

    static void Increment()
    {
        semaphore.WaitOne();
        Console.WriteLine($"before. {number} in thread {Thread.CurrentThread.ManagedThreadId}");
        number++;
        Console.WriteLine($"after. {number} in thread {Thread.CurrentThread.ManagedThreadId}");
        semaphore.Release();
    }
}