using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketCrawler.Models
{
    [Table("tickers")]
    public class Ticker
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }
        
        [Column("ticker")]
        [MaxLength(16)]
        public string TickerSymbol { get; set; }
        
        [Column("fullname")]
        [MaxLength(128)]
        public string FullName { get; set; }

        public ICollection<Dividend> Dividends { get; set; }
        public ICollection<DailyStock> DailyStocks { get; set; }
        public ICollection<UserStock> UserStocks { get; set; }
    }
}
