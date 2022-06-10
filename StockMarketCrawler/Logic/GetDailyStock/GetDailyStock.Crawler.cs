using HtmlAgilityPack;
using StockMarketCrawler.Models;

namespace StockMarketCrawler.Logic.GetDailyStock
{
    public class GetDailyStockCrawler
    {
        public static async Task<DailyStock> GetDailyStocks(Ticker ticker)
        {
            string DAILY_STOCKS_URL = $"https://strefainwestorow.pl/notowania/gpw/{ticker.TickerSymbol}";
            string html = await Crawler.GetHtml(DAILY_STOCKS_URL);
            if(CheckIfTickerHasDailyPrice(html))
            {
                DailyStock dailyStock = await ParseDocument(html, ticker);
                return dailyStock;
            }
            return new();
        }

        private static bool CheckIfTickerHasDailyPrice(string document)
        {
            if (document.Contains("instrument-summary-quotations"))
                return true;
            else
                return false;
        }

        private static async Task<DailyStock> ParseDocument(string document, Ticker ticker)
        {
            HtmlDocument doc = new();
            doc.LoadHtml(document);
            List<HtmlNode> dailyStock = doc.DocumentNode.SelectNodes("//div[@class='row instrument-summary-quotations']/div/div/div/div").ToList();
            DailyStock dailyStockModel = new DailyStock();
            dailyStockModel.Ticker = ticker;
            dailyStockModel.Date = DateTimeOffset.UtcNow;
            dailyStockModel.Price = ParsePrice(dailyStock.FirstOrDefault().InnerHtml);
            return dailyStockModel;
        }

        private static double ParsePrice(string price)
        {
            return double.Parse(price);
        }
    }
}
