using Microsoft.EntityFrameworkCore;
using StockMarketCrawler.Models;
using StockMarketCrawler.Services;

namespace StockMarketCrawler.Logic.JobHandler
{
    public class JobHandler
    {
        private readonly DatabaseService _db = new();
        private List<Task> _tasks = new();

        public JobHandler()
        {
            
        }

        public async Task Run()
        {
            List<Job> jobs = await GetViableJobsAsync();
            jobs.ForEach(job =>
            {
                _tasks.Add(Task.Run(() =>
                    Run(job)));
            });
            await Task.WhenAll(_tasks);
        }

        private async Task Run(Job job)
        {
            switch (job.Name)
            {
                case "GetTickers":
                    await new GetTickers.GetTickers().Run();
                    break;
                default:
                    break;
            }
        }

        private async Task<List<Job>> GetViableJobsAsync()
        {
            return await _db.Jobs
                .Where(job => job.Active)
                .Where(job => job.NextExecution <= DateTime.Now)
                .ToListAsync();
        }
    }
}
