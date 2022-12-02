using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Backend.Persistence.Entities;

namespace Backend.Persistence
{
    public class UserDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Host=localhost;Database=mlm;Username=postgres;Password=jp2gmd";

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(CONNECTION_STRING);
        }
    }
}
