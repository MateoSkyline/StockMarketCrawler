using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Logic.GetTickers;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;

namespace StockMarketCrawler.Logic.GetDividends
{
    public class GetDividends
    {
        private List<Task> _tasks = new();
        private readonly DatabaseService _db = new();
        private readonly GetDividendsSaver _saver = new();
        private readonly ILogger _logger = new LoggerService();

        public GetDividends()
        {

        }

        public async Task<int> Run()
        {
            _logger.StartJob(this.GetType().Name);
            
            List<Ticker> tickers = await _db.Tickers.ToListAsync();
            tickers.ForEach(ticker =>
            {
                _tasks.Add(Task.Run(() =>
                    GetDividendsFromTicker(ticker)));
            });
            Task.WaitAll();
            
            _logger.FinishJob(this.GetType().Name);
            return Status.Waiting;
        }

        private async Task GetDividendsFromTicker(Ticker ticker)
        {
            List<Dividend> dividends = await GetDividendsCrawler.GetDividends(ticker);
            await _saver.Save(dividends);
            _logger.FinishCrawling(ticker.TickerSymbol);
        }
    }
}
