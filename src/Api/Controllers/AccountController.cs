using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Controllers.Account;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountFacade _facade;

        public AccountController(ILogger<AccountController> logger, IAccountFacade facade)
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
