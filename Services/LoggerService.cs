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

        public void StartJob(string jobName)
        {
            Log($"[{jobName}] Job has started.");
        }

        public void FinishJob(string jobName)
        {
            Log($"[{jobName}] Job has finished.");
        }

        public void FinishCrawling(string ticker)
        {
            Log($"[{ticker}] Crawling has finished.");
        }
    }
}
