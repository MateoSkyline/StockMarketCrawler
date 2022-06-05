using StockMarketCrawler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Logic.GetTickers
{
    public class GetTickers
    {
        private readonly GetTickersCrawler _crawler = new();
        private readonly GetTickersSaver _saver = new();
        public GetTickers()
        {
            
        }
        
        public async Task Run()
        {
            List<TickerModel> tickers = await GetTickersCrawler.GetTickers();
            await _saver.Save(tickers);
        }
    }
}
