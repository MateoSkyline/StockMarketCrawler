namespace StockMarketCrawler.Interfaces
{
    internal interface ILogger
    {
        void Log(string message);
        void StartJob(string jobName);
        void FinishJob(string jobName);
        void StartCrawling(string jobName, string ticker);
        void FinishCrawling(string jobName, string ticker);
    }
}
