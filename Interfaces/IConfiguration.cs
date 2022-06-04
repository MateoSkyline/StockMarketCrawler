namespace StockMarketCrawler.Interfaces
{
    internal interface IConfiguration
    {
        string GetValue(string name);
    }
}
