using Microsoft.AspNetCore.Mvc;
using Octopus.Core.User;

namespace Octopus.Api.Controllers
{
    [Route("api")]
    public class UserController : ControllerBase
    {
        public static async Task<IEnumerable<User>> GetUsersAsync()
        {
            return [];
        }
    }
}
