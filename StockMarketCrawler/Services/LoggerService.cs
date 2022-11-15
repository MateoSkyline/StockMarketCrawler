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

        public void StartCrawling(string jobName, string ticker)
        {
            Log($"[{jobName}] [{ticker}] Crawling has started.");
        }

        public void FinishCrawling(string jobName, string ticker)
        {
            Log($"[{jobName}] [{ticker}] Crawling has finished.");
        }
    }
}
