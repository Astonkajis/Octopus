namespace Octopus.Core.User
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Gets or sets the name associated with the current instance.
        /// </summary>
        public string Name { get; set; } = default!;
    }
}
