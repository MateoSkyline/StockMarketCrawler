using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketCrawler.Models
{
    [Table("user_stocks")]
    public class UserStock
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("email")]
        [MaxLength(128)]
        public string Email { get; set; }

        [Column("amount")]
        public int Amount { get; set; }

        [ForeignKey("ticker_id")]
        public Ticker Ticker { get; set; }
    }
}
