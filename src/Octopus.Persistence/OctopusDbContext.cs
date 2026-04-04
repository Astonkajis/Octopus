using Microsoft.EntityFrameworkCore;
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
    }
}
