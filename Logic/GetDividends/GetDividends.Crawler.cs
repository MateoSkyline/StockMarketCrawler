using HtmlAgilityPack;
using StockMarketCrawler.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Logic.GetDividends
{
    public class GetDividendsCrawler
    {
        public static async Task<List<Dividend>> GetDividends(Ticker ticker)
        {
            string DIVIDENDS_URL = $"https://strefainwestorow.pl/notowania/gpw/{ticker.TickerSymbol}/dywidendy";
            string html = await Crawler.GetHtml(DIVIDENDS_URL);
            if (CheckIfTickerHasDividends(html))
            {
                List<Dividend> dividends = await ParseDocument(html, ticker);
                return dividends;
            }
            return new();
        }
        
        private static bool CheckIfTickerHasDividends(string document)
        {
            if (document.Contains("instrument-dividends"))
                return true;
            else
                return false;
        }

        private static async Task<List<Dividend>> ParseDocument(string document, Ticker ticker)
        {
            HtmlDocument doc = new();
            doc.LoadHtml(document);
            List<HtmlNode> dividends = doc.DocumentNode.SelectNodes("//table[contains(@class, 'instrument-dividends')]/tr[@class='instrument-dividend']").ToList();
            List<Dividend> dividendModels = new List<Dividend>();
            foreach (HtmlNode dividend in dividends)
            {
                string _year = dividend.SelectSingleNode("td[1]").InnerText;
                string _dividendDate = dividend.SelectSingleNode("td[2]").InnerText;
                string _paymentDate = dividend.SelectSingleNode("td[4]").InnerText;
                string _dividendAmount = dividend.SelectSingleNode("td[5]").InnerText;
                try
                {
                    Dividend _dividend = new()
                    {
                        DividendAmount = ParseDividendAmount(_dividendAmount),
                        DividendDate = ParseDividendDate(_dividendDate),
                        PaymentDate = ParseDividendDate(_paymentDate),
                        Year = ParseDividendYear(_year)
                    };
                    dividendModels.Add(_dividend);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return dividendModels;
        }
        
        private static double ParseDividendAmount(string dividendAmount)
        {
            return double.Parse(dividendAmount
                .Replace(" ", "")
                .Replace("zł", ""));
        }

        private static DateTimeOffset ParseDividendDate(string dividendDate)
        {
            return DateTimeOffset.ParseExact(dividendDate
                .Replace(" ", ""), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        private static int ParseDividendYear(string year)
        {
            return int.Parse(year);
        }
    }
}
