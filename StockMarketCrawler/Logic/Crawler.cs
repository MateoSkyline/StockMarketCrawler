using System.Net;

namespace StockMarketCrawler.Logic
{
    public class Crawler
    {
        public static async Task<string> GetHtml(string fullUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36 OPR/86.0.4363.70");
            client.DefaultRequestHeaders.Add("language", "pl-PL");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            try
            {
                var response = client.GetStringAsync(fullUrl);
                return await response;
            }
            catch(Exception)
            {
                return "";
            }
            
        }
    }
}