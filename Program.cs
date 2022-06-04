using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Services;

ILogger _logger = new LoggerService();
IConfiguration _config = new ConfigurationService();

int _triggerTime = Int32.Parse(_config.GetValue("PROCESS_TRIGGER_SECONDS"));
PeriodicTimer timer = new(TimeSpan.FromSeconds(_triggerTime));

while(await timer.WaitForNextTickAsync())
{
    _logger.Log("Something");
}