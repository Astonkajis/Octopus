using Microsoft.AspNetCore.Mvc;

namespace Octopus.Api.Controllers
{
    /// <summary>
    /// Base API controller that all other API controllers should inherit from.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase;
}
