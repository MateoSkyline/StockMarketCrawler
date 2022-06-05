using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Logic.GetTickers;
using StockMarketCrawler.Services;

ILogger _logger = new LoggerService();
IConfiguration _config = new ConfigurationService();

_logger.Log("StockMarketCrawler has started.");


// Timer to obtain ticker info from stooq.pl

int _getTickersTimer = Int32.Parse(_config.GetValue("TRIGGER_GET_TICKERS"));
PeriodicTimer getTickersTimer = new(TimeSpan.FromSeconds(_getTickersTimer));

while (await getTickersTimer.WaitForNextTickAsync())
{
    await new GetTickers().Run();
}