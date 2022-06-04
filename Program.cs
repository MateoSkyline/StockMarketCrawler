var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

while(await timer.WaitForNextTickAsync())
{
    Console.WriteLine("Something");
}