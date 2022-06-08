using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketCrawler.Models
{
    [Table("jobs")]
    public class Job
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("name")]
        [MaxLength(128)]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(512)]
        public string? Description { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("crontab")]
        [MaxLength(32)]
        public string Crontab { get; set; }

        [Column("last_execution")]
        public DateTimeOffset? LastExecution { get; set; }

        [Column("next_execution")]
        public DateTimeOffset? NextExecution { get; set; }
    }
}
