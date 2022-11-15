using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Logic.GetTickers;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;
using System.Collections.Concurrent;

namespace StockMarketCrawler.Logic.GetDividends
{
    public class GetDividends
    {
        private readonly DatabaseService _db;
        private readonly GetDividendsSaver _saver;
        private readonly ILogger _logger = new LoggerService();

        public GetDividends()
        {
            _db = new DatabaseService();
            _saver = new GetDividendsSaver(_db);
        }

        public async Task<int> Run()
        {
            _logger.StartJob(this.GetType().Name);
            
            List<Ticker> tickers = await _db.Tickers.ToListAsync();
            ConcurrentBag<List<Dividend>> dividends = new();

            Parallel.ForEach(tickers, new ParallelOptions { MaxDegreeOfParallelism = 5 },
            ticker =>
            {
                dividends.Add(GetDividendsFromTicker(ticker).GetAwaiter().GetResult());
            });

            await _saver.Save(dividends.ToList());
            
            _logger.FinishJob(this.GetType().Name);
            return Status.Waiting;
        }
        
        private async Task<List<Dividend>> GetDividendsFromTicker(Ticker ticker)
        {
            _logger.StartCrawling(this.GetType().Name, ticker.TickerSymbol);
            List<Dividend> dividends = await GetDividendsCrawler.GetDividends(ticker);
            _logger.FinishCrawling(this.GetType().Name, ticker.TickerSymbol);
            return dividends;
        }
    }
}
