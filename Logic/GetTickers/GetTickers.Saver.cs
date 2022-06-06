using StockMarketCrawler.Models;
using StockMarketCrawler.Services;

namespace StockMarketCrawler.Logic.GetTickers
{
    public class GetTickersSaver
    {
        private readonly DatabaseService _db = new();

        public async Task Save(List<Ticker> tickers)
        {
            tickers = await FilterTickers(tickers);
            tickers.ForEach(x => _db.AddAsync(x));
            await _db.SaveChangesAsync();
        }

        private async Task<List<Ticker>> FilterTickers(List<Ticker> tickers)
        {
            var tickersToRemove = _db.Tickers.ToList();
            tickers.RemoveAll(x => tickersToRemove.Any(y => y.TickerSymbol == x.TickerSymbol && y.FullName == x.FullName));
            return tickers;
        }
    }
}
