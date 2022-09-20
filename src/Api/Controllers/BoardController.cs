using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Controllers.Board;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : Controller
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IBoardFacade _facade;

        public BoardController(ILogger<BoardController> logger, IBoardFacade facade)
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
