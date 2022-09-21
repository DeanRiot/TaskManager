using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        public IEnumerable<Model.Data.Board> Get(uint? id) => _facade.Get(id);

        [HttpPost]
        public uint? Post(Model.Data.Board board)
        {
            var id = _facade.Create(board);
            if (id is null)
            {
                Response.StatusCode = 201;
                return null;
            }
            return id;
        }
        

        [HttpPut]
        public void Put(Model.Data.Board board) => _facade.Update(board);
    }
}
