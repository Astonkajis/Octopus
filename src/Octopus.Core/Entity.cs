namespace Octopus.Core
{
    /// <summary>
    /// Represents a base class for entities with a unique identifier.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public Ulid Id { get; set; } = Ulid.NewUlid();
    }
}
