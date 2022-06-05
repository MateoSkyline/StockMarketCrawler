using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketCrawler.Models
{
    [Table("tickers")]
    public class TickerModel
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }
        
        [Column("ticker")]
        [MaxLength(16)]
        public string Ticker { get; set; }
        
        [Column("fullname")]
        [MaxLength(128)]
        public string FullName { get; set; }
    }
}
