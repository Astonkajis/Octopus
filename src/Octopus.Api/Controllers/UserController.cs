using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Octopus.Core.User;
using Octopus.Persistence;

namespace Octopus.Api.Controllers
{
    /// <summary>
    /// Provides API endpoints for retrieving user information.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the UserController class using the specified database context.
    /// </remarks>
    /// <param name="DbContext">The database context to be used for data access operations. Cannot be null.</param>
    public class UserController(OctopusDbContext DbContext) : BaseApiController
    {
        /// <summary>
        /// Retrieves a collection of all users asynchronously.
        /// </summary>
        /// <returns>Enumerable collection of users. The collection is empty if no users are found.</returns>
        /// <response code="200">Returns a list of users.</response>
        [HttpGet]
        [OutputCache(Duration = 60)]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<User>>> GetUsersAsync()
        {
            return Ok(await DbContext.Users.ToListAsync());
        }

        /// <summary>
        /// Gets user by ID asynchronously.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>User.</returns>
        /// <response code="200">Returns user.</response>
        /// <response code="404">User not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserByIdAsync(Ulid id)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user with the specified name asynchronously.
        /// </summary>
        /// <param name="name">The name to assign to the new user. Cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the unique identifier of the
        /// newly created user.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Ulid), StatusCodes.Status200OK)]
        public async Task<ActionResult<Ulid>> CreateUserAsync(string name)
        {
            User user = Octopus.Core.User.User.Create(name);

            await DbContext.Users.AddAsync(user);

            return Ok(user.Id);
        }
    }
}
