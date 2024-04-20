using EPuna.DAL.IRepositories;
using EPuna.DAL.Repositories;
using EPuna.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPuna.BLL
{
    public static class BLLStartup
    {
        public static void RegisterDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJobRepository, JobRepository>();
        }
    }
}
