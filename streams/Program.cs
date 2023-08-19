// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
 //Connection();
 //using tasks
Task t10 = new Task(new Action(Connection));
Task<string> t11=new Task<string>(()=>ConnectionD("sss"));
t10.Start();
t11.Start();
//uncomment this and program will wait when tasks is finished and then go
Console.WriteLine(t11.Result);
//end using tasks



//using async function
 ConnectionAsync("sss",'_'); 
ConnectionAsync("ddd",'*');
var t1 = ConnectionAsync("ttt", 'q');
var t2 = ConnectionAsync("ttt", 'w');
 


Console.WriteLine("i am waiting. It the End of the program");

Console.ReadLine();

void Connection()
{

    Console.WriteLine("start connection in thread "+Thread.CurrentThread.ManagedThreadId);
    for (int i = 0; i < 200; i++)
    {
        Console.Write('D');
        Thread.Sleep(10);
    }

    Console.WriteLine("\nEnd connection in thread " + Thread.CurrentThread.ManagedThreadId);
}
string ConnectionD(string s)
{

    Console.WriteLine("start connection in thread " + Thread.CurrentThread.ManagedThreadId);
    for (int i = 0; i < 200; i++)
    {
        Console.Write('S');
        Thread.Sleep(10);
    }

    Console.WriteLine("\nEnd connection in thread " + Thread.CurrentThread.ManagedThreadId);
    return ("Message ConnectionD is Finished");
}
async Task<string> ConnectionAsync(string _str, char simbol) 
{
    try
    {
        if (string.IsNullOrEmpty(_str))
            throw new ArgumentNullException("Argumnet is null or zero length");
    }
    catch (Exception ex) 
    { Console.WriteLine(ex.Message); return(ex.Message); }
    Console.WriteLine("Here the main thread!!!! \nstart connection to SQL in thread " + Thread.CurrentThread.ManagedThreadId);
    await LongConnectionAS(simbol);
    Console.WriteLine("\nEnd connection to SQL in thread " + Thread.CurrentThread.ManagedThreadId);
    return ("method ConnectionAsync has done");
}
//not an async function because there is no await in it. so it works synchronius
async Task<int> LongConnectionS(char simbol)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            Console.Write("SQL" + simbol);
            Thread.Sleep(10);
        }
        Console.WriteLine();
    }
    return(0);
}
async Task LongConnectionAS(char simbol)
{
    await Task.Run(() =>
    {
        Console.WriteLine("start connection to SQL in thread " + Thread.CurrentThread.ManagedThreadId);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Console.Write("SQL" + simbol);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
    });
}
