using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using School.Application.Interfaces.IRepositories;
using School.Domain.Contexts;

namespace School.Application.Services
{
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>, ISchoolDbContextFactory
    {
        public SchoolContextFactory() { }
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            if (args?.Length > 0)
            {
                optionsBuilder.UseSqlServer(args[0]);
            }
            else
            {
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.{environmentName}.json")
                    .Build();
                optionsBuilder.UseSqlServer(config.GetSection("ConnectionStrings:SqlServer").Value);
            }
            return new SchoolContext(optionsBuilder.Options);


        }
    }
}