using StockMarketCrawler.Interfaces;

namespace StockMarketCrawler.Services
{
    internal class LoggerService : ILogger
    {
        private static string GetTime()
        {
            return $"{DateTime.UtcNow.ToLocalTime():HH:mm:ss dd.MM.yyyy}";
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{GetTime()}] {message}");
        }
    }
}
