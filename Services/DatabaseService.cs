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
        public DbSet<TickerModel> Tickers { get; set; }
    }
}
