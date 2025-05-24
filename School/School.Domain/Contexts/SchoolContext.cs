using Microsoft.EntityFrameworkCore;
using School.Domain.ModelsDto;

namespace School.Domain.Contexts
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<UserDto> Users { get; set; }
        public DbSet<GroupDto> Groups { get; set; }
        public DbSet<PermissionDto> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>()
            .HasData(
                new UserDto
                {
                    Id = 1,
                    Name = "Harry",
                    Surname = "Potter",
                    Groups = [1, 2]
                },
                new UserDto
                {
                    Id = 2,
                    Name = "Ron",
                    Surname = "Weasely",
                    Groups = [1]
                }
            );

            modelBuilder.Entity<GroupDto>()
            .HasData(
                new GroupDto()
                {
                    Id = 1,
                    Name = "Wizard",
                    Permissions = [1]
                },
                new GroupDto()
                {
                    Id = 2,
                    Name = "Orphan",
                    Permissions = [2]
                }
            );

            modelBuilder.Entity<PermissionDto>()
           .HasData(
               new PermissionDto()
               {
                   Id = 1,
                   Name = "CanCast"
               },
               new PermissionDto()
               {
                   Id = 2,
                   Name = "HasBed"
               }
           );
        }
    }
}
