using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Backend.Persistence.Entities;

namespace Backend.Persistence
{
    public class BackendDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Host=localhost;Database=mlm;Username=postgres;Password=jp2gmd";

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<HandshakeEntity> Handshakes { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<DirectContactEntity> DirectRelations { get; set; }
        public DbSet<IndirectRelationEntity> IndirectRelations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*builder.Entity<DirectContactEntity>()
              .HasOne(c => c.Giver)
              .WithMany(c => c.DirectContacts);

            builder.Entity<DirectContactEntity>()
              .HasOne(c => c.Receiver)
              .WithMany(c => c.DirectContacts);*/
        }
    }
}
