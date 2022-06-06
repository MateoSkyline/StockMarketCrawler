using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Logic.JobHandler;
using StockMarketCrawler.Services;

ILogger _logger = new LoggerService();
IConfiguration _config = new ConfigurationService();

_logger.Log("StockMarketCrawler has started.");

int _timer = Int32.Parse(_config.GetValue("TRIGGER_TIME"));
PeriodicTimer timer = new(TimeSpan.FromSeconds(_timer));

while (await timer.WaitForNextTickAsync())
{
    await new JobHandler().Run();
}