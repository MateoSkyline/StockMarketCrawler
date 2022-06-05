using HtmlAgilityPack;
using StockMarketCrawler.Models;
using StockMarketCrawler.Logic;

namespace StockMarketCrawler.Logic.GetTickers
{
    public class GetTickersCrawler
    {
        public static async Task<List<TickerModel>> GetTickers()
        {
            string url = "https://infostrefa.com/infostrefa/pl/spolki";
            string html = await Crawler.CallUrl(url);
            List<TickerModel> tickers = await ParseDocument(html);
            return tickers;
        }
        
        private static async Task<List<TickerModel>> ParseDocument(string document)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(document);
            List<HtmlNode> tickers = doc.DocumentNode.SelectNodes("//div[@id='companiesList']/table/tbody/tr").ToList();
            List<TickerModel> tickerModels = new List<TickerModel>();
            foreach (HtmlNode ticker in tickers)
            {
                string _fullName = ticker.SelectSingleNode("td[1]").InnerText;
                string _tickerData = ticker.SelectSingleNode("td[3]").InnerText;
                TickerModel _ticker = new()
                {
                    FullName = _fullName,
                    Ticker = _tickerData
                };
                tickerModels.Add(_ticker);
            }
            return tickerModels;
        }
    }
}
