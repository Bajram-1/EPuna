using EPuna.DAL.Entities;
using EPuna.DAL.IRepositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPuna.DAL.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public JobRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(int jobId)
        {
            Job job;
            string cacheKey = $"Job_{jobId}";
            if (!_cache.TryGetValue(cacheKey, out job))
            {
                job = await _context.Jobs.FindAsync(jobId);
                if (job != null)
                {
                    _cache.Set(cacheKey, job, new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return job;
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            _context.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> UpdateJobAsync(Job job)
        {
            _context.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task DeleteJobAsync(int id)
        {
            var job = await _context.FindAsync(id);
            if (job != null)
            {
                _context.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
