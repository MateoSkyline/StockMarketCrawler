using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Logic.GetDividends;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;
using System.Collections.Concurrent;

namespace StockMarketCrawler.Logic.GetDailyStock
{
    public class GetDailyStock
    {
        private readonly DatabaseService _db;
        private readonly GetDailyStockSaver _saver;
        private readonly ILogger _logger = new LoggerService();

        public GetDailyStock()
        {
            _db = new DatabaseService();
            _saver = new GetDailyStockSaver(_db);
        }

        public async Task<int> Run()
        {
            _logger.StartJob(this.GetType().Name);
            
            List<Ticker> tickers = await GetViableStocks();
            ConcurrentBag<DailyStock> dailyStocks = new();

            Parallel.ForEach(tickers, new ParallelOptions { MaxDegreeOfParallelism = 50 },
            ticker =>
            {
                dailyStocks.Add(GetDailyStocksFromTicker(ticker).GetAwaiter().GetResult());
            });

            await _saver.Save(dailyStocks.ToList());
            
            _logger.FinishJob(this.GetType().Name);
            return Status.Waiting;
        }

        private async Task<List<Ticker>> GetViableStocks()
        {
            List<DailyStock> stocksWithTodaysPrice = await _db.DailyStocks.Where(s => s.Date.Value.Date == DateTimeOffset.UtcNow.Date).ToListAsync();
            List<Ticker> tickers = await _db.Tickers.ToListAsync();
            
            tickers.RemoveAll(t => stocksWithTodaysPrice.Any(s => s.Ticker.Id == t.Id));
            return tickers;
        }

        private async Task<DailyStock> GetDailyStocksFromTicker(Ticker ticker)
        {
            _logger.StartCrawling(this.GetType().Name, ticker.TickerSymbol);
            DailyStock dailyStocks = await GetDailyStockCrawler.GetDailyStocks(ticker);
            _logger.FinishCrawling(this.GetType().Name, ticker.TickerSymbol);
            return dailyStocks;
        }
    }
}
