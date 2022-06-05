using StockMarketCrawler.Models;
using StockMarketCrawler.Services;

namespace StockMarketCrawler.Logic.GetTickers
{
    public class GetTickersSaver
    {
        private readonly DatabaseService _db = new();

        public async Task Save(List<TickerModel> tickers)
        {
            tickers = await FilterTickers(tickers);
            tickers.ForEach(x => _db.AddAsync(x));
            await _db.SaveChangesAsync();
        }

        private async Task<List<TickerModel>> FilterTickers(List<TickerModel> tickers)
        {
            var tickersToRemove = _db.Tickers.ToList();
            tickers.RemoveAll(x => tickersToRemove.Any(y => y.Ticker == x.Ticker && y.FullName == x.FullName));
            return tickers;
        }
    }
}
