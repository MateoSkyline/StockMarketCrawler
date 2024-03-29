﻿using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Interfaces;
using StockMarketCrawler.Models;

namespace StockMarketCrawler.Services
{
    public class DatabaseService : DbContext
    {
        private readonly IConfiguration _config = new ConfigurationService();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_config.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticker>()
                .HasMany(d => d.Dividends)
                .WithOne(t => t.Ticker);
            modelBuilder.Entity<Ticker>()
                .HasMany(d => d.DailyStocks)
                .WithOne(t => t.Ticker);
            modelBuilder.Entity<Ticker>()
                .HasMany(u => u.UserStocks)
                .WithOne(t => t.Ticker);
        }
        
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Dividend> Dividends { get; set; }
        public DbSet<DailyStock> DailyStocks { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
    }
}
