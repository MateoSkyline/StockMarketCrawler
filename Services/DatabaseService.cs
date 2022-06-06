using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Models;

namespace StockMarketCrawler.Services
{
    internal class DatabaseService : DbContext
    {
        private readonly IConfiguration _config = new ConfigurationService();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_config.GetConnectionString());
        }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
