using StockMarketCrawler.Logic.GetTickers;
using StockMarketCrawler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StockMarketCrawler.Tests.Logic
{
    public class GetTickers
    {
        [Fact]
        public async Task GetTickersTest()
        {
            List<Ticker> tickers = await GetTickersCrawler.GetTickers();
            Assert.IsType<List<Ticker>>(tickers);
            Assert.NotEmpty(tickers);
        }
    }
}
