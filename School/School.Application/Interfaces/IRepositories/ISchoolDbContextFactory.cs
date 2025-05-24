using School.Domain.Contexts;

namespace School.Application.Interfaces.IRepositories
{
    public interface ISchoolDbContextFactory
    {
        public SchoolContext CreateDbContext(string[] args);
    }
}
