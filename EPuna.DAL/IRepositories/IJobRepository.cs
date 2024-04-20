using EPuna.DAL.Entities;

namespace EPuna.DAL.IRepositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> CreateJobAsync(Job job);
        Task<Job> GetJobByIdAsync(int id);
        Task<Job> UpdateJobAsync(Job job);
        Task DeleteJobAsync(int id);
    }
}