using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Controllers.Auth;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthFacade _facade;

        public AuthController(ILogger<AuthController> logger, IAuthFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }


        [HttpGet]
        public void Get()
        {

        }
    }
}
