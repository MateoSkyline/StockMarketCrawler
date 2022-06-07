using HtmlAgilityPack;
using StockMarketCrawler.Models;
using StockMarketCrawler.Logic;

namespace StockMarketCrawler.Logic.GetTickers
{
    public class GetTickersCrawler
    {
        public static async Task<List<Ticker>> GetTickers()
        {
            string TICKERS_URL = "https://infostrefa.com/infostrefa/pl/spolki";
            string html = await Crawler.GetHtml(TICKERS_URL);
            List<Ticker> tickers = await ParseDocument(html);
            return tickers;
        }
        
        private static async Task<List<Ticker>> ParseDocument(string document)
        {
            HtmlDocument doc = new();
            doc.LoadHtml(document);
            List<HtmlNode> tickers = doc.DocumentNode.SelectNodes("//div[@id='companiesList']/table/tbody/tr").ToList();
            List<Ticker> tickerModels = new List<Ticker>();
            foreach (HtmlNode ticker in tickers)
            {
                string _fullName = ticker.SelectSingleNode("td[1]").InnerText;
                string _tickerData = ticker.SelectSingleNode("td[3]").InnerText;
                Ticker _ticker = new()
                {
                    FullName = _fullName,
                    TickerSymbol = _tickerData
                };
                tickerModels.Add(_ticker);
            }
            return tickerModels;
        }
    }
}
