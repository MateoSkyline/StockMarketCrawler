using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Logic.GetDividends
{
    public class GetDividendsSaver
    {
        private readonly DatabaseService _db = new();
        
        public async Task Save(List<Dividend> dividends)
        {
            dividends = await FilterTickers(dividends);
            var ticker = _db.Tickers.Include(d => d.Dividends).First();
            dividends.ForEach(x => ticker.Dividends.Add(x));
            await _db.SaveChangesAsync();
        }

        private async Task<List<Dividend>> FilterTickers(List<Dividend> dividends)
        {
            var dividendsToRemove = _db.Dividends.ToList();
            dividends.RemoveAll(x => dividendsToRemove.Any(y => y.DividendDate == x.DividendDate && y.DividendAmount == x.DividendAmount && y.Ticker == x.Ticker));
            return dividends;
        }
    }
}
