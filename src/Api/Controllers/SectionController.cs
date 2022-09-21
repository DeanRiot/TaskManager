using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Controllers.Section;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ILogger<SectionController> _logger;
        private readonly ISectionFacade _facade;

        public SectionController(ILogger<SectionController> logger, ISectionFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }

        [HttpPost]
        public void Post(Model.Data.Board board) => _facade.CreateColumn(board);
        [HttpPut]
        public void Put(Model.Data.Column column) => _facade.UpdateColumn(column);
    }
}
