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
        public readonly DatabaseService _db;

        public GetDividendsSaver(DatabaseService db)
        {
            _db = db;
        }

        public async Task Save(List<List<Dividend>> dividends)
        {
            List<List<Dividend>> stocks = await FilterDividends(dividends);

            stocks.ForEach(stock =>
            {
                try
                {
                    var tickerReference = _db.Tickers.Include(d => d.Dividends).Where(t => t.Id == stock.First().Ticker.Id).First();
                    stock.ForEach(dividend => tickerReference.Dividends.Add(dividend));
                }
                catch(Exception)
                {
                    // For now just pass, TODO: Make some logic to handle this
                }
            });

            await _db.SaveChangesAsync();
        }

        private async Task<List<List<Dividend>>> FilterDividends(List<List<Dividend>> dividends)
        {
            dividends = await DeleteDuplicatedDividends(dividends);
            return dividends;
        }

        private async Task<List<List<Dividend>>> DeleteDuplicatedDividends(List<List<Dividend>> dividends)
        {
            var dividendsToRemove = _db.Dividends.ToList();
            dividends.ForEach(d => d.RemoveAll(x => dividendsToRemove.Any(y => y.DividendDate == x.DividendDate && y.DividendAmount == x.DividendAmount && y.Ticker == x.Ticker)));
            return dividends;
        }
    }
}
