using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route(ApiRoutes.BaseRoutes)]
    [ApiController]
    public class UserProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
