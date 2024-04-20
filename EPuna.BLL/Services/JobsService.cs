using EPuna.DAL.Entities;
using EPuna.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPuna.BLL.IServices;
using System.Web.Mvc;

namespace EPuna.BLL.Services
{
    public class JobService : IJobsService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.ToListAsync();
        }

        [Authorize(Roles = "Admin")]
        public async Task<Job> CreateJobAsync(Job job)
        {
            _context.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _context.FindAsync(id);
        }

        public async Task<Job> UpdateJobAsync(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
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
