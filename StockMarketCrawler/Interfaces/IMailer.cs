using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Interfaces
{
    public interface IMailer
    {
        Task SendMail(string recipients, string subject, string body);
    }
}
