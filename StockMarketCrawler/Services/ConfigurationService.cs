using StockMarketCrawler.Interfaces;
using System.Text;

namespace StockMarketCrawler.Services
{
    internal class ConfigurationService : IConfiguration
    {   
        public string GetValue(string name)
        {
            if (Environment.GetEnvironmentVariable(name) != null)
                return Environment.GetEnvironmentVariable(name);
            else
                throw new ConfigurationMissingException();
        }
        
        public string GetConnectionString()
        {
            StringBuilder connStr = new();
            connStr.Append($"Server={GetValue("DB_SERVER")};");
            connStr.Append($"Port={GetValue("DB_PORT")};");
            connStr.Append($"Database={GetValue("DB_NAME")};");
            connStr.Append($"User Id={GetValue("DB_USER")};");
            connStr.Append($"Password={GetValue("DB_PASSWORD")};");
            return connStr.ToString();
        }
    }
}
