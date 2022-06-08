using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Models
{
    [Table("dividends")]
    public class Dividend
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("dividend_amount")]
        public double DividendAmount { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("dividend_date")]
        public DateTimeOffset? DividendDate { get; set; }
        
        [Column("payment_date")]
        public DateTimeOffset? PaymentDate { get; set; }
        
        [ForeignKey("ticker_id")]
        public Ticker Ticker { get; set; }
    }
}
