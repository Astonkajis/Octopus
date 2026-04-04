using Microsoft.AspNetCore.Mvc;
using Octopus.Core.User;

namespace Octopus.Api.Controllers
{
    /// <summary>
    /// Provides API endpoints for retrieving user information.
    /// </summary>
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Retrieves a collection of all users asynchronously.
        /// </summary>
        /// <returns>Enumerable collection of users. The collection is empty if no users are found.</returns>
        /// <response code="200">Returns a list of users.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return [];
        }

        /// <summary>
        /// Gets user by ID asynchronously.
        /// </summary>
        /// <param name="Id">User ID</param>
        /// <returns>User.</returns>
        /// <response code="200">Returns user.</response>
        /// <response code="404">User not found.</response>
        [HttpGet("id")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return new() { Id = Id };
        }
    }
}
