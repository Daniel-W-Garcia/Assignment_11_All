class Program
{

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting async demo...");

        // Start all work at the same time
        Task sequentialTask = RunSequentialTasks();
        Task parallelTask = RunParallelTasks();
        Task squaresTask = RunParallelSquares();

        // Wait for all to complete
        await Task.WhenAll(squaresTask, sequentialTask, parallelTask);

        Console.WriteLine("\nDemo completed!");
    }

    static async Task RunSequentialTasks()
    {
        await LongRunningTaskAsync("Sequential Task 1", 2000);
        await LongRunningTaskAsync("Sequential Task 2", 1500);
        await LongRunningTaskAsync("Sequential Task 3", 1000);
    }

    static async Task RunParallelTasks()
    {
        Task task1 = LongRunningTaskAsync("Parallel Task 1", 2000);
        Task task2 = LongRunningTaskAsync("Parallel Task 2", 1500);
        Task task3 = LongRunningTaskAsync("Parallel Task 3", 1000);

        await Task.WhenAll(task1, task2, task3);
    }

    static async Task LongRunningTaskAsync(string taskName, int delayMs)
    {
        Console.WriteLine($"{taskName} started");
        await Task.Delay(delayMs); // Better than Thread.Sleep for async
        Console.WriteLine($"{taskName} completed");
    }
    static async Task RunParallelSquares()
    {
        // Array to hold results
        var squares = new int[100];

        // Compute i*i for i=1..100 in parallel
        Parallel.For(1, 101, i =>
        {
            int result = i * i;
            squares[i - 1] = result;
            Console.WriteLine($"Square of {i} is {result} on Thread {Thread.CurrentThread.ManagedThreadId}");
        });
    }
}