using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Logic.GetDailyStock
{
    public class GetDailyStockSaver
    {
        public readonly DatabaseService _db;

        public GetDailyStockSaver(DatabaseService db)
        {
            _db = db;
        }
        
        public async Task Save(List<DailyStock> stocks)
        {
            stocks.ForEach(stock =>
            {
                try
                {
                    if(stock.Ticker != null)
                    {
                        var tickerReference = _db.Tickers.Include(d => d.DailyStocks).Where(t => t.Id == stock.Ticker.Id).First();
                        tickerReference.DailyStocks.Add(stock);
                    }
                }
                catch (Exception)
                {
                    // For now just pass, TODO: Make some logic to handle this
                }
            });

            await _db.SaveChangesAsync();
        }
    }
}
