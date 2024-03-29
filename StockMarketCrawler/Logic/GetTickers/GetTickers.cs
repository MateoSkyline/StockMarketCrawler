﻿using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;

namespace StockMarketCrawler.Logic.GetTickers
{
    public class GetTickers
    {
        private readonly GetTickersSaver _saver = new();
        private readonly ILogger _logger = new LoggerService();
        
        public GetTickers()
        {
            
        }
        
        public async Task<int> Run()
        {
            _logger.StartJob(this.GetType().Name);
            List<Ticker> tickers = await GetTickersCrawler.GetTickers();
            await _saver.Save(tickers);
            _logger.FinishJob(this.GetType().Name);
            return Status.Waiting;
        }
    }
}
