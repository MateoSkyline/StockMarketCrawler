using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Logic.GetDividends;
using StockMarketCrawler.Logic.JobHandler;
using StockMarketCrawler.Services;

ILogger _logger = new LoggerService();
IConfiguration _config = new ConfigurationService();

_logger.Log("StockMarketCrawler has started.");

int _timer = Int32.Parse(_config.GetValue("TRIGGER_TIME"));
PeriodicTimer timer = new(TimeSpan.FromSeconds(_timer));

#if !DEBUG
while (await timer.WaitForNextTickAsync())
{
    await new JobHandler().Run();
}
#else
new GetDividends().Run().Wait();

while (await timer.WaitForNextTickAsync())
{
    // Don't die on debug mode
}
#endif