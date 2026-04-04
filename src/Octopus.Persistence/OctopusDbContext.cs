using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Octopus.Core;
using Octopus.Core.User;

namespace Octopus.Persistence
{
    /// <summary>
    /// Represents a session with the Octopus database, providing access to entity sets and database operations.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the OctopusDbContext class.
    /// </remarks>
    public sealed class OctopusDbContext(DbContextOptions<OctopusDbContext> options) : DbContext(options)
    {

        /// <summary>
        /// Gets or sets the collection of users in the database context.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ulidConverter = new ValueConverter<Ulid, string>(
                v => v.ToString(),
                v => Ulid.Parse(v)
            );

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasConversion(ulidConverter);
            });
        }
    }
}
