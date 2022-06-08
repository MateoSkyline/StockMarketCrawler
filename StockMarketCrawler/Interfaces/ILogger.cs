namespace StockMarketCrawler.Interfaces
{
    internal interface ILogger
    {
        void Log(string message);
        void StartJob(string jobName);
        void FinishJob(string jobName);
        void FinishCrawling(string ticker);
    }
}
