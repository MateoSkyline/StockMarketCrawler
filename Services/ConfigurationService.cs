using StockMarketCrawler.Interfaces;

namespace StockMarketCrawler.Services
{
    internal class ConfigurationService : IConfiguration
    {
        public string GetValue(string name)
        {
            if (Environment.GetEnvironmentVariable(name) != null)
                return Environment.GetEnvironmentVariable(name);
            else
                throw new ConfigurationMissingException();
        }
    }
}
