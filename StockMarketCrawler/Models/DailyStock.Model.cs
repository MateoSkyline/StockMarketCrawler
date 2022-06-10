using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketCrawler.Models
{
    [Table("daily_stock")]
    public class DailyStock
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("date")]
        public DateTimeOffset? Date { get; set; }

        [ForeignKey("ticker_id")]
        public Ticker Ticker { get; set; }
    }
}
