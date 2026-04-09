namespace Octopus.Core.User
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Gets the name associated with the current instance.
        /// </summary>
        public string Name { get; private set; } = default!;

        /// <summary>
        /// Creates a new instance of the User class with the specified name.
        /// </summary>
        /// <param name="name">The name to assign to the new user. Cannot be null.</param>
        /// <returns>A new User entity.</returns>
        public static User Create(string name)
        {
            return new User() { Name = name };
        }
    }
}
