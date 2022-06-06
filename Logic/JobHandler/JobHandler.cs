﻿using Cronos;
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
            await SetLastExecutionTimeAsync(job);
            await SetJobStatus(job, Status.Running);
            int status = job.Name switch
            {
                "GetTickers" => await new GetTickers.GetTickers().Run(),
                _ => throw new ArgumentException(message: "Wrong job supplied", paramName: nameof(job))
            };
            await SetJobStatus(job, status);
            await SetNextExecutionTimeAsync(job);
        }

        private async Task<List<Job>> GetViableJobsAsync()
        {
            return await _db.Jobs
                .Where(job => job.Active)
                .Where(job => job.NextExecution <= DateTime.Now)
                .ToListAsync();
        }

        private async Task SetJobStatus(Job job, int status)
        {
            job.Status = status;
            await _db.SaveChangesAsync();
        }

        private async Task SetLastExecutionTimeAsync(Job job)
        {
            job.LastExecution = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }        

        private async Task SetNextExecutionTimeAsync(Job job)
        {
            CronExpression expression = CronExpression.Parse(job.Crontab);
            DateTime? nextUtc = expression.GetNextOccurrence(DateTime.UtcNow);
            job.NextExecution = nextUtc;
            await _db.SaveChangesAsync();
        }
    }
}