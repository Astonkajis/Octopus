using Microsoft.AspNetCore.Mvc;

namespace Octopus.Api.Controllers
{
    [Route("api")]
    public class UserController : ControllerBase
    {
        public async Task<IEnumerable<int>> GetUserIds() {
            return [];
        }
    }
}
